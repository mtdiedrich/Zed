/// ---------------------------------------------
/// Ultimate Character Controller
/// Copyright (c) Opsive. All Rights Reserved.
/// https://www.opsive.com
/// ---------------------------------------------

namespace Opsive.UltimateCharacterController.Integrations.UltimateInventorySystem
{
    using Opsive.Shared.Inventory;
    using Opsive.UltimateCharacterController.Inventory;
    using UnityEngine;

    /// <summary>
    /// Active and Next Item Set Data, is a class which stores the current state active and next item set of the Item Set Manager.
    /// </summary>
    public class ActiveAndNextItemSetData
    {
        /// <summary>
        /// Item Set Data.
        /// </summary>
        public class ItemSetData
        {
            private IItemIdentifier[] m_Items;
            private IItemSetRule m_ItemSetRule;
            private int m_Index;

            public IItemSetRule ItemSetRule
            {
                get { return m_ItemSetRule; }
                set { m_ItemSetRule = value; }
            }

            public IItemIdentifier[] Items => m_Items;
            public int Index { get=> m_Index; set=> m_Index = value; }

            /// <summary>
            /// Constructor.
            /// </summary>
            /// <param name="size">The size.</param>
            public ItemSetData(int size)
            {
                m_Items = new IItemIdentifier[size];
            }

            /// <summary>
            /// Reset the value.
            /// </summary>
            public void Reset()
            {
                m_ItemSetRule = null;
                for (int i = 0; i < m_Items.Length; i++) {
                    m_Items[i] = null;
                }

                m_Index = -1;
            }

            /// <summary>
            /// Does the item set match the rule.
            /// </summary>
            /// <param name="itemSet">The item set.</param>
            /// <param name="rule">The rule.</param>
            /// <returns>True if they match.</returns>
            public bool MatchItemSetAndRule(ItemSet itemSet, IItemSetRule rule)
            {
                if (rule != ItemSetRule) { return false; }

                return MatchItemSet(itemSet);
            }

            /// <summary>
            /// Does the item set match with this Item Set data.
            /// </summary>
            /// <param name="itemSet">The item set.</param>
            /// <returns>True if they match.</returns>
            public bool MatchItemSet(ItemSet itemSet)
            {
                var foundMatch = true;
                for (int j = 0; j < itemSet.ItemIdentifiers.Length; j++) {
                    var item = itemSet.ItemIdentifiers[j];
                    if (item == Items[j]) { continue; }

                    foundMatch = false;
                    break;
                }

                return foundMatch;
            }
        }
        
        /// <summary>
        /// Item Sets Data.
        /// </summary>
        public class ItemSetsData
        {
            protected int m_CategoryCount;
            protected int m_SlotCount;
            protected ItemSetData[] m_Data;

            public ItemSetData[] Data => m_Data;
            
            /// <summary>
            /// Constructor.
            /// </summary>
            /// <param name="categoryCount">The category count.</param>
            /// <param name="slotCount">The slot count.</param>
            public ItemSetsData(int categoryCount, int slotCount)
            {
                m_CategoryCount = categoryCount;
                m_SlotCount = slotCount;
                m_Data = new ItemSetData[categoryCount];

                for (int i = 0; i < categoryCount; i++) {
                    m_Data[i] = new ItemSetData(slotCount);
                }
            }
            
            /// <summary>
            /// Record the item sets.
            /// </summary>
            /// <param name="categoryIndex">The category index.</param>
            /// <param name="itemSet">The item set.</param>
            /// <param name="itemSetIndex">The item set index.</param>
            /// <param name="rule">The item set rule.</param>
            /// <param name="additive">Add the record or overwrite it.</param>
            public void RecordSets(int categoryIndex, ItemSet itemSet, int itemSetIndex, IItemSetRule rule, bool additive)
            {
                if (additive && m_Data[categoryIndex].Index != -1) { return; }

                m_Data[categoryIndex].Index = itemSetIndex;

                if (itemSet == null) {
                    m_Data[categoryIndex].ItemSetRule = null;
                } else {
                    m_Data[categoryIndex].ItemSetRule = rule;
                    for (int j = 0; j < itemSet.ItemIdentifiers.Length; j++) {
                        var activeItem = itemSet?.ItemIdentifiers[j];
                        if (additive && activeItem == null) { continue; }

                        m_Data[categoryIndex].Items[j] = activeItem;
                    }
                }
            }

