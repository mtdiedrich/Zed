/// ---------------------------------------------
/// Ultimate Character Controller
/// Copyright (c) Opsive. All Rights Reserved.
/// https://www.opsive.com
/// ---------------------------------------------

//#define DEBUG_BRIDGE

namespace Opsive.UltimateCharacterController.Integrations.UltimateInventorySystem
{
    using Opsive.Shared.Game;
    using Opsive.Shared.Inventory;
    using Opsive.Shared.Utility;
    using Opsive.UltimateCharacterController.Character.Abilities.Items;
    using Opsive.UltimateCharacterController.Inventory;
    using Opsive.UltimateInventorySystem.Core;
    using Opsive.UltimateInventorySystem.Core.AttributeSystem;
    using Opsive.UltimateInventorySystem.Core.DataStructures;
    using Opsive.UltimateInventorySystem.Core.InventoryCollections;
    using Opsive.UltimateInventorySystem.Storage;
    using System;
    using System.Collections.Generic;
    using UnityEngine;

    using EventHandler = Opsive.Shared.Events.EventHandler;
    using Inventory = Opsive.UltimateInventorySystem.Core.InventoryCollections.Inventory;
    using Item = Items.Item;
    using ItemCollection = Opsive.UltimateInventorySystem.Core.InventoryCollections.ItemCollection;

    /// <summary>
    /// Provides an integration between the Ultimate Character Controller and Ultimate Inventory System.
    /// </summary>
    public class CharacterInventoryBridge : InventoryBase, IDatabaseSwitcher
    {
        [Tooltip("The ItemCategory that items that can be equipped are placed in.")]
        [SerializeField] protected ItemCategory m_EquippableCategory;
        [Tooltip("The ItemCategory that ammo (character item consumable) items are placed in.")]
        [SerializeField] protected ItemCategory m_AmmoCategory;
        [Tooltip("The name of the attribute containing the item prefab for single item.")]
        [SerializeField] protected string m_SingleItemPrefabAttributeName = "Prefab";
        [Tooltip("The name of attribute containing the item prefabs for multi items.")]
        [SerializeField] protected string m_MultiItemPrefabsAttributeName = "Prefabs";
        [Tooltip("Should the Equippable Item Collections allow items that do not inherit the Equippable Item Category?")]
        [SerializeField] protected bool m_AllowNonEquippableItemsInEquippableCollections = false;
        [Tooltip("The name of the ItemCollection that contains the items that are not equippable.")]
        [SerializeField] protected string m_DefaultItemCollectionName = "Default";
        [Tooltip("The name of the ItemCollection that contains the items that are not equippable.")]
        [SerializeField] protected string[] m_AmmoItemCollectionNames = new []{"Default"};
        [Tooltip("The name of the ItemCollection that contains the items that are equipped.")]
        [SerializeField] protected string[] m_EquippableItemCollectionNames = new []{"Equippable Slots", "Equippable"};
        [Tooltip("The name of the ItemCollection that specifies the items that should be loaded when the character spawns.")]
        [SerializeField] protected string[] m_LoadoutItemCollectionNames =  new []{ "Loadout" };
        [Tooltip("Specifies the prefab that should be used when an item is dropped, requires a Inventory Item Pickup and cannot have children.")]
        [SerializeField] protected bool m_DropUsingCharacterItemWhenPossible;
        [Tooltip("Specifies the prefab that should be used when an item is dropped, requires a Inventory Item Pickup and cannot have children.")]
        [SerializeField] protected GameObject m_InventoryItemPickupPrefab;
        [Tooltip("Specifies the offset compared to the character position as to where the drop item will spawn.")]
        [SerializeField] protected Vector3 m_ItemDropPositionOffset;
        
        private ItemCollection m_DefaultItemCollection;
        private ItemCollectionGroup  m_AmmoItemCollections;
        private ItemCollectionGroup m_EquippableItemCollections;
        private ItemCollectionGroup m_LoadoutItemCollections;

        private Transform m_Transform;
        private Inventory m_Inventory;
#if UNITY_EDITOR
        private InventorySystemManager m_InventorySystemManager;
#endif
        private Character.UltimateCharacterLocomotion m_CharacterLocomotion;
        private InventoryItemSetManager m_ItemSetManager;
        private EquipUnequip[] m_EquipUnequipAbilities;
        private BridgeEquippableProcessing m_BridgeEquippableProcessing;
        private BridgeDropProcessing m_BridgeDropProcessing;
        private Opsive.UltimateInventorySystem.Core.Item[] m_ActiveItem;

        public bool AllowNonEquippableItemsInEquippableCollections => m_AllowNonEquippableItemsInEquippableCollections;
        
        public ItemCollection DefaultItemCollection => m_DefaultItemCollection;
        public ItemCollectionGroup  AmmoItemCollections => m_AmmoItemCollections;
        public ItemCollectionGroup EquippableItemCollections => m_EquippableItemCollections;
        public ItemCollectionGroup LoadoutItemCollections => m_LoadoutItemCollections;
        public InventoryItemSetManager ItemSetManager => m_ItemSetManager;

        public string SingleItemPrefabAttributeName => m_SingleItemPrefabAttributeName;
        public string MultiItemPrefabsAttributeName => m_MultiItemPrefabsAttributeName;

        public ItemCategory EquippableCategory => m_EquippableCategory;
        public ItemCategory AmmoCategory => m_AmmoCategory;

        public Inventory Inventory => m_Inventory;
        public Character.UltimateCharacterLocomotion CharacterLocomotion => m_CharacterLocomotion;

