/// ---------------------------------------------
/// Ultimate Character Controller
/// Copyright (c) Opsive. All Rights Reserved.
/// https://www.opsive.com
/// ---------------------------------------------
//#define DEBUG_BRIDGE

namespace Opsive.UltimateCharacterController.Integrations.UltimateInventorySystem
{
    using Opsive.Shared.Inventory;
    using Opsive.Shared.StateSystem;
    using Opsive.Shared.Utility;
    using Opsive.UltimateCharacterController.Inventory;
    using Opsive.UltimateInventorySystem.Core;
    using Opsive.UltimateInventorySystem.Utility;
    using System;
    using System.Collections.Generic;
    using UnityEngine;
    using EventHandler = Opsive.Shared.Events.EventHandler;

    /// <summary>
    /// The item set state info is
    /// </summary>
    public struct ItemSetStateInfo
    {
        public enum SetState{
            Keep,
            Add,
            Remove
        }

        private ItemSetRuleInfo m_RuleInfo;
        private ItemSet m_ItemSet;
        private SetState m_State;

        public ItemSetRuleInfo RuleInfo => m_RuleInfo;
        public ItemSet ItemSet => m_ItemSet;
        public SetState State => m_State;

        public ItemSetStateInfo(ItemSetRuleInfo ruleInfo, ItemSet itemSet, SetState state)
        {
            m_RuleInfo = ruleInfo;
            m_ItemSet = itemSet;
            m_State = state;
        }
    }
    
    /// <summary>
    /// The ItemSetManager manages the ItemSets belonging to the character for Ultimate Inventory System inventories.
    /// </summary>
    public class InventoryItemSetManager : ItemSetManagerBase
    {
        
        [Tooltip("The Item Set Rules Object is used to define the Item Sets to create at runtime.")]
        [SerializeField] protected ItemSetRulesObject m_ItemSetRulesObject;

        protected List<ItemSetStateInfo> m_TemporaryItemSetStateList;
        
        protected Dictionary<ItemSet, IItemSetRule> m_ItemSetToRuleMap;
        protected Dictionary<IItemSetRule,List<ItemSet>> m_RuleToItemSetsMap;
        protected int[] m_TemporarySetCount;
        protected int[] m_TemporaryAssignedActiveItemSet;
        protected int[] m_TemporaryAssignedNextItemSet;
        protected (ItemSet active, ItemSet next)[] m_TemporaryActiveNextItemSet;
        protected Func<ItemSet, bool> m_IgnoreItemSetOnAddItem;

        public int CategoryCount => m_CategoryItemSets.Length;
        public int SlotCount => m_ItemSetRulesObject.SlotCount;
        
        public ItemSetRulesObject ItemSetRulesObject
        {
            get { return m_ItemSetRulesObject; }
            set { m_ItemSetRulesObject = value; }
        }

        /// <summary>
        /// Initializes the ItemSetManager.
        /// </summary>
        /// <param name="force">Should the ItemSet be force initialized?</param>
        public override void Initialize(bool force)
        {
            if (m_Initialized && !force) {
                return;
            }

            m_TemporaryItemSetStateList = new List<ItemSetStateInfo>();
            m_ItemSetToRuleMap = new Dictionary<ItemSet, IItemSetRule>();
            m_RuleToItemSetsMap = new Dictionary<IItemSetRule, List<ItemSet>>();

            Initialize(m_ItemSetRulesObject);
        }

