/// ---------------------------------------------
/// Ultimate Character Controller
/// Copyright (c) Opsive. All Rights Reserved.
/// https://www.opsive.com
/// ---------------------------------------------

namespace Opsive.UltimateCharacterController.Integrations.UltimateInventorySystem
{
    using Opsive.Shared.Game;
    using Opsive.UltimateCharacterController.Inventory;
    using Opsive.UltimateCharacterController.Objects.CharacterAssist;
    using Opsive.UltimateInventorySystem.Core;
    using Opsive.UltimateInventorySystem.Core.DataStructures;
    using Opsive.UltimateInventorySystem.Storage;
    using UnityEngine;

    using Inventory = Opsive.UltimateInventorySystem.Core.InventoryCollections.Inventory;
    using ItemDefinitionAmount = Opsive.UltimateCharacterController.Inventory.ItemDefinitionAmount;

    /// <summary>
    /// Allows an object with an Ultimate Inventory System inventory to pickup items when a character enters the trigger.
    /// </summary>
    public class InventoryItemPickup : ItemPickupBase, IDatabaseSwitcher
    {
        [Tooltip("Equip the item that was picked up?")]
        [SerializeField] protected bool m_EquipOnPickup;
        [Tooltip("Copy the items before they are picked up?")]
        [SerializeField] protected bool m_PickupItemCopies;
        [Tooltip("Remove the items that were picked up from the inventory?")]
        [SerializeField] protected bool m_RemoveItemsOnPickup;

        protected Inventory m_Inventory;
        protected ItemDefinitionAmount[] m_ItemDefinitionAmounts;

        /// <summary>
        /// Initialize the default values.
        /// </summary>
        protected override void Awake()
        {
            base.Awake();

            m_Inventory = gameObject.GetCachedComponent<Inventory>();

            // Convert from ItemAmounts to ItemIdentifierAmounts.
            var pickupItems = m_Inventory.MainItemCollection.GetAllItemStacks();
            m_ItemDefinitionAmounts = new ItemDefinitionAmount[pickupItems.Count];
            for (int i = 0; i < pickupItems.Count; ++i) {
                m_ItemDefinitionAmounts[i] = new ItemDefinitionAmount(pickupItems[i].Item.ItemDefinition, pickupItems[i].Amount);
            }
        }

        /// <summary>
        /// Returns the ItemDefinitionAmount that the ItemPickup contains.
        /// </summary>
        /// <returns>The ItemDefinitionAmount that the ItemPickup contains.</returns>
        public override ItemDefinitionAmount[] GetItemDefinitionAmounts()
        {
            return m_ItemDefinitionAmounts;
        }

        /// <summary>
        /// Sets the ItemPickup ItemDefinitionAmount value.
        /// </summary>
        /// <param name="itemDefinitionAmounts">The ItemDefinitionAmount that should be set.</param>
        public override void SetItemDefinitionAmounts(ItemDefinitionAmount[] itemDefinitionAmounts)
        {
            m_ItemDefinitionAmounts = itemDefinitionAmounts;
            m_Inventory.MainItemCollection.RemoveAll();
            for (int i = 0; i < m_ItemDefinitionAmounts.Length; ++i) {
                if (!(m_ItemDefinitionAmounts[i].ItemDefinition is ItemDefinition)) {
                    Debug.LogWarning($"Warning: Unable to drop {m_ItemDefinitionAmounts[i].ItemDefinition} because it isn't an Ultimate Inventory System Item Definition.");
                    continue;
                }
                m_Inventory.MainItemCollection.AddItem(InventorySystemManager.CreateItem(m_ItemDefinitionAmounts[i].ItemDefinition as ItemDefinition, null), m_ItemDefinitionAmounts[i].Amount);
            }
        }

