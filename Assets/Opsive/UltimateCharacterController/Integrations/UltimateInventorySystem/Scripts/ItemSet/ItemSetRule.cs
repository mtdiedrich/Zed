/// ---------------------------------------------
/// Ultimate Character Controller
/// Copyright (c) Opsive. All Rights Reserved.
/// https://www.opsive.com
/// ---------------------------------------------

namespace Opsive.UltimateCharacterController.Integrations.UltimateInventorySystem
{
    using Opsive.Shared.Inventory;
    using Opsive.Shared.StateSystem;
    using Opsive.Shared.Utility;
    using Opsive.UltimateCharacterController.Inventory;
    using Opsive.UltimateInventorySystem.Core;
    using Opsive.UltimateInventorySystem.Storage;
    using System;
    using UnityEngine;
    using UnityEngine.UIElements;

    /// <summary>
    /// The item set rule interface.
    /// </summary>
    public interface IItemSetRule
    {
        bool Default { get; }

        ListSlice<ItemSet> GetItemSetsFor(ListSlice<Item> items);
        void SetSlotCount(int slotCount);
        bool DoesItemMatchRule(Item item);
        bool IsComponentValidForDatabase(InventorySystemDatabase database);

        ModifiedObjectWithDatabaseObjects
            ReplaceInventoryObjectsBySelectedDatabaseEquivalents(InventorySystemDatabase database);
    }
    
    /// <summary>
    /// The item set rule.
    /// </summary>
    [Serializable]
    public abstract class ItemSetRule : IItemSetRule
    {
        [Tooltip("A list of all states that the component can change to.")]
        [HideInInspector] [SerializeField] protected State[] m_States = new State[] { new State("Default", true) };
        [Tooltip("The state to change to when the ItemSet is active.")]
        [SerializeField] protected string m_State;
        [Tooltip("Is the ItemSet the default ItemSet?")]
        [SerializeField] protected bool m_Default = false;
        [Tooltip("Is the ItemSet enabled?")]
        [SerializeField] protected bool m_Enabled = true;
        [Tooltip("Can the ItemSet be switched to by the EquipNext/EquipPrevious abilities?")]
        [SerializeField] protected bool m_CanSwitchTo = true;
        [Tooltip("The ItemSet index that should be activated when the current ItemSet is active and disabled.")]
        [SerializeField] protected int m_DisabledIndex = -1;

        protected ResizableArray<ItemSet> m_TemporaryItemSets;
        
        [Opsive.Shared.Utility.NonSerialized] public State[] States { get { return m_States; } set { m_States = value; } }
        [Shared.Utility.NonSerialized] public string State { get { return m_State; } set { m_State = value; } }
        public bool Default { get { return m_Default; } set { m_Default = value; } }
        public bool Enabled { get { return m_Enabled; } set { m_Enabled = value; } }
        public bool CanSwitchTo { get { return m_CanSwitchTo; } set { m_CanSwitchTo = value; } }
        public int DisabledIndex { get { return m_DisabledIndex; } set { m_DisabledIndex = value; } }
        
        public abstract ListSlice<ItemSet> GetItemSetsFor(ListSlice<Item> items);
        public abstract void SetSlotCount(int slotCount);
        public abstract bool DoesItemMatchRule(Item item);
        public abstract bool IsComponentValidForDatabase(InventorySystemDatabase database);

        public abstract ModifiedObjectWithDatabaseObjects
            ReplaceInventoryObjectsBySelectedDatabaseEquivalents(InventorySystemDatabase database);

        /// <summary>
        /// Get the item sets for for the list of item permutations.
        /// </summary>
        /// <param name="slotCount">The slot count.</param>
        /// <param name="itemPermutations">The item permutations.</param>
        /// <returns>The list of item sets.</returns>
        public virtual ListSlice<ItemSet> GetItemSetsFor(int slotCount, ListSlice<Item[]> itemPermutations)
        {
            if (m_TemporaryItemSets == null) { m_TemporaryItemSets = new ResizableArray<ItemSet>(); }

            for (int i = 0; i < itemPermutations.Count; i++) {
                if (m_TemporaryItemSets.Count <= i) { m_TemporaryItemSets.Add(CreateItemSet(slotCount)); }

                AssignItemsToItemSet(slotCount, m_TemporaryItemSets[i], itemPermutations[i]);
            }
            
            return (m_TemporaryItemSets, 0, itemPermutations.Count);
        }
        