        /// <summary>
        /// Initialize using an array of categories.
        /// </summary>
        /// <param name="categories">The categories.</param>
        public void Initialize(ItemSetRulesObject itemSetRulesObject)
        {
            m_ItemSetRulesObject = itemSetRulesObject;
            m_Initialized = true;

            if (m_ItemSetRulesObject == null) {
                m_CategoryItemSets = null;
                return;
            }
            
            m_ItemSetRulesObject.Initialize(false);

            var validCategoryCount = m_ItemSetRulesObject.CategoryItemSetRules.Length;

            // Initialize the categories.
            if (m_CategoryItemSets == null) {
                m_CategoryItemSets = new CategoryItemSet[validCategoryCount];
            } else if (m_CategoryItemSets.Length != validCategoryCount) {
                System.Array.Resize(ref m_CategoryItemSets, validCategoryCount);
            }
            
            if (m_CategoryIndexMap == null) {
                m_CategoryIndexMap = new Dictionary<IItemCategoryIdentifier, int>();
            } else {
                m_CategoryIndexMap.Clear();
            }
            
            m_ActiveItemSetIndex = new int[m_CategoryItemSets.Length];
            m_NextItemSetIndex = new int[m_CategoryItemSets.Length];
            m_TemporarySetCount = new int[m_CategoryItemSets.Length];
            m_TemporaryAssignedActiveItemSet = new int[m_CategoryItemSets.Length];
            m_TemporaryAssignedNextItemSet = new int[m_CategoryItemSets.Length];
            m_TemporaryActiveNextItemSet = new (ItemSet, ItemSet)[m_CategoryItemSets.Length];

            m_IgnoreItemSetOnAddItem = IgnoreItemSetOnAddItem;
            
            var index = 0;
            for (int i = 0; i < m_ItemSetRulesObject.CategoryItemSetRules.Length; ++i) {

                var category = m_ItemSetRulesObject.CategoryItemSetRules[i].ItemCategory;
                m_ActiveItemSetIndex[index] = -1;
                m_NextItemSetIndex[index] = -1;
                if (m_CategoryItemSets[index] == null) {
                    m_CategoryItemSets[index] = new CategoryItemSet(category.ID, category.name, category);
                } else {
                    m_CategoryItemSets[index].ItemCategory = category;
                }

                // Create a mapping between the category and index.
                m_CategoryIndexMap.Add(category, index);
                
                //TODO Do not use the serialized data?
                m_CategoryItemSets[index].ItemSetList = new List<ItemSet>();
                /*// The ItemSet must be initialized.
                //TODO remove this?
                for (int j = 0; j < m_CategoryItemSets[index].ItemSetList.Count; ++j) {
                    m_CategoryItemSets[index].ItemSetList[j].Initialize(gameObject, this, m_CategoryItemSets[index].CategoryID, index, j);
                }*/
                
                index++;
            }
        }
        
        /// <summary>
        /// Copies the CategoryItemSets from the specified category. Can be used for loading from a previous save.
        /// </summary>
        /// <param name="categoryItemSets">The CategoryItemSets that should be copied.</param>
        public void CopyFrom(CategoryItemSet[] categoryItemSets)
        {
            if (categoryItemSets == null) {
                return;
            }
            for (int i = 0; i < m_CategoryItemSets.Length; ++i) {
                // Copy the item fields of each category.
                m_CategoryItemSets[i].ItemSetList.Clear();
                m_CategoryItemSets[i].DefaultItemSetIndex = categoryItemSets[i].DefaultItemSetIndex;

                // Copy each ItemSet. Do not copy the ItemIdentifier as it will be assigned later.
                for (int j = 0; j < categoryItemSets[i].ItemSetList.Count; ++j) {
                    m_CategoryItemSets[i].ItemSetList.Add(new ItemSet(categoryItemSets[i].ItemSetList[j]));
                    m_CategoryItemSets[i].ItemSetList[j].ItemIdentifiers = new IItemIdentifier[categoryItemSets[i].ItemSetList[j].Slots.Length];
                }
            }
            // Reset the active ItemSet index. No ItemSet is active when the ItemSets are restored.
            m_ActiveItemSetIndex = new int[m_ActiveItemSetIndex.Length];
            m_NextItemSetIndex = new int[m_ActiveItemSetIndex.Length];
            for (int i = 0; i < m_ActiveItemSetIndex.Length; ++i) {
                m_ActiveItemSetIndex[i] = -1;
                m_NextItemSetIndex[i] = -1;
            }
#if DEBUG_BRIDGE
            Debug.Log(categoryItemSets[0].ItemSetList.Count + " " + m_CategoryItemSets[0].ItemSetList.Count);
#endif
        }

        /// <summary>
        /// Adds the item with the specified ItemCategoryIdentifier.
        /// </summary>
        /// <param name="item">The item that should be added.</param>
        /// <param name="category">The category that the item should be aded to.</param>
        protected override void AddItem(Items.Item item, IItemCategoryIdentifier category)
        {
            // Do nothing, the item sets are added via the item set rules.
        }
        
        /// <summary>
        /// Add an Item Set.
        /// </summary>
        /// <param name="item">The character item.</param>
        /// <param name="category">The category.</param>
        protected override void AddItemSet(Items.Item item, IItemCategoryIdentifier category)
        {
            // Do nothing, the item sets are added via the item set rules.
            // AddItemSet(item, category, m_IgnoreItemSetOnAddItem);
        }