        public bool DropUsingCharacterItemWhenPossible { get => m_DropUsingCharacterItemWhenPossible; set => m_DropUsingCharacterItemWhenPossible = value; }
        public Vector3 ItemDropPositionOffset { get => m_ItemDropPositionOffset; set => m_ItemDropPositionOffset = value; }
        public GameObject InventoryItemPickupPrefab { get => m_InventoryItemPickupPrefab; set => m_InventoryItemPickupPrefab = value; }
        public BridgeEquippableProcessing BridgeEquippableProcessing { get => m_BridgeEquippableProcessing; set => m_BridgeEquippableProcessing = value; }
        public BridgeDropProcessing BridgeDropProcessing { get => m_BridgeDropProcessing; set => m_BridgeDropProcessing = value; }
        
        /// <summary>
        /// Initialize the default values.
        /// </summary>
        protected override void Awake()
        {
            base.Awake();

            m_Transform = transform;
            m_Inventory = m_GameObject.GetCachedComponent<Opsive.UltimateInventorySystem.Core.InventoryCollections.Inventory>();
#if UNITY_EDITOR
            m_InventorySystemManager = FindObjectOfType<InventorySystemManager>();
#endif
            m_CharacterLocomotion = m_GameObject.GetCachedComponent<Character.UltimateCharacterLocomotion>();
            m_ItemSetManager = m_GameObject.GetCachedComponent<InventoryItemSetManager>();

            if (m_ItemSetManager.ItemSetRulesObject == null) {
                Debug.LogError("The Item Set Manager is missing an Inventory Item Set Data object.");
            }
            
            if (m_SlotCount != m_ItemSetManager.ItemSetRulesObject.SlotCount) {
                Debug.LogError($"The Inventory Slot Count ({m_SlotCount}) and the Item Set Rule Object slot count ({m_ItemSetManager.ItemSetRulesObject.SlotCount}) must match!");
            }

            m_ActiveItem = new Opsive.UltimateInventorySystem.Core.Item[m_SlotCount];

            if (m_EquippableCategory == null) {
                Debug.LogError("Error: An equippable category must be specified.");
            }
            if (m_AmmoCategory == null) {
                Debug.LogError("Error: A ammo category must be specified.");
            }

            m_DefaultItemCollection = GetItemCollection(m_DefaultItemCollectionName, true);
            
            m_AmmoItemCollections = new ItemCollectionGroup { ItemCollections = new List<ItemCollection>() };
            for (var i = 0; i < m_AmmoItemCollectionNames.Length; i++) {
                var ammoCollection = GetItemCollection(m_AmmoItemCollectionNames[i], true);
                if (ammoCollection == null) { continue; }
                m_AmmoItemCollections.ItemCollections.Add(ammoCollection);
            }

            m_EquippableItemCollections = new ItemCollectionGroup();
            m_EquippableItemCollections.ItemCollections = new List<ItemCollection>();
            for (int i = 0; i < m_EquippableItemCollectionNames.Length; i++) {
                var equippableItemCollection = GetItemCollection(m_EquippableItemCollectionNames[i], true);
                if(equippableItemCollection == null){continue;}
                m_EquippableItemCollections.ItemCollections.Add(equippableItemCollection);
            }

            m_LoadoutItemCollections = new ItemCollectionGroup();
            m_LoadoutItemCollections.ItemCollections = new List<ItemCollection>();
            for (int i = 0; i < m_LoadoutItemCollectionNames.Length; i++) {
                var loadoutItemCollection = GetItemCollection(m_LoadoutItemCollectionNames[i], true);
                if(loadoutItemCollection == null){continue;}
                m_LoadoutItemCollections.ItemCollections.Add(loadoutItemCollection);
            }
            
            m_BridgeEquippableProcessing = new BridgeEquippableProcessing(this);
            m_Inventory.AddRestriction(m_BridgeEquippableProcessing);
            
            m_BridgeDropProcessing = new BridgeDropProcessing(this);

            EventHandler.RegisterEvent<ItemInfo, ItemStack>(m_Inventory, EventNames.c_Inventory_OnAdd_ItemInfo_ItemStack, OnAddItemToInventory);
            EventHandler.RegisterEvent<ItemInfo>(m_Inventory, EventNames.c_Inventory_OnRemove_ItemInfo, OnRemoveItemFromInventory);
            //EventHandler.RegisterEvent<PanelEventData>(m_GameObject, EventNames.c_GameObject_OnPanelOpenClose_PanelEventData, OnOpenCloseMenu);
        }

        /// <summary>
        /// Initialize the bridge after the other components have initialized.
        /// </summary>
        protected override void Start()
        {
            var characterLocomotion = m_GameObject.GetCachedComponent<Character.UltimateCharacterLocomotion>();
            m_EquipUnequipAbilities = characterLocomotion.GetAbilities<EquipUnequip>();

            base.Start();
        }

        /// <summary>
        /// Returns the ItemCollection with the specified name.
        /// </summary>
        /// <param name="collectionName">The name of the ItemCollection.</param>
        /// <param name="errorIfNull">Should an error be logged if the ItemCollection cannot be found?</param>
        /// <returns>The ItemCollection with the specified name.</returns>
        private ItemCollection GetItemCollection(string collectionName, bool errorIfNull)
        {
            var itemCollection = m_Inventory.GetItemCollection(collectionName);
            if (errorIfNull && itemCollection == null) {
                Debug.LogWarning($"Error: Unable to find the Item Collection with name {collectionName} within the Character Inventory.");
            }
            return itemCollection;
        }

        /// <summary>
        /// Is the item
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool IsMultiItem(Opsive.UltimateInventorySystem.Core.Item item)
        {
            if (item == null) {
                return false;
            }

            return item.HasAttribute(MultiItemPrefabsAttributeName);
        }
        