            /// <summary>
            /// Get the match index.
            /// </summary>
            /// <param name="categoryIndex">The category Index.</param>
            /// <param name="data">The item set data.</param>
            /// <param name="itemSetManager">The item set manager.</param>
            /// <returns>The index.</returns>
            public int GetMatchIndex(int categoryIndex, ItemSetData data, InventoryItemSetManager itemSetManager)
            {
                if (data.Index == -1) { return -1; }
        
                var itemSetList = itemSetManager.CategoryItemSets[categoryIndex].ItemSetList;
                for (int i = 0; i < itemSetList.Count; i++) {
                    var itemSet = itemSetList[i];
                    if(itemSetManager.GetRuleFor(itemSet) != data.ItemSetRule){continue;}

                    var foundMatch = true;
                    for (int j = 0; j < itemSet.ItemIdentifiers.Length; j++) {
                        var item = itemSet.ItemIdentifiers[j];
                        if (item != data.Items[j]) {
                            foundMatch = false;
                            break;
                        }
                    }

                    if (foundMatch) {
                        return i;
                    }
                }

                return -1;
            }
        }
        
        protected int m_CategoryCount;
        protected int m_SlotCount;
        protected ItemSetsData m_Active;
        protected ItemSetsData m_Next;

        public int CategoryCount => m_CategoryCount;
        public int SlotCount => m_SlotCount;
        public ItemSetsData Active => m_Active;
        public ItemSetsData Next => m_Next;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="categoryCount">The category count.</param>
        /// <param name="slotCount">The item set slot count.</param>
        public ActiveAndNextItemSetData(int categoryCount, int slotCount)
        {
            m_CategoryCount = categoryCount;
            m_SlotCount = slotCount;
            m_Active = new ItemSetsData(categoryCount,slotCount);
            m_Next = new ItemSetsData(categoryCount,slotCount);
        }
        
        /// <summary>
        /// Record teh item set data.
        /// </summary>
        /// <param name="itemSetManager">The item set manager.</param>
        /// <param name="additive">Add the data or overwrite it.</param>
        public void RecordSets(InventoryItemSetManager itemSetManager, bool additive)
        {
            for (int categoryIndex = 0; categoryIndex < m_CategoryCount; categoryIndex++) {
                //Active Sets
                var activeItemSet = itemSetManager.GetActiveItemSet(categoryIndex);
                m_Active.RecordSets(
                    categoryIndex, 
                    activeItemSet,
                    itemSetManager.ActiveItemSetIndex[categoryIndex],
                    itemSetManager.GetRuleFor(activeItemSet),
                    additive);
                
                var nextItemSet = itemSetManager.GetNextItemSet(categoryIndex);
                m_Next.RecordSets(
                    categoryIndex,
                    nextItemSet,
                    itemSetManager.NextItemSetIndex[categoryIndex],
                    itemSetManager.GetRuleFor(nextItemSet),
                    additive);
            }
        }

        /// <summary>
        /// Reset the recorded data.
        /// </summary>
        public void Reset()
        {
            if (Active?.Data == null) {
                return;
            }

            var count = m_CategoryCount;
            
            if (Active.Data.Length != m_CategoryCount) {
                Debug.LogWarning($"The data array length '{Active.Data.Length}' is not the same size as the category count '{m_CategoryCount}'");
                count = Active.Data.Length;
            }
                
            for (int i = 0; i < count; i++) {
                Active.Data[i]?.Reset();
                Next.Data[i]?.Reset();
            }
        }
    }
}