        /// <summary>
        /// Ignore the item set when adding the item?
        /// </summary>
        /// <param name="itemSet">The item set to add.</param>
        /// <returns>Ignore?</returns>
        public bool IgnoreItemSetOnAddItem(ItemSet itemSet)
        {
            return m_ItemSetToRuleMap.ContainsKey(itemSet);
        }

        /// <summary>
        /// Get the Item Set Rule mapped to the Item Set.
        /// </summary>
        /// <param name="itemSet">The item set.</param>
        /// <returns>THe item set rule.</returns>
        public IItemSetRule GetRuleFor(ItemSet itemSet)
        {
            if (itemSet == null) { return null;}
            m_ItemSetToRuleMap.TryGetValue(itemSet, out var rule);
            return rule;
        }

        /// <summary>
        /// Get the item sets mapped to the rule
        /// </summary>
        /// <param name="rule">The item set rule.</param>
        /// <returns>The item sets.</returns>
        public ListSlice<ItemSet> GetItemSetsFor(IItemSetRule rule)
        {
            if (rule == null) { return (null,0,0);}
            m_RuleToItemSetsMap.TryGetValue(rule, out var itemSets);
            return itemSets;
        }

        /// <summary>
        /// Update the item sets using the item set rules.
        /// </summary>
        /// <param name="items">The items used to create the new item sets.</param>
        public void UpdateItemSets(ListSlice<Item> items)
        {
            var pooledItemCategorySetList = GenericObjectPool.Get<List<ItemSetRuleInfo>>();
            var pooledItemSets = GenericObjectPool.Get<List<ItemSet>>();
            pooledItemCategorySetList.Clear();
            pooledItemSets.Clear();
            
            m_TemporaryItemSetStateList.Clear();
            
            //Determine which item sets should be added, remove and kept.
            for (int i = 0; i < m_ItemSetRulesObject.CategoryItemSetRules.Length; i++) {
                var categoryItemSetRule = m_ItemSetRulesObject.CategoryItemSetRules[i];
                    
                for (int j = 0; j < categoryItemSetRule.ItemSetRules.Count; j++) {
                    
                    var rule = categoryItemSetRule.ItemSetRules[j];
                    var ruleInfo = new ItemSetRuleInfo(i, categoryItemSetRule, j, rule);
                    var newItemSets = rule.GetItemSetsFor(items);

                    m_RuleToItemSetsMap.TryGetValue(rule, out var ruleItemSets);

                    AddItemSetStateForRule(ruleInfo, ruleItemSets, newItemSets);
                }
            }

            EventHandler.ExecuteEvent<List<ItemSetStateInfo>>(m_GameObject,
                IntegrationEventNames.c_GameObject_ItemSetsWillUpdate_ListOfItemSetStateInfo,
                m_TemporaryItemSetStateList);

            //Reset the index.
            for (int i = 0; i < m_CategoryItemSets.Length; i++) {
                m_CategoryItemSets[i].DefaultItemSetIndex = -1;
                m_TemporarySetCount[i] = 0;
                m_TemporaryAssignedActiveItemSet[i] = -1;
                m_TemporaryAssignedNextItemSet[i] = -1;
                m_TemporaryActiveNextItemSet[i] = (GetActiveItemSet(i), GetNextItemSet(i));
            }

            for (int i = 0; i < m_TemporaryItemSetStateList.Count; i++) {
                var itemSetStateInfo = m_TemporaryItemSetStateList[i];
                var categoryIndex = itemSetStateInfo.RuleInfo.CategoryIndex;
                var categoryItemSet = m_CategoryItemSets[categoryIndex];
                var itemSet = itemSetStateInfo.ItemSet;
                var setCount = m_TemporarySetCount[categoryIndex];

                //Add/Remove the ItemSets and update index, for default, active, next, etc...

                switch (itemSetStateInfo.State) {
                    case ItemSetStateInfo.SetState.Keep: {
                        //Update and move Index
                        itemSet.Index = setCount;
                        categoryItemSet.ItemSetList.Remove(itemSet);
                        categoryItemSet.ItemSetList.Insert(setCount, itemSet);

                        if (m_TemporaryAssignedActiveItemSet[categoryIndex] == -1 &&
                            (m_TemporaryActiveNextItemSet[categoryIndex].active == itemSet)){
                            m_TemporaryAssignedActiveItemSet[categoryIndex] = setCount;
                        }
                        
                        if (m_TemporaryAssignedNextItemSet[categoryIndex] == -1 &&
                            (m_TemporaryActiveNextItemSet[categoryIndex].next == itemSet )){
                            m_TemporaryAssignedNextItemSet[categoryIndex] = setCount;
                        }

                        setCount++;
                        break;
                    }
                    case ItemSetStateInfo.SetState.Add: {
                        itemSet.Index = setCount;
                        categoryItemSet.ItemSetList.Insert(setCount, itemSet);

                        setCount++;
                        break;
                    }
                    case ItemSetStateInfo.SetState.Remove: {
                        categoryItemSet.ItemSetList.Remove(itemSet);

                        if (m_TemporaryActiveNextItemSet[categoryIndex].active == itemSet
                            && string.IsNullOrWhiteSpace(itemSet.State) == false) {
                            StateManager.SetState(m_GameObject, itemSet.State, false);
                        }

                        DestroyItemSet(itemSet);
                        break;
                    }
                    default: {
                        throw new ArgumentOutOfRangeException();
                    }
                }
                m_TemporarySetCount[categoryIndex] = setCount;
                
                if (itemSetStateInfo.RuleInfo.ItemSetRule.Default) {
                    categoryItemSet.DefaultItemSetIndex = setCount - 1;
                }
            }

            for (int categoryIndex = 0; categoryIndex < m_CategoryItemSets.Length; categoryIndex++) {
                var newActiveIndex = m_TemporaryAssignedActiveItemSet[categoryIndex];
                var newNextIndex = m_TemporaryAssignedNextItemSet[categoryIndex];

                //The active index needs to be set to the next index if it is -1;
                newActiveIndex = newActiveIndex != -1 ? newActiveIndex : newNextIndex;
                
                //TODO Force the update to happen by setting the index to minus one? Maybe set a different value from temporary to really force it?
                m_ActiveItemSetIndex[categoryIndex] = -1;
                m_NextItemSetIndex[categoryIndex] = -1;
                
                UpdateActiveItemSet(categoryIndex, newActiveIndex);
                UpdateNextItemSet(categoryIndex, newNextIndex);
                EventHandler.ExecuteEvent(m_GameObject, "OnItemSetIndexChange", categoryIndex, m_ActiveItemSetIndex[categoryIndex]);
            }

            GenericObjectPool.Return(pooledItemSets);
            GenericObjectPool.Return(pooledItemCategorySetList);
            
            EventHandler.ExecuteEvent(m_GameObject, IntegrationEventNames.c_GameObject_ItemSetsUpdated);
        }