        /// <summary>
        /// Is the Item Active.
        /// </summary>
        /// <param name="item">The item to check if active.</param>
        /// <returns>True if active</returns>
        public bool IsItemActive(Opsive.UltimateInventorySystem.Core.Item item)
        {
            var characterItem = GetCharacterItem(item);
            return IsItemActive(characterItem);
        }

        /// <summary>
        /// Is the Item Active.
        /// </summary>
        /// <param name="item">The item to check if active.</param>
        /// <returns>True if active</returns>
        public virtual bool IsItemActive(Item characterItem)
        {
            if (characterItem == null) { return false; }

            var slotID = characterItem.SlotID;

            var active = characterItem.IsActive();
            var activeItem = GetActiveItem(slotID);
            return active && activeItem == characterItem;
        }

        /// <summary>
        /// An Item has been added to the Inventory.
        /// </summary>
        /// <param name="itemInfo">The info that describes hte item.</param>
        /// <param name="addedItemStack">The ItemCollection that the item was added to.</param>
        private void OnAddItemToInventory(ItemInfo itemInfo, ItemStack addedItemStack)
        {
            if(addedItemStack == null){ return; }
            
#if DEBUG_BRIDGE
            Debug.Log("Item Added or Moved in Inventory, origin: " + itemInfo + " | added stack: " + addedItemStack ,gameObject);
#endif

            //if(m_IgnoreAdd){return;}

            var originItemCollection = itemInfo.ItemCollection;
            var destinationItemCollection = addedItemStack.ItemCollection;

            if (m_AmmoItemCollections.Contains(destinationItemCollection)) {

                if (m_AmmoCategory.InherentlyContains(itemInfo.Item)) {
                    // The item has already been added to the inventory. Only the event needs to be sent.
#if DEBUG_BRIDGE
                    Debug.Log("Add to ammo " + itemInfo + " " + itemInfo.Item.ItemDefinition + " " +
                              m_GameObject);
#endif
                    ItemIdentifierPickedUp(itemInfo.Item, itemInfo.Amount, -1, false, true);
                }
            }
        }
        
        /// <summary>
        /// An Item has been removed from the Inventory.
        /// </summary>
        /// <param name="itemInfo">The info that describes the item.</param>
        private void OnRemoveItemFromInventory(ItemInfo itemInfo)
        {
#if DEBUG_BRIDGE
            Debug.Log("Item Removed or Moved in Inventory: " + itemInfo,gameObject);
#endif
            if (m_AmmoItemCollections.Contains(itemInfo.ItemCollection)) {
                // Notify those interested that an item has been adjusted.
                var remaining = GetItemIdentifierAmount(itemInfo.Item);
                EventHandler.ExecuteEvent<IItemIdentifier, int>(m_GameObject, "OnInventoryAdjustItemIdentifierAmount", itemInfo.Item, remaining);
                if (m_OnAdjustItemIdentifierAmountEvent != null) {
                    m_OnAdjustItemIdentifierAmountEvent.Invoke(itemInfo.Item, remaining);
                }
            }
        }


        /// <summary>
        /// The Drop ItemAction has been triggered.
        /// </summary>
        /// <param name="item">The Item that should be dropped.</param>
        public virtual Inventory DropItem(ItemInfo itemInfo, bool forceDrop, bool removeItemOnDrop)
        {
            return m_BridgeDropProcessing.DropInventoryPickup(itemInfo, forceDrop, removeItemOnDrop);
        }

        /// <summary>
        /// Returns the Inventory with the specified Slot ID.
        /// </summary>
        /// <param name="slotID">The ID of the slot for the ItemObject that should be retrieved.</param>
        /// <returns></returns>
        public Opsive.UltimateInventorySystem.Core.Item GetActiveInventoryItem(int slotID)
        {
            if (slotID < 0 || slotID >= m_ActiveItem.Length) {
                return null;
            }
            return m_ActiveItem[slotID];
        }

        /// <summary>
        /// Returns the ItemObject with the specified Item and Slot ID.
        /// </summary>
        /// <param name="item">The Item for the ItemObject that should be retrieved.</param>
        /// <param name="slotID">The ID of the slot for the ItemObject that should be retrieved.</param>
        /// <returns></returns>
        public ItemObject GetItemObjectAtSlot(Opsive.UltimateInventorySystem.Core.Item item, int slotID)
        {

            var characterItem = GetCharacterItem(item, slotID);
            if (characterItem == null) {
                return null;
            }

            return characterItem.gameObject.GetCachedComponent<ItemObject>();
        }

        /// <summary>
        /// Get the Character Item from the Inventory Item.
        /// </summary>
        /// <param name="item">The inventory item.</param>
        /// <param name="slotID">The ID of the slot which the item belongs to.</param>
        /// <returns>The item which occupies the specified slot. Can be null.</returns>
        public virtual Item GetCharacterItem(Opsive.UltimateInventorySystem.Core.Item item, int slotID = -1)
        {
            // The item will be null if the item hasn't been assigned an ItemIdentifier yet.
            if (item == null) { return null; }
            
            if(m_BridgeEquippableProcessing.InventoryItemToCharacterItems.TryGetValue(item, out var characterItemList) == false) {
                return null;
            }
            if (characterItemList.Count == 0) { return null; }

            Items.Item characterItem = null;

            if (slotID != -1) {
                for (int i = 0; i < characterItemList.Count; i++) {
                    characterItem = characterItemList[i];
                    if (characterItem.SlotID == slotID) { return characterItem; }
                }

                return null;
            }

            if (characterItemList.Count == 1) { return characterItemList[0]; }

            //If slot id is -1 the active item set has priority.
            //Reverse loop such that first in the list has priority.
            for (int i = characterItemList.Count - 1; i >= 0; i--) {
                characterItem = characterItemList[i];
                if (characterItem.IsActive()) {
                    return characterItem;
                }
            }
                
            //If no item is active then the first item found in the item set has priority
            var itemSetCategoryCount = m_ItemSetManager.CategoryItemSets.Length;
            for (int i = 0; i < itemSetCategoryCount; i++) {
                var targetSlotID = m_ItemSetManager.GetSlotIDFor(i,item);
                if(targetSlotID == -1){continue;}
                    
                return GetCharacterItem(item, targetSlotID);
            }

            return characterItem;
        }
        
