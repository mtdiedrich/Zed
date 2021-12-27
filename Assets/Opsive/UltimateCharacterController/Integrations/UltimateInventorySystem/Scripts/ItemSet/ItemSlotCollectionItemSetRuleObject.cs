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
    using Opsive.UltimateInventorySystem.Core.InventoryCollections;
    using UnityEngine;

    /// <summary>
    /// An Item Set Rule used to match the ItemSet with the 
    /// </summary>
    [CreateAssetMenu(menuName = "Opsive/Inventory/Item Slot Collection Item Set Rule Object", fileName = "MyItemSlotCollectionItemSetRuleObject", order = 0)]
    public class ItemSlotCollectionItemSetRuleObject : ItemSetRuleObject
    {
        [SerializeField] protected string m_ItemSlotCollectionName = "EquippableSlots";
        
        [Tooltip("A list of all states that the component can change to.")]
        [HideInInspector] [SerializeField] protected State[] m_States = new State[] { new State("Default", true) };
        [Tooltip("The state to change to when the ItemSet is active.")]
        [SerializeField] protected string m_State;
        [Tooltip("Is the ItemSet the default ItemSet?")]
        [SerializeField] protected bool m_Default = false;
        [Tooltip("Is the ItemSet enabled?")]
        [SerializeField] protected bool m_IsEnabled = true;
        [Tooltip("Can the ItemSet be switched to by the EquipNext/EquipPrevious abilities?")]
        [SerializeField] protected bool m_CanSwitchTo = true;
        [Tooltip("The ItemSet index that should be activated when the current ItemSet is active and disabled.")]
        [SerializeField] protected int m_DisabledIndex = -1;

        protected ResizableArray<ItemSet> m_TemporaryItemSets;
        protected int m_SlotCount = 0;
        
        [Opsive.Shared.Utility.NonSerialized] public State[] States { get { return m_States; } set { m_States = value; } }
        [Shared.Utility.NonSerialized] public string State { get { return m_State; } set { m_State = value; } }
        public override bool Default { get { return m_Default; } set { m_Default = value; } }
        public bool IsEnabled { get { return m_IsEnabled; } set { m_IsEnabled = value; } }
        public bool CanSwitchTo { get { return m_CanSwitchTo; } set { m_CanSwitchTo = value; } }
        public int DisabledIndex { get { return m_DisabledIndex; } set { m_DisabledIndex = value; } }

        /// <summary>
        /// Get the item sets for the list of equippable items.
        /// </summary>
        /// <param name="items">The items.</param>
        /// <returns>The list of item sets.</returns>
        public override ListSlice<ItemSet> GetItemSetsFor(ListSlice<Item> items)
        {
            if (m_TemporaryItemSets == null) {
                m_TemporaryItemSets = new ResizableArray<ItemSet>(1);
            }
            
            m_TemporaryItemSets.Clear();
            var itemSet = CreateItemSet(m_SlotCount);
            m_TemporaryItemSets.Add(itemSet);
            
            if (items.Count == 0) {
                return m_TemporaryItemSets;
            }

            Item itemInCollection = null;
            for (int i = 0; i < items.Count; i++) {
                var item = items[i];
                if (DoesItemMatchRule(item) == false) {
                    continue;
                }

                itemInCollection = item;
                break;
            }

            if (itemInCollection == null) {
                return m_TemporaryItemSets;
            }

            var itemSlotCollection = itemInCollection.ItemCollection as ItemSlotCollection;
            if (itemSlotCollection == null) {
                return m_TemporaryItemSets;
            }

            for (int i = 0; i < itemSlotCollection.SlotCount; i++) {
                var itemInfoInSlot = itemSlotCollection.GetItemInfoAtSlot(i);

                if (i >= m_SlotCount) {
                    break;
                }
                
                itemSet.ItemIdentifiers[i] = itemInfoInSlot.Item;
            }

            return m_TemporaryItemSets;
        }

        /// <summary>
        /// Set the number of slots for each item set.
        /// </summary>
        /// <param name="slotCount">The slot count.</param>
        public override void SetSlotCount(int slotCount)
        {
            m_SlotCount = slotCount;
        }
        
        /// <summary>
        /// Does the item match the item set rule?
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>True if the rule could contain the item.</returns>
        public override bool DoesItemMatchRule(Item item)
        {
            if (item.ItemCollection == null) {
                return false;
            }

            return item.ItemCollection.Name == m_ItemSlotCollectionName;
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
            itemSet.Enabled = IsEnabled;
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
    }
}