        /// <summary>
        /// Add the item sets with their state to the item set state list.
        /// </summary>
        /// <param name="itemSetRuleInfo">The item set rule info.</param>
        /// <param name="currentItemSets">The item sets currently in the category.</param>
        /// <param name="newItemSets">The new items that could potentially be added.</param>
        protected void AddItemSetStateForRule(ItemSetRuleInfo itemSetRuleInfo, List<ItemSet> currentItemSets, ListSlice<ItemSet> newItemSets)
        {
            var newItemSetList = GenericObjectPool.Get<List<ItemSet>>();
            newItemSetList.Clear();
            newItemSetList.AddRange(newItemSets);

            if (currentItemSets != null) {
                var slotCount = m_ItemSetRulesObject.SlotCount;
                for (int i = 0; i < currentItemSets.Count; i++) {

                    var currentItemSet = currentItemSets[i];
                    var foundSetMatch = false;
                    for (int j = newItemSetList.Count - 1; j >= 0; j--) {
                        var newItemSet = newItemSetList[j];

                        if(currentItemSet.State != newItemSet.State){ continue; }
                        
                        var allSlotMatch = true;
                        for (int k = 0; k < slotCount; k++) {
                            if (currentItemSet.ItemIdentifiers[k] != newItemSet.ItemIdentifiers[k]) {
                                allSlotMatch = false;
                                break;
                            }
                        }

                        if (allSlotMatch) {
                            foundSetMatch = true;
                            m_TemporaryItemSetStateList.Add(
                                new ItemSetStateInfo(itemSetRuleInfo, currentItemSet,ItemSetStateInfo.SetState.Keep));
                            newItemSetList.RemoveAt(j);
                            break;
                        }
                    }

                    if (foundSetMatch == false) {
                        m_TemporaryItemSetStateList.Add(
                            new ItemSetStateInfo(itemSetRuleInfo, currentItemSet,ItemSetStateInfo.SetState.Remove));
                    }
                }
            }
            

            for (int i = 0; i < newItemSetList.Count; i++) {
                //New item set index set to -1 it will be updated once it is really set.
                var newItemSet = CreateItemSetCopy(itemSetRuleInfo, newItemSetList[i], -1);
                
                m_TemporaryItemSetStateList.Add(
                    new ItemSetStateInfo(itemSetRuleInfo, newItemSet,ItemSetStateInfo.SetState.Add));
            }
            
            newItemSetList.Clear();
            GenericObjectPool.Return(newItemSetList);
        }