        /// <summary>
        /// Get the Character Item from the Inventory Item.
        /// </summary>
        /// <param name="item">The inventory item.</param>
        /// <param name="slotID">The ID of the slot which the item belongs to.</param>
        /// <returns>The item which occupies the specified slot. Can be null.</returns>
        public virtual ListSlice<Item> GetCharacterItems(Opsive.UltimateInventorySystem.Core.Item item)
        {
            if(m_BridgeEquippableProcessing.InventoryItemToCharacterItems.TryGetValue(item, out var characterItemList) == false) {
                return (null,0,0);
            }

            return characterItemList;
        }

        /// <summary>
        /// Get the inventory item from the character item.
        /// </summary>
        /// <param name="characterItem">The character Item.</param>
        /// <returns>The inventory Item.</returns>
        public Opsive.UltimateInventorySystem.Core.Item GetInventoryItem(Item characterItem)
        {
            if (characterItem == null) {
                return null;
            }

            return characterItem.ItemIdentifier as Opsive.UltimateInventorySystem.Core.Item;
        }
        
        /// <summary>
        /// Move the Item from the Default Item Collection to one of the equippable item collections.
        /// </summary>
        /// <param name="itemInfo">The item info to move.</param>
        /// <param name="equippableCollectionIndex">The index of the equippable item collection.</param>
        /// <param name="slotIndex">The slot Index if the equippable is an item slot collection.</param>
        /// <returns>The item info moved.</returns>
        public virtual ItemInfo MoveItemToEquippable(ItemInfo itemInfo, int equippableCollectionIndex = 0, int slotIndex = -1)
        {
            var equippableCollection = m_EquippableItemCollections.GetItemCollection(equippableCollectionIndex);

            if (equippableCollection == null) {
                Debug.LogWarning($"The equippable item collection at index {equippableCollectionIndex} could not be found",gameObject);
                return ItemInfo.None;
            }

            var sourceItemCollection = itemInfo.ItemCollection;
            if (sourceItemCollection == null) {
                sourceItemCollection = DefaultItemCollection;
            }

            if(sourceItemCollection.HasItem(itemInfo) == false) {
                Debug.LogWarning($"{itemInfo} cannot be moved to equippable because it was not in default first.",gameObject);
                return ItemInfo.None;
            }
            
            //Remove the item from Default collection.
            itemInfo = sourceItemCollection.RemoveItem(itemInfo);

            ItemInfo movedItemInfo;
            
            if (equippableCollection is ItemSlotCollection equippableSlotCollection) {

                if (slotIndex == -1) {
                    slotIndex = equippableSlotCollection.GetTargetSlotIndex(itemInfo.Item);
                }
                
                var previousItemInSlot = equippableSlotCollection.GetItemInfoAtSlot(slotIndex);

                if (previousItemInSlot.Item != null) {
                    //If the previous item is stackable don't remove it.
                    if (previousItemInSlot.Item.StackableEquivalentTo(itemInfo.Item)) {
                        previousItemInSlot = ItemInfo.None;
                    } else {
                        previousItemInSlot = equippableSlotCollection.RemoveItem(slotIndex); 
                    }
                }
            
                movedItemInfo = equippableSlotCollection.AddItem(itemInfo, slotIndex);

                if (previousItemInSlot.Item != null) {
                    sourceItemCollection.AddItem(previousItemInSlot);
                }
                
            } else {
                movedItemInfo = equippableCollection.AddItem(itemInfo);
            }
            
            //Not all the item was added, return the items to the default collection.
            if (movedItemInfo.Amount != itemInfo.Amount) {
                var amountToReturn = itemInfo.Amount - movedItemInfo.Amount;
                sourceItemCollection.AddItem((ItemInfo) (amountToReturn, itemInfo));
            }

            return movedItemInfo;

        }

        /// <summary>
        /// Move the item from one of th equippable item collection to the default item collection.
        /// </summary>
        /// <param name="itemInfo">The item info.</param>
        /// <param name="equippableCollectionIndex">The index of the equippable item collection.</param>
        /// <param name="slotIndex">The slot Index if the equippable is an item slot collection.</param>
        /// <returns>The item info moved.</returns>
        public ItemInfo MoveItemToDefault(ItemInfo itemInfo, int equippableCollectionIndex = 0, int slotIndex = -1)
        {
            var equippableCollection = m_EquippableItemCollections.GetItemCollection(equippableCollectionIndex);

            if (equippableCollection == null) {
                Debug.LogWarning($"The equippable item collection at index {equippableCollectionIndex} could not be found",gameObject);
                return ItemInfo.None;
            }
            
            ItemInfo movedItemInfo;
            
            if (equippableCollection.HasItem(itemInfo) == false) {
                Debug.LogWarning($"{itemInfo} cannot be moved to default because it was equippable.",gameObject);
                return ItemInfo.None;
            }

            if (equippableCollection is ItemSlotCollection equippableSlotCollection) {

                if (slotIndex == -1) {
                    slotIndex = equippableSlotCollection.GetItemSlotIndex(itemInfo.Item);
                }
                
                movedItemInfo = equippableSlotCollection.RemoveItem(slotIndex, itemInfo.Amount);
                
            } else {
                movedItemInfo = equippableCollection.RemoveItem(itemInfo);
            }
            
            m_DefaultItemCollection.AddItem(movedItemInfo);

            return movedItemInfo;
        }