        /// <summary>
        /// Create an item set.
        /// </summary>
        /// <param name="slotCount">The slot count.</param>
        /// <returns>The item set.</returns>
        protected virtual ItemSet CreateItemSet(int slotCount)
        {
            var itemSet = new ItemSet();

            if (itemSet.Slots == null || itemSet.Slots.Length != slotCount) {
                itemSet.Slots = new ItemDefinitionBase[slotCount];
            }
            if (itemSet.ItemIdentifiers == null || itemSet.ItemIdentifiers.Length != slotCount) {
                itemSet.ItemIdentifiers = new IItemIdentifier[slotCount];
            }
            
            itemSet.Active = false;
            itemSet.State = State;
            itemSet.Enabled = Enabled;
            itemSet.CanSwitchTo = CanSwitchTo;
            itemSet.DisabledIndex = DisabledIndex;
            
            //Create new state references
            var stateCount = States.Length;
            if (itemSet.States != null && stateCount > 1) {
                itemSet.States = new State[stateCount];
                for (int i = 0; i < stateCount; i++) {
                    var originalState = States[i];
                    if (originalState.Default) {
                        itemSet.States[i] = new State(originalState.Name, true);
                    } else {
                        itemSet.States[i] = new State(originalState.Name, originalState.Preset, originalState.BlockList);
                    }
                }
            }

            return itemSet;
        }
        
        /// <summary>
        /// Assign items to the item set.
        /// </summary>
        /// <param name="slotCount">The slot count.</param>
        /// <param name="itemSet">The item set.</param>
        /// <param name="itemsInSet">The items in the set.</param>
        protected virtual void AssignItemsToItemSet(int slotCount, ItemSet itemSet, ListSlice<Item> itemsInSet)
        {
            if (slotCount != itemsInSet.Count) {
                Debug.LogError("The Inventory System Item Set Data Slot Count must match the array size of items in a set.");
            }

            for (int i = 0; i < slotCount; i++) {
                itemSet.Slots[i] = itemsInSet[i]?.ItemDefinition;
                itemSet.ItemIdentifiers[i] = itemsInSet[i];
            }
        }
    }
    
    /// <summary>
    /// An item set rule that contains an item set rule object.
    /// </summary>
    [Serializable]
    public class ItemSetRuleObjectContainer : IItemSetRule
    {
        [SerializeField] protected ItemSetRuleObject m_ItemSetRuleObject;

        public ItemSetRuleObject ItemSetRuleObject
        {
            get => m_ItemSetRuleObject;
            set => m_ItemSetRuleObject = value;
        }

        public bool Default
        {
            get
            {
                if (m_ItemSetRuleObject == null) { return false; }
                
                return m_ItemSetRuleObject.Default;
            }
        }

        public ListSlice<ItemSet> GetItemSetsFor(ListSlice<Item> items)
        {
            if (m_ItemSetRuleObject == null) { return (null, 0, 0); }
            
            return m_ItemSetRuleObject.GetItemSetsFor(items);
        }

        public void SetSlotCount(int slotCount)
        {
            if (m_ItemSetRuleObject == null) { return; }
            
            m_ItemSetRuleObject.SetSlotCount(slotCount);
        }

        public bool DoesItemMatchRule(Item item)
        {
            if (m_ItemSetRuleObject == null) { return false; }
            
            return m_ItemSetRuleObject.DoesItemMatchRule(item);
        }

        public bool IsComponentValidForDatabase(InventorySystemDatabase database)
        {
            if (m_ItemSetRuleObject == null) { return true; }
            
            return m_ItemSetRuleObject.IsComponentValidForDatabase(database);
        }

        public ModifiedObjectWithDatabaseObjects
            ReplaceInventoryObjectsBySelectedDatabaseEquivalents(InventorySystemDatabase database)
        {
            if (m_ItemSetRuleObject == null) { return null; }
            
            return m_ItemSetRuleObject.ReplaceInventoryObjectsBySelectedDatabaseEquivalents(database);
        }
    }
    
    /// <summary>
    /// The item set rule object, override this to create custom item set rules.
    /// </summary>
    public abstract class ItemSetRuleObject : ScriptableObject, IItemSetRule
    {
        /// <summary>
        /// Is the item set the default one.
        /// </summary>
        public virtual bool Default
        {
            get { return false; }
            // ReSharper disable once ValueParameterNotUsed
            set { }
        }

        /// <summary>
        /// Get the item sets for the list of equippable items.
        /// </summary>
        /// <param name="items">The items.</param>
        /// <returns>The list of item sets.</returns>
        public abstract ListSlice<ItemSet> GetItemSetsFor(ListSlice<Item> items);
        
        /// <summary>
        /// Set the number of slots for each item set.
        /// </summary>
        /// <param name="slotCount">The slot count.</param>
        public abstract void SetSlotCount(int slotCount);
        
        /// <summary>
        /// Does the item match the item set rule?
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>True if the rule could contain the item.</returns>
        public abstract bool DoesItemMatchRule(Item item);

        /// <summary>
        /// Check fo valid inventory objects.
        /// </summary>
        /// <param name="database">The database to check against.</param>
        /// <returns>True if valid.</returns>
        public virtual bool IsComponentValidForDatabase(InventorySystemDatabase database)
        {
            return true;
        }

        /// <summary>
        /// replace the inventory objects by valid one.
        /// </summary>
        /// <param name="database">The database to check against.</param>
        /// <returns>objects to dirty.</returns>
        public virtual ModifiedObjectWithDatabaseObjects
            ReplaceInventoryObjectsBySelectedDatabaseEquivalents(InventorySystemDatabase database)
        {
            return null;
        }
    }
}