        /// <summary>
        /// Reset the category Item set.
        /// </summary>
        /// <param name="categoryItemSet">The category item set.</param>
        protected virtual void ResetCategoryItemSet(CategoryItemSet categoryItemSet)
        {
            categoryItemSet.DefaultItemSetIndex = 0;

            for (int i = 0; i < categoryItemSet.ItemSetList.Count; i++) {
                DestroyItemSet(categoryItemSet.ItemSetList[i]);
            }
            
            categoryItemSet.ItemSetList.Clear();
        }

        /// <summary>
        /// Destroy the item set, and remove it from the mappings.
        /// </summary>
        /// <param name="itemSet">The item set to destroy.</param>
        protected void DestroyItemSet(ItemSet itemSet)
        {
            for (int i = 0; i < itemSet.Slots.Length; i++) {
                itemSet.Slots[i] = null;
            }
            for (int i = 0; i < itemSet.ItemIdentifiers.Length; i++) {
                itemSet.ItemIdentifiers[i] = null;
            }
            itemSet.State = null;
            itemSet.Enabled = false;
            itemSet.Active = false;
            itemSet.CanSwitchTo = false;
            itemSet.DisabledIndex = -1;
            
            if(m_ItemSetToRuleMap.TryGetValue(itemSet, out var rule)) {
                m_RuleToItemSetsMap[rule].Remove(itemSet);
                m_ItemSetToRuleMap.Remove(itemSet);
            }

            itemSet.OnDestroy();
            //TODO using the generic pool caused issues because the states are still registered in the state manager.
            //GenericObjectPool.Return(itemSet);
        }

        /// <summary>
        /// Create a copy of the ite set.
        /// </summary>
        /// <param name="itemSetRuleInfo">The item set rule info.</param>
        /// <param name="itemSetToCopy">The item set to copy.</param>
        /// <param name="slotIndex">index of the item set once added.</param>
        /// <returns>The new item set.</returns>
        protected ItemSet CreateItemSetCopy(ItemSetRuleInfo itemSetRuleInfo, ItemSet itemSetToCopy, int slotIndex)
        {
            var slotCount = itemSetToCopy.ItemIdentifiers.Length;
            if (SlotCount != slotCount) {
                Debug.LogError($"The slot count does not match for the Item Set {SlotCount} != {slotCount}");
            }

            //TODO using the generic pool caused issues because the states are still registered in the state manager.
            //var itemSet = GenericObjectPool.Get<ItemSet>();
            var itemSet = new ItemSet();

            if (itemSet.Slots == null || itemSet.Slots.Length != slotCount) {
                itemSet.Slots = new ItemDefinitionBase[slotCount];
            }
            if (itemSet.ItemIdentifiers == null || itemSet.ItemIdentifiers.Length != slotCount) {
                itemSet.ItemIdentifiers = new IItemIdentifier[slotCount];
            }
            
            itemSet.Active = false;
            itemSet.State = itemSetToCopy.State;
            itemSet.Enabled = itemSetToCopy.Enabled;
            itemSet.CanSwitchTo = itemSetToCopy.CanSwitchTo;
            itemSet.DisabledIndex = itemSetToCopy.DisabledIndex;
            
            //Create new state references
            var stateCount = itemSetToCopy.States.Length;
            if (itemSet.States != null && stateCount > 1) {
                itemSet.States = new State[stateCount];
                for (int i = 0; i < stateCount; i++) {
                    var originalState = itemSetToCopy.States[i];
                    if (originalState.Default) {
                        itemSet.States[i] = new State(originalState.Name, true);
                    } else {
                        itemSet.States[i] = new State(originalState.Name, originalState.Preset, originalState.BlockList);
                    }
                }
            }

            for (int i = 0; i < slotCount; i++) {
                itemSet.ItemIdentifiers[i] = itemSetToCopy.ItemIdentifiers[i];
                itemSet.Slots[i] = itemSetToCopy.Slots[i];
            }

            itemSet.Initialize(m_GameObject,this, itemSetRuleInfo.CategoryItemSetRule.ItemCategory.ID, itemSetRuleInfo.CategoryIndex, slotIndex);

            m_ItemSetToRuleMap[itemSet] = itemSetRuleInfo.ItemSetRule;
            if (m_RuleToItemSetsMap.ContainsKey(itemSetRuleInfo.ItemSetRule) == false) {
                m_RuleToItemSetsMap[itemSetRuleInfo.ItemSetRule] = new List<ItemSet>();
            }
            m_RuleToItemSetsMap[itemSetRuleInfo.ItemSetRule].Add(itemSet);
            
            return itemSet;
        }