        /// <summary>
        /// Move the item from collection and equip or unequip the item.
        /// </summary>
        /// <param name="itemInfo">The item info to equip/unequip.</param>
        /// <param name="equip">Equip or Unequip?</param>
        public void MoveEquip(ItemInfo itemInfo, bool equip)
        {
            MoveEquip(itemInfo, 0, -1, equip);
        }
        
        /// <summary>
        /// Move the item from collection and equip or unequip the item.
        /// </summary>
        /// <param name="itemInfo">The item info to equip/unequip.</param>
        /// <param name="equippableCollectionIndex">The index of the equippable item collection.</param>
        /// <param name="slotIndex">The slot Index if the equippable is an item slot collection.</param>
        /// <param name="equip">Equip or Unequip?</param>
        public void MoveEquip(ItemInfo itemInfo, int equippableItemCollectionSet, int slotID, bool equip)
        {
            if (equip) {
                m_BridgeEquippableProcessing.AboutToEquip(itemInfo);
                MoveItemToEquippable(itemInfo, equippableItemCollectionSet, slotID);
                Equip(itemInfo,true);
            } else {
                MoveItemToDefault(itemInfo, equippableItemCollectionSet, slotID);
            }
        }

        /// <summary>
        /// Equip or Unequip an item, the item must be equippable.
        /// </summary>
        /// <param name="itemInfo">The item info to equip/Unequip.</param>
        /// <param name="equip">Equip or Unequip?</param>
        public void Equip(ItemInfo itemInfo, bool equip, bool forceEquipUnequip = false, bool immediateEquipUnequip = false)
        {
            var characterItem = GetCharacterItem(itemInfo.Item);
            if(characterItem == null){return;}

            //Don't equip or unequip if it is already equipped or unequipped.
            if (characterItem.IsActive() == equip) { return; }
            
            var categoryIndex = ItemSetManager.GetMatchingCategoryIndex(itemInfo.Item);
            if (categoryIndex == -1) {
                Debug.LogWarning($"The Item Set for item {itemInfo} could not be found and therefore the item could not be equipped. Perhaps you are missing an item Set Rule for this item?");
                return;
            }

            if (equip == false) {
                //To Unequip find the next target item set index, and make sure it is not equal to the item set index that should be unequipped.
                var itemSetIndex = m_ItemSetManager.GetTargetItemSetIndex(categoryIndex, -1);
                if (itemSetIndex == m_ItemSetManager.GetItemSetIndexFor(categoryIndex, itemInfo.Item)) {
                    itemSetIndex = -1;
                }
                Equip(categoryIndex, itemSetIndex, forceEquipUnequip, immediateEquipUnequip);
            } else {
                var itemSetIndex = m_ItemSetManager.GetItemSetIndexFor(categoryIndex, itemInfo.Item);
                Equip(categoryIndex, itemSetIndex, forceEquipUnequip, immediateEquipUnequip);
            }
        }

        /// <summary>
        /// Equip the default itm.
        /// </summary>
        public void Equip()
        {
            var categoryIndex = 0;
            var itemSetIndex = m_ItemSetManager.GetDefaultItemSetIndex(categoryIndex);
            if (itemSetIndex <= 0) {
                itemSetIndex = 0;
            }

            Equip(categoryIndex, itemSetIndex);
        }
        
        /// <summary>
        /// Equip a specific Item Set.
        /// </summary>
        /// <param name="categoryIndex">The category index.</param>
        /// <param name="itemSetIndex">The item set index.</param>
        /// <param name="forceEquipUnequip">Force equip/unequip?</param>
        /// <param name="immediateEquipUnequip">immediate equip/unequip?</param>
        public void Equip(int categoryIndex, int itemSetIndex, bool forceEquipUnequip = false, bool immediateEquipUnequip = false)
        {
            // The correct ItemSet has been found. Equip the item using the correct EquipUnequip ability.
            for (int i = 0; i < m_EquipUnequipAbilities.Length; ++i) {
                var abilityCategoryIndex = m_EquipUnequipAbilities[i].ItemSetCategoryIndex;
                if (abilityCategoryIndex >= 0 && abilityCategoryIndex != categoryIndex) {
                    continue;
                }
                m_EquipUnequipAbilities[i].StartEquipUnequip(itemSetIndex, forceEquipUnequip, immediateEquipUnequip);
            }
        }
        
        /// <summary>
        /// Called when the bridge will be loaded, disable equipping or state changes.
        /// </summary>
        public void OnWillLoadSaveData()
        {
            BridgeEquippableProcessing.EquipOnItemSetUpdate = false;
            BridgeEquippableProcessing.StateChangeOnItemSetUpdate = false;
        }

        /// <summary>
        /// Called when the bridge finished loading the save data, re-enable the equipping and state changes.
        /// </summary>
        public void OnSaveDataLoaded()
        {
            BridgeEquippableProcessing.EquipOnItemSetUpdate = true;
            BridgeEquippableProcessing.StateChangeOnItemSetUpdate = true;
        }

    #region Inventory Base overrides