        /// <summary>
        /// Internal method which picks up the ItemIdentifier.
        /// </summary>
        /// <param name="character">The character that should pick up the ItemIdentifier.</param>
        /// <param name="inventory">The inventory belonging to the character.</param>
        /// <param name="slotID">The slot ID that picked up the item. A -1 value will indicate no specified slot.</param>
        /// <param name="immediatePickup">Should the item be picked up immediately?</param>
        /// <param name="forceEquip">Should the item be force equipped?</param>
        /// <returns>True if an ItemIdentifier was picked up.</returns>
        protected override bool DoItemIdentifierPickupInternal(GameObject character, InventoryBase inventory, int slotID, bool immediatePickup, bool forceEquip)
        {
            var pickupItems = m_Inventory.AllItemInfos;
            if (pickupItems.Count == 0) { return false;}
            
            var bridgeInventory = character.GetCachedComponent<CharacterInventoryBridge>();
            var inventorySystemInventory = character.GetCachedComponent<Inventory>();
            for (int i = pickupItems.Count - 1; i >= 0; --i) {
                var itemInfo = pickupItems[i];

                if (m_RemoveItemsOnPickup) {
                    itemInfo = m_Inventory.RemoveItem(itemInfo);
                }
                
                if (m_PickupItemCopies) {
                    itemInfo = new ItemInfo((InventorySystemManager.CreateItem(itemInfo.Item), itemInfo.Amount), itemInfo.ItemCollection);
                } else if(!m_RemoveItemsOnPickup){
                    //Remove the item and replace it by a copy.
                    itemInfo = m_Inventory.RemoveItem(itemInfo);
                    m_Inventory.AddItem((ItemInfo) (InventorySystemManager.CreateItem(itemInfo.Item), itemInfo.Amount));
                }
                
                itemInfo = inventorySystemInventory.AddItem(itemInfo);
                if (m_EquipOnPickup && bridgeInventory.EquippableCategory.InherentlyContains(itemInfo.Item)) {
                    bridgeInventory.MoveEquip(itemInfo,true);
                }
            }
            return true;
        }

        /// <summary>
        /// Check if the object contained by this component are part of the database.
        /// </summary>
        /// <param name="database">The database.</param>
        /// <returns>True if all the objects in the component are part of that database.</returns>
        bool IDatabaseSwitcher.IsComponentValidForDatabase(InventorySystemDatabase database)
        {
            if (database == null) { return false; }
            if (m_ItemPickupSet == null) { return true; }

            database.Initialize(false);

            for (int i = 0; i < m_ItemPickupSet.Length; i++) {
                if (m_ItemPickupSet[i] == null) { continue; }

                var itemSet = m_ItemPickupSet[i].ItemSet;

                if (itemSet == null) { continue; }

                if (itemSet.Slots != null) {
                    for (int j = 0; j < itemSet.Slots.Length; j++) {
                        var itemDefinition = itemSet.Slots[j] as ItemDefinition;
                        if (itemDefinition == null || database.Contains(itemDefinition)) { continue; }

                        return false;
                    }
                }

                if (itemSet.ItemIdentifiers == null) { continue; }

                for (int j = 0; j < itemSet.ItemIdentifiers.Length; j++) {
                    var item = itemSet.ItemIdentifiers[j] as Item;
                    if (item == null || database.Contains(item)) { continue; }
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Replace any object that is not in the database by an equivalent object in the specified database.
        /// </summary>
        /// <param name="database">The database.</param>
        /// <returns>The objects that have been changed.</returns>
        ModifiedObjectWithDatabaseObjects IDatabaseSwitcher.ReplaceInventoryObjectsBySelectedDatabaseEquivalents(InventorySystemDatabase database)
        {
            if (database == null) { return null; }
            if (m_ItemPickupSet == null) { return null; }

            database.Initialize(false);

            for (int i = 0; i < m_ItemPickupSet.Length; i++) {
                if (m_ItemPickupSet[i] == null) { continue; }

                var itemSet = m_ItemPickupSet[i].ItemSet;

                if (itemSet == null) { continue; }

                if (itemSet.Slots != null) {
                    for (int j = 0; j < itemSet.Slots.Length; j++) {
                        var itemDefinition = itemSet.Slots[j] as ItemDefinition;
                        if (itemDefinition == null || database.Contains(itemDefinition)) { continue; }

                        itemSet.Slots[j] = database.FindSimilar(itemDefinition);
                    }
                }

                if (itemSet.ItemIdentifiers == null) { continue; }

                for (int j = 0; j < itemSet.ItemIdentifiers.Length; j++) {
                    var item = itemSet.ItemIdentifiers[j] as Item;
                    if (item == null || database.Contains(item)) { continue; }

                    itemSet.ItemIdentifiers[j] = database.FindSimilar(item);
                }
            }
            return null;
        }
    }
}