        /// <summary>
        /// Get the item set index.
        /// </summary>
        /// <param name="category">The category index.</param>
        /// <param name="itemIdentifier">The item identifier you are looking for.</param>
        /// <param name="slotID">The slot Index where the item should be.</param>
        /// <returns>The index of the first item set which matches.</returns>
        public int GetItemSetIndexFor(int category, IItemIdentifier itemIdentifier, int slotID = -1)
        {
            var itemSetList = m_CategoryItemSets[category].ItemSetList;
            for (int i = 0; i < itemSetList.Count; i++) {
                var itemSet = itemSetList[i];

                if (slotID == -1) {
                    for (int j = 0; j < itemSet.ItemIdentifiers.Length; j++) {
                        if (itemIdentifier == itemSet.ItemIdentifiers[j]) {
                            return i;
                        }
                    }
                } else {
                    if (itemIdentifier == itemSet.ItemIdentifiers[slotID]) {
                        return i;
                    }
                }
            }

            return -1;
        }
        
        /// <summary>
        /// Get the Item slot ID.
        /// </summary>
        /// <param name="category">The category index.</param>
        /// <param name="itemIdentifier">The item.</param>
        /// <returns>The index of the slot.</returns>
        public int GetSlotIDFor(int category, IItemIdentifier itemIdentifier)
        {
            var itemSetList = m_CategoryItemSets[category].ItemSetList;
            for (int i = 0; i < itemSetList.Count; i++) {
                var itemSet = itemSetList[i];
                
                for (int j = 0; j < itemSet.ItemIdentifiers.Length; j++) {
                    if (itemIdentifier == itemSet.ItemIdentifiers[j]) {
                        return j;
                    }
                }
            }

            return -1;
        }
        
        /// <summary>
        /// Get the active slot id.
        /// </summary>
        /// <param name="category">The category index.</param>
        /// <param name="itemIdentifier">The item.</param>
        /// <returns>The index of the slot.</returns>
        public int GetActiveSlotIDFor(int category, IItemIdentifier itemIdentifier)
        {
            var activeItemSetIndex = m_ActiveItemSetIndex[category];
            if (activeItemSetIndex == -1) {
                return -1;
            }

            var activeItemSet = m_CategoryItemSets[category].ItemSetList[activeItemSetIndex];
            
            for (int i = 0; i < activeItemSet.ItemIdentifiers.Length; i++) {
                if (itemIdentifier == activeItemSet.ItemIdentifiers[i]) {
                    return i;
                }
            }

            return -1;
        }
        
        /// <summary>
        /// Is the item part of the category.
        /// </summary>
        /// <param name="categoryIndex">The category index.</param>
        /// <param name="itemIdentifier">The item.</param>
        /// <returns>True if the item exist in that category.</returns>
        public bool IsCategoryMember(int categoryIndex, IItemIdentifier itemIdentifier)
        {
            var slotID = GetSlotIDFor(categoryIndex, itemIdentifier);
            return slotID != -1;
        }