        /// <summary>
        /// Remove all the items.
        /// </summary>
        /// <param name="drop">Drop the removed Items.</param>
        public override void RemoveAllItems(bool drop)
        {
            var allItemInfos = m_Inventory.AllItemInfos;
            for (int i = allItemInfos.Count - 1; i >= 0; i--) {
                // Multiple items may be dropped at the same time.
                if (allItemInfos.Count <= i) {
                    continue;
                }
                if (drop) {
                    DropItem(allItemInfos[i], true, true);
                } else {
                    m_Inventory.RemoveItem(allItemInfos[i]);
                }
            }
        }
        
        /// <summary>
        /// Add the content of the default loadout item collection to the main item collection.
        /// </summary>
        public override void LoadDefaultLoadout()
        {
            if (m_LoadoutItemCollections == null) {
                return;
            }
            
            // Make the inventory monitor stop listening while loading the loadout.
            EventHandler.ExecuteEvent(gameObject, EventNames.c_InventoryGameObject_InventoryMonitorListen_Bool, false);

            // First take into account the items that were set in equippable Item Collections.
            m_BridgeEquippableProcessing.LoadDefaultLoadout();
            
            // Equip the default items.
            var categorySetCount = m_ItemSetManager.CategoryItemSets.Length;
            for (int i = 0; i < categorySetCount; i++) {
                var targetItemSetIndex = m_ItemSetManager.GetTargetItemSetIndex(i, -1);
                if(targetItemSetIndex == -1){continue;}
                Equip(i,targetItemSetIndex, true, true);
            }

            // Add the items from the loadouts
            for (int i = 0; i < m_LoadoutItemCollections.ItemCollections.Count; i++) {
                var loadoutItemCollection = m_LoadoutItemCollections.ItemCollections[i];

                // Use the custom character loadout function to choose whether to equip the items or not.
                if (loadoutItemCollection is CharacterLoadoutItemCollection characterLoadoutItemCollection) {
                    characterLoadoutItemCollection.LoadCharacterLoadout(this);
                    continue;
                }
                
                // Not all items can belong to multiple collections. Create a new item and add that item to the default The loadout should remain the same
                var items = loadoutItemCollection.GetAllItemStacks();
                for (int j = 0; j < items.Count; ++j) {
                    var duplicateItem = InventorySystemManager.CreateItem(items[j].Item);
                    m_DefaultItemCollection.AddItem((ItemInfo)(duplicateItem, items[j].Amount));
                }
            }

            EventHandler.ExecuteEvent(gameObject, EventNames.c_InventoryGameObject_InventoryMonitorListen_Bool, true);
        }

        /// <summary>
        /// Internal method which determines if the character has the specified item.
        /// </summary>
        /// <param name="item">The item to check against.</param>
        /// <returns>True if the character has the item.</returns>
        protected override bool HasItemInternal(Item item)
        {
            if (item == null) { return false; }
            
            //Check for items that are being equipped.
            if (m_BridgeEquippableProcessing.IsItemEquippable(item)) {
                return true;
            }

            //Check for items that are equippable.
            var equippableItemStacks = m_EquippableItemCollections.GetAllItemStacks();
            for (int j = 0; j < equippableItemStacks.Count; j++) {
                var itemStack = equippableItemStacks[j];
                if(itemStack == null){ continue; }
            
                var itemPrefab = itemStack.Item.GetAttribute<Attribute<GameObject>>(SingleItemPrefabAttributeName).GetValue();
            
                //Check that the Item Prefab matches the item.
                if (ObjectPool.GetOriginalObject(item.gameObject) == itemPrefab) {
                    return true;
                }
            }

            //Check within the inventory
            var inventoryItem = item?.ItemIdentifier as Opsive.UltimateInventorySystem.Core.Item;
            var hasItem = m_Inventory.HasItem(inventoryItem);

#if DEBUG_BRIDGE
            Debug.Log("Has Item " + inventoryItem + "At "+ item.SlotID+ "? "+ hasItem);
            for (int i = 0; i < equippableItemStacks.Count; i++) {
                Debug.Log("Equippable Items: " + equippableItemStacks[i]);
            }
            
#endif

            return hasItem;
        }

        /// <summary>
        /// Adds the item to the inventory. This does not add the actual ItemIdentifier - PickupItem does that.
        /// </summary>
        /// <param name="item">The item to add.</param>
        /// <returns>True if the item was added to the inventory.</returns>
        protected override bool AddItemInternal(Item item)
        {
#if DEBUG_BRIDGE
            Debug.Log("Try add item internal " + item.SlotID);
#endif
            if (m_BridgeEquippableProcessing.IsItemEquippable(item) == false) {
                return false;
            }
            
            // Add the item to the equipped item collection.
#if DEBUG_BRIDGE
            Debug.Log("Add to equippable " + item.SlotID);
#endif

            return true;
        }