        /// <summary>
        /// Get the next or the default Item set.
        /// </summary>
        /// <param name="categoryIndex">The category index.</param>
        /// <param name="currentItemSetIndex">The current item set index.</param>
        /// <param name="allowedSlotsLayerMask">The layer mask for valid item slot IDs.</param>
        /// <returns>The item set index.</returns>
        public int GetNextOrDefaultItemSetIndex(int categoryIndex, int currentItemSetIndex, int allowedSlotsLayerMask)
        {
            var itemSetList = m_CategoryItemSets[categoryIndex].ItemSetList;
            if (itemSetList.Count == 0) {
                return -1;
            }

            var startIndex = Mathf.Clamp(currentItemSetIndex+1, 0, itemSetList.Count - 1);

            var itemSetIndex = 0;
            for (int i = startIndex; i < itemSetList.Count+startIndex; i++) {

                itemSetIndex = i;
                if (itemSetIndex >= itemSetList.Count) {
                    itemSetIndex -= itemSetList.Count;
                }

                if (IsItemSetValid(categoryIndex, itemSetIndex, true, allowedSlotsLayerMask)) {
                    return itemSetIndex;
                }
            }

            return m_CategoryItemSets[categoryIndex].DefaultItemSetIndex;
        }
        
        /// <summary>
        /// Get the item set index which does not own that item.
        /// </summary>
        /// <param name="categoryIndex">The category index.</param>
        /// <param name="currentItemSetIndex">The current item set index.</param>
        /// <param name="item">The item to avoid.</param>
        /// <returns>The item set index.</returns>
        public int GetItemSetIndexExcludingItem(int categoryIndex, int currentItemSetIndex, IItemIdentifier item)
        {
            var itemSetList = m_CategoryItemSets[categoryIndex].ItemSetList;
            if (itemSetList.Count == 0) {
                return -1;
            }

            var startIndex = Mathf.Clamp(currentItemSetIndex, 0, itemSetList.Count - 1);

            var itemSetIndex = 0;
            for (int i = startIndex; i < itemSetList.Count+startIndex; i++) {

                itemSetIndex = i;
                if (itemSetIndex >= itemSetList.Count) {
                    itemSetIndex -= itemSetList.Count;
                }

                if (IsItemSetValid(categoryIndex, itemSetIndex, true, -1)) {

                    var itemSet = itemSetList[itemSetIndex];

                    var foundMatch = false;
                    for (int j = 0; j < itemSet.ItemIdentifiers.Length; j++) {
                        if (itemSet.ItemIdentifiers[j] == item) {
                            foundMatch = true;
                            break;
                        }
                    }

                    if (foundMatch == false) {
                        return itemSetIndex;
                    }
                }
            }

            return m_CategoryItemSets[categoryIndex].DefaultItemSetIndex;
        }

        /// <summary>
        /// Get the active item set.
        /// </summary>
        /// <param name="categoryIndex">The category index.</param>
        /// <returns>The active item set.</returns>
        public ItemSet GetActiveItemSet(int categoryIndex)
        {
            var activeItemSetIndex = m_ActiveItemSetIndex[categoryIndex];

            if (activeItemSetIndex == -1) { return null;}

            return m_CategoryItemSets[categoryIndex].ItemSetList[activeItemSetIndex];
        }
        
        /// <summary>
        /// Get the next item set.
        /// </summary>
        /// <param name="categoryIndex">The category index.</param>
        /// <returns>The items set.</returns>
        public ItemSet GetNextItemSet(int categoryIndex)
        {
            var nextItemSetIndex = m_NextItemSetIndex[categoryIndex];

            if (nextItemSetIndex == -1) { return null;}

            return m_CategoryItemSets[categoryIndex].ItemSetList[nextItemSetIndex];
        }

        /// <summary>
        /// Force state changed to be called on all item sets.
        /// </summary>
        public void StateChange()
        {
            for (int i = 0; i < m_CategoryItemSets.Length; i++) {
                var itemSets = m_CategoryItemSets[i].ItemSetList;
                for (int j = 0; j < itemSets.Count; j++) {
                    itemSets[j].StateChange();
                }
            }
        }
        
        /// <summary>
        /// Get the matching category indexes.
        /// </summary>
        /// <param name="itemIdentifier">The item.</param>
        /// <returns>The first category index match.</returns>
        public int GetMatchingCategoryIndex(IItemIdentifier itemIdentifier)
        {
            for (int i = 0; i < CategoryCount; i++) {
                if (IsCategoryMember(i, itemIdentifier)) {
                    return i;
                }
            }

            return -1;
        }
    }

    public static class InventorySystemItemSetUtility
    {
        public static ListSlice<Item[]> GetAllSlotPermutations(ListSlice<ItemDefinition> itemDefinitions, ListSlice<Item> items,
            List<Item[]> result)
        {
            result.Clear();
            var slotCount = itemDefinitions.Count;

            //There must be at least one set.
            var firstSet = new Item[slotCount];
            var count = 1;
            result.Add(firstSet);

            GetAllSlotPermutations(0, itemDefinitions, items, firstSet, result, ref count);
                
            return (result, 0, count);
        }
        
        public static ListSlice<Item[]> GetAllSlotPermutations(int categoryIndex, ListSlice<ItemDefinition> itemDefinitions,
            ListSlice<Item> items, Item[] currentSet, List<Item[]> result, ref int resultCount)
        {
            for (int i = categoryIndex; i < itemDefinitions.Count; i++) {
                var itemDefinition = itemDefinitions[i];
                if (itemDefinition == null) { continue; }

                var foundMatch = false;
                for (int j = 0; j < items.Count; j++) {
                    var item = items[j];
                    
                    if (itemDefinition.InherentlyContains(item) == false) {
                        continue;
                    }

                    //The same item cannot be added twice in the same set.
                    if (currentSet.Contains(item)) {
                        continue;
                    }

                    if (!foundMatch) {
                        //First match add to current.
                        currentSet[i] = items[j];
                        foundMatch = true;
                        continue;
                    }

                    //Other match must create new set.
                    var nextCategoryIndex = i + 1;
                    var newSet = Duplicate(currentSet, nextCategoryIndex);
                    newSet[i] = items[j];
                    resultCount++;
                    result.Add(newSet);

                    GetAllSlotPermutations(nextCategoryIndex, itemDefinitions, items, newSet, result, ref resultCount);
                }

                if (foundMatch) { continue; }

                //No match was found, no need to look further.
                result.Remove(currentSet);
                resultCount--;
                break;

            }
            
            return (result, 0, resultCount);
        }

        public static ListSlice<Item[]> GetAllSlotPermutations(ListSlice<ItemCategory> itemCategories, ListSlice<Item> items,
            List<Item[]> result)
        {
            result.Clear();
            var slotCount = itemCategories.Count;

            //There must be at least one set.
            var firstSet = new Item[slotCount];
            var count = 1;
            result.Add(firstSet);

            GetAllSlotPermutations(0, itemCategories, items, firstSet, result, ref count);
                
            return (result, 0, count);
        }

        public static ListSlice<Item[]> GetAllSlotPermutations(int categoryIndex, ListSlice<ItemCategory> itemCategories,
            ListSlice<Item> items, Item[] currentSet, List<Item[]> result, ref int resultCount)
        {
            for (int i = categoryIndex; i < itemCategories.Count; i++) {
                var itemCategory = itemCategories[i];
                if (itemCategory == null) { continue; }

                var foundMatch = false;
                for (int j = 0; j < items.Count; j++) {
                    var item = items[j];
                    
                    if (itemCategory.InherentlyContains(item) == false) {
                        continue;
                    }

                    //The same item cannot be added twice in the same set.
                    if (currentSet.Contains(item)) {
                        continue;
                    }

                    if (!foundMatch) {
                        //First match add to current.
                        currentSet[i] = items[j];
                        foundMatch = true;
                        continue;
                    }

                    //Other match must create new set.
                    var nextCategoryIndex = i + 1;
                    var newSet = Duplicate(currentSet, nextCategoryIndex);
                    newSet[i] = items[j];
                    resultCount++;
                    result.Add(newSet);

                    GetAllSlotPermutations(nextCategoryIndex, itemCategories, items, newSet, result, ref resultCount);
                }

                if (foundMatch) { continue; }

                //No match was found, no need to look further.
                result.Remove(currentSet);
                resultCount--;
                break;

            }
            
            return (result, 0, resultCount);
        }

        private static Item[] Duplicate(Item[] currentSet, int copyUpTo)
        {
            var newSet = new Item[currentSet.Length];
            var count = Mathf.Min(currentSet.Length, copyUpTo);

            for (int i = 0; i < count; i++) {
                newSet[i] = currentSet[i];
            }

            return newSet;
        }
    }
}