        /// <summary>
        /// Adds the specified amount of the ItemIdentifier to the inventory.
        /// </summary>
        /// <param name="itemIdentifier">The ItemIdentifier to add.</param>
        /// <param name="amount">The amount of ItemIdentifier to add.</param>
        /// <returns>True if the ItemIdentifier was picked up.</returns>
        protected override bool PickupInternal(IItemIdentifier itemIdentifier, int amount)
        {
            if (itemIdentifier is ItemType) {
                Debug.LogError($"Error: The ItemIdentifier {itemIdentifier} is an ItemType. The identifier must be created by the Ultimate Inventory System.");
                return false;
            }
#if UNITY_EDITOR
            if (!m_InventorySystemManager.Database.Contains(itemIdentifier as Opsive.UltimateInventorySystem.Core.Item)) {
                Debug.LogError($"Error: The Item ({itemIdentifier}) does not exist within the active database ({m_InventorySystemManager.Database.name}).");
                return false;
            }
#endif

            // Any picked up ItemTypes should be added to the default item collection.
            var item = itemIdentifier as Opsive.UltimateInventorySystem.Core.Item;
#if DEBUG_BRIDGE
            Debug.Log("Pickup " + item);
#endif
            if (m_DefaultItemCollection.AddItem(item, amount).Amount > 0) {
                //TODO should this event be executed in the on add event instead? maybe not
                EventHandler.ExecuteEvent(m_GameObject, "OnInventoryPickupItemIdentifier", itemIdentifier, amount, false, false);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Internal method which returns the active item in the specified slot.
        /// </summary>
        /// <param name="slotID">The ID of the slot which the item belongs to.</param>
        /// <returns>The active item which occupies the specified slot. Can be null.</returns>
        protected override Item GetActiveItemInternal(int slotID)
        {
            if (slotID < 0 || slotID >= m_ActiveItem.Length) { return null; }
            
            var item = m_ActiveItem[slotID];
            if (item == null) { return null; }
            
            return GetCharacterItem(item, slotID);
        }

        /// <summary>
        /// Internal method which returns the item that corresponds to the specified ItemIdentifier.
        /// </summary>
        /// <param name="itemIdentifier">The ItemIdentifier of the item.</param>
        /// <param name="slotID">The ID of the slot which the item belongs to.</param>
        /// <returns>The item which occupies the specified slot. Can be null.</returns>
        protected override Item GetItemInternal(IItemIdentifier itemIdentifier, int slotID)
        {
            var item = itemIdentifier as Opsive.UltimateInventorySystem.Core.Item;
            return GetCharacterItem(item, slotID);
        }

        /// <summary>
        /// Internal method which equips the ItemIdentifier in the specified slot.
        /// </summary>
        /// <param name="itemIdentifier">The ItemIdentifier to equip.</param>
        /// <param name="slotID">The ID of the slot.</param>
        /// <returns>The item which corresponds to the ItemIdentifier. Can be null.</returns>
        protected override Item EquipItemInternal(IItemIdentifier itemIdentifier, int slotID)
        {
            if (itemIdentifier == null || slotID < -1 || slotID >= m_ActiveItem.Length) {
                return null;
            }
            
            var item = itemIdentifier as Opsive.UltimateInventorySystem.Core.Item;
#if DEBUG_BRIDGE
            Debug.Log("Active Equipped for slot "+slotID+" Item:"+item);
#endif
            
            var characterItem = GetCharacterItem(item, slotID);
            if (characterItem == null) {
                return null;
            }
            
            m_ActiveItem[slotID] = item;
            return characterItem;
        }

        /// <summary>
        /// Internal method which unequips the item in the specified slot.
        /// </summary>
        /// <param name="slotID">The ID of the slot.</param>
        /// <returns>The item that was unequipped.</returns>
        protected override Item UnequipItemInternal(int slotID)
        {
            if (slotID < -1 || slotID >= m_ActiveItem.Length) {
                return null;
            }
            
            var prevItem = GetActiveItem(slotID);
#if DEBUG_BRIDGE
            Debug.Log("Active Unequipped for slot "+slotID+" item "+prevItem);
#endif
            m_ActiveItem[slotID] = null;
            return prevItem;
        }

        /// <summary>
        /// Internal method which returns the amount of the specified ItemIdentifier.
        /// </summary>
        /// <param name="itemIdentifier">The ItemIdentifier to get the amount of.</param>
        /// <returns>The amount of the specified ItemIdentifier.</returns>
        protected override int GetItemIdentifierAmountInternal(IItemIdentifier itemIdentifier)
        {
            if (itemIdentifier is ItemType) {
                Debug.LogError($"Error: The ItemIdentifier {itemIdentifier} is an ItemType. The identifier must be created by the Ultimate Inventory System.");
                return 0;
            }
            
            var inventoryItem = itemIdentifier as Opsive.UltimateInventorySystem.Core.Item;
            
#if UNITY_EDITOR
            if (!m_InventorySystemManager.Database.Contains(inventoryItem)) {
                Debug.LogError($"Error: The Item ({itemIdentifier}) does not exist within the active database ({m_InventorySystemManager.Database.name}).");
                return 0;
            }
#endif

            //If the item is ammo check default items if not check Equippable items.
            if(m_AmmoCategory.InherentlyContains(inventoryItem))
            {
                return m_AmmoItemCollections.GetItemAmount(inventoryItem);
            }

            return EquippableItemCollections.GetItemAmount(inventoryItem);
        }

        /// <summary>
        /// Internal method which adjusts the amount of the specified ItemIdentifier.
        /// </summary>
        /// <param name="itemIdentifier">The ItemIdentifier to adjust.</param>
        /// <param name="amount">The amount of ItemIdentifier to adjust.</param>
        protected override void AdjustItemIdentifierAmountInternal(IItemIdentifier itemIdentifier, int amount)
        {
            if (itemIdentifier is ItemType) {
                Debug.LogError($"Error: The ItemIdentifier {itemIdentifier} is an ItemType. The identifier must be created by the Ultimate Inventory System.");
                return;
            }

            var item = itemIdentifier as Opsive.UltimateInventorySystem.Core.Item;
#if DEBUG_BRIDGE
            Debug.Log("Adjust " + itemIdentifier + " by " + amount);
#endif

            var equippableItemInfo = m_EquippableItemCollections.GetItemInfo(item);

            if (amount < 0) {
                if (equippableItemInfo.HasValue) {
                    equippableItemInfo.Value.ItemCollection.RemoveItem(item, -amount);
                } else {
                    if (m_DefaultItemCollection.HasItem(item)) {
                        m_DefaultItemCollection.RemoveItem(item, -amount);
                    }else if (m_AmmoItemCollections.HasItem(item)) {
                        var ammoItemInfo = m_AmmoItemCollections.GetItemInfo(item);
                        ammoItemInfo.Value.ItemCollection.RemoveItem(item, -amount);
                    } else {
                        m_Inventory.RemoveItem(new ItemInfo(item, -amount));
                    }
                }
            } else {
                if (equippableItemInfo.HasValue) {
                    equippableItemInfo.Value.ItemCollection.AddItem(item, amount);
                } else {
                    m_DefaultItemCollection.AddItem(item, amount);
                }
            }
        }

        /// <summary>
        /// Removes the ItemIdentifier from the inventory.
        /// </summary>
        /// <param name="itemIdentifier">The ItemIdentifier to remove.</param>
        /// <param name="slotID">The ID of the slot.</param>
        /// <param name="amount">The amount of the ItemIdentnfier that should be removed.</param>
        /// <param name="drop">Should the item be dropped when removed?</param>
        /// <returns>The instance of the dropped item (can be null).</returns>
        public override GameObject RemoveItem(IItemIdentifier itemIdentifier, int slotID, int amount, bool drop)
        {
            var inventoryItem = itemIdentifier as Opsive.UltimateInventorySystem.Core.Item;
            if (inventoryItem == null) {
                return null;
            }

            var itemInfo = (ItemInfo) (inventoryItem, amount);
            
            if (drop) {
                DropItem(itemInfo, true, true);
                return null;
            }
            
            var result = m_Inventory.GetItemInfo(itemInfo.Item);
            if (result.HasValue) {
                m_BridgeEquippableProcessing.AboutToDrop(itemInfo);
                itemInfo = result.Value;
                itemInfo.ItemCollection.RemoveItem(itemInfo);
            }
            return null;
        }

        /// <summary>
        /// Removes the ItemIdentifier from the inventory.
        /// </summary>
        /// <param name="itemIdentifier">The ItemIdentifier to remove.</param>
        /// <param name="slotID">The ID of the slot.</param>
        /// <param name="amount">The amount of the ItemIdentnfier that should be removed.</param>
        /// <param name="drop">Should the item be dropped when removed?</param>
        public virtual void BaseRemoveItem(IItemIdentifier itemIdentifier, int slotID, int amount, bool drop)
        {
            //In the integration a weapon is removed when it is unequipped,
            //the ammo should stay on the weapon no matter whether it is unequipped or dropped.
            var dropConsumableItem = false;
            var item = GetItem(itemIdentifier, slotID);
            if(item != null) {
                dropConsumableItem = item.DropConsumableItems;
                item.DropConsumableItems = false;
            }
            base.RemoveItem(itemIdentifier, slotID, amount, drop);
            if(item != null) {
                item.DropConsumableItems = dropConsumableItem;
            }
        }

        /// <summary>
        /// Internal method which removes the ItemIdentifier from the inventory.
        /// </summary>
        /// <param name="itemIdentifier">The ItemIdentifier to remove.</param>
        /// <param name="slotID">The ID of the slot.</param>
        /// <param name="amount">The ItemIdentifier amount that should be removed.</param>
        /// <returns>The item that was removed (can be null).</returns>
        protected override void RemoveItemIdentifierInternal(IItemIdentifier itemIdentifier, int slotID, int amount)
        {
            if (slotID == -1) {
                return;
            }

            // The item should no longer be equipped.
            if (m_ActiveItem[slotID] != null && m_ActiveItem[slotID] == itemIdentifier) {
                m_ActiveItem[slotID] = null;
            }
        }

        /// <summary>
        /// Drop an Item from the character.
        /// </summary>
        /// <param name="characterItem">The item to drop.</param>
        /// <param name="forceDrop">Should the item be dropped even if the inventory doesn't contain any count for the item?</param>
        /// <param name="amount">The amount of ItemIdentifier that should be dropped.</param>
        /// <param name="remove">Should the item be removed after it is dropped?</param>
        /// <returns>The instance of the dropped item (can be null).</returns>
        public override GameObject DropItem(Item characterItem, int amount, bool forceDrop, bool remove)
        {
            var inventoryItem = GetInventoryItem(characterItem);

            if (inventoryItem == null) { return null; }
            
            var spawnedItem = DropItem((ItemInfo)(inventoryItem, amount), forceDrop, remove);
            if (spawnedItem != null) {
                return spawnedItem.gameObject;
            }
            return null;
        }
        
    #endregion

        /// <summary>
        /// Check if the object contained by this component are part of the database.
        /// </summary>
        /// <param name="database">The database.</param>
        /// <returns>True if all the objects in the component are part of that database.</returns>
        bool IDatabaseSwitcher.IsComponentValidForDatabase(InventorySystemDatabase database)
        {
            if (database == null) { return false; }

            database.Initialize(false);

            return database.Contains(m_EquippableCategory) &&
                   database.Contains(m_AmmoCategory);
        }

        /// <summary>
        /// Replace any object that is not in the database by an equivalent object in the specified database.
        /// </summary>
        /// <param name="database">The database.</param>
        /// <returns>The objects that have been changed.</returns>
        ModifiedObjectWithDatabaseObjects IDatabaseSwitcher.ReplaceInventoryObjectsBySelectedDatabaseEquivalents(InventorySystemDatabase database)
        {
            if (database == null) { return null; }

            database.Initialize(false);

            m_EquippableCategory = database.FindSimilar(m_EquippableCategory);
            m_AmmoCategory = database.FindSimilar(m_AmmoCategory);
            return null;
        }
    }
}