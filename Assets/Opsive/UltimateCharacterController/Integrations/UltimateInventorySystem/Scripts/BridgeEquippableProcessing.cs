/// ---------------------------------------------
/// Ultimate Character Controller
/// Copyright (c) Opsive. All Rights Reserved.
/// https://www.opsive.com
/// ---------------------------------------------

//#define DEBUG_BRIDGE

namespace Opsive.UltimateCharacterController.Integrations.UltimateInventorySystem
{
    using Opsive.Shared.Events;
    using Opsive.Shared.Game;
    using Opsive.Shared.Utility;
    using Opsive.UltimateCharacterController.Items;
    using Opsive.UltimateCharacterController.Items.Actions;
    using Opsive.UltimateCharacterController.Objects.CharacterAssist;
    using Opsive.UltimateCharacterController.Utility;
    using Opsive.UltimateInventorySystem.Core;
    using Opsive.UltimateInventorySystem.Core.AttributeSystem;
    using Opsive.UltimateInventorySystem.Core.DataStructures;
    using Opsive.UltimateInventorySystem.Core.InventoryCollections;
    using System.Collections.Generic;
    using UnityEngine;
    using Item = Opsive.UltimateInventorySystem.Core.Item;
    using ItemCollection = Opsive.UltimateInventorySystem.Core.InventoryCollections.ItemCollection;
    using Inventory = Opsive.UltimateInventorySystem.Core.InventoryCollections.Inventory;
    using CharacterItem = Opsive.UltimateCharacterController.Items.Item;
    
    /// <summary>
    /// Character Item Info has reference to a character Item and a Item Info.
    /// </summary>
    public class CharacterItemInfo
    {
        private Items.Item m_CharacterItem;
        private ItemInfo m_ItemInfo;

        public Items.Item CharacterItem => m_CharacterItem;
        public ItemInfo ItemInfo => m_ItemInfo;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="characterItem">The character item.</param>
        /// <param name="itemInfo">The item info.</param>
        public CharacterItemInfo(Items.Item characterItem, ItemInfo itemInfo)
        {
            Set(characterItem, itemInfo);
        }
        
        /// <summary>
        /// Setter.
        /// </summary>
        /// <param name="characterItem">The character item.</param>
        /// <param name="itemInfo">The item info.</param>
        public void Set(Items.Item characterItem, ItemInfo itemInfo)
        {
            m_CharacterItem = characterItem;
            m_ItemInfo = itemInfo;
        }
    }

    /// <summary>
    /// The Bridge Equippable Processing is used to detect items added in the equippable item collection and equipping/unequipping them.
    /// </summary>
    [HideFromItemRestrictionSetAttribute]
    public class BridgeEquippableProcessing : IItemRestriction
    {
        protected CharacterInventoryBridge m_InventoryBridge;

        protected GameObject m_CharacterGameobject;
        
        private List<CharacterItemInfo> m_RemovingFromItemSet;
        private List<Item> m_CurrentItemSet;
        protected ItemInfo m_AboutToEquip;
        protected ItemInfo m_AboutToDropItemInfo;
        protected Dictionary<Item, List<Items.Item>> m_InventoryItemToCharacterItems;
        protected ActiveAndNextItemSetData m_PreviousActiveSets;
        protected bool m_EquipOnItemSetUpdate;
        protected bool m_StateChangeOnItemSetUpdate;

        public ItemCollection DefaultItemCollection => m_InventoryBridge.DefaultItemCollection;
        public ItemCollectionGroup EquippableItemCollections => m_InventoryBridge.EquippableItemCollections;
        public InventoryItemSetManager ItemSetManager => m_InventoryBridge.ItemSetManager;
        public string PrefabAttributeName => m_InventoryBridge.SingleItemPrefabAttributeName;
        public string MultiItemPrefabsAttributeName => m_InventoryBridge.MultiItemPrefabsAttributeName;
        public Dictionary<Item, List<Items.Item>> InventoryItemToCharacterItems => m_InventoryItemToCharacterItems;

        public bool EquipOnItemSetUpdate
        {
            get => m_EquipOnItemSetUpdate;
            set => m_EquipOnItemSetUpdate = value;
        }

        public bool StateChangeOnItemSetUpdate
        {
            get => m_StateChangeOnItemSetUpdate;
            set => m_StateChangeOnItemSetUpdate = value;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="inventoryBridge">The inventory bridge.</param>
        public BridgeEquippableProcessing(CharacterInventoryBridge inventoryBridge)
        {
            m_EquipOnItemSetUpdate = true;
            m_StateChangeOnItemSetUpdate = true;
            m_InventoryBridge = inventoryBridge;
            m_CharacterGameobject = m_InventoryBridge.gameObject;
            m_PreviousActiveSets = new ActiveAndNextItemSetData(ItemSetManager.CategoryCount,ItemSetManager.SlotCount);

            m_RemovingFromItemSet = new List<CharacterItemInfo>();
            m_CurrentItemSet = new List<Item>();
            m_InventoryItemToCharacterItems = new Dictionary<Item, List<Items.Item>>();
            
            EventHandler.RegisterEvent<ItemInfo, ItemStack>(m_InventoryBridge.Inventory, 
                EventNames.c_Inventory_OnAdd_ItemInfo_ItemStack, OnAddItemToInventory);
            EventHandler.RegisterEvent<ItemInfo>(m_InventoryBridge.Inventory, 
                EventNames.c_Inventory_OnRemove_ItemInfo, OnRemoveItemFromInventory);
            EventHandler.RegisterEvent<Items.Item, int>(m_CharacterGameobject, 
                "OnAbilityUnequipItemComplete", OnUnequipItemComplete);
            EventHandler.RegisterEvent<Items.Item, int>(m_CharacterGameobject,
                "OnInventoryEquipItem", OnEquipItemComplete);
            EventHandler.RegisterEvent<Items.Item, int>(m_CharacterGameobject,
                "OnAbilityWillEquipItem", OnWillEquipItem);
            EventHandler.RegisterEvent<List<ItemSetStateInfo>>(m_CharacterGameobject,
                IntegrationEventNames.c_GameObject_ItemSetsWillUpdate_ListOfItemSetStateInfo, OnItemSetsWillUpdate);
        }

        /// <summary>
        /// An item was added to the equippable item colections.
        /// </summary>
        /// <param name="itemInfo">The item info.</param>
        /// <param name="addedItemStack">The added item stack.</param>
        /// <returns>The item info added.</returns>
        public ItemInfo OnItemAddedToEquippable(ItemInfo itemInfo, ItemStack addedItemStack)
        {
#if DEBUG_BRIDGE
            Debug.Log("Item was added to equippable: "+addedItemStack);
#endif
            //The item was already added if the amount added is smaller than the actual amount
            if (itemInfo.Amount < addedItemStack.Amount) {
                if (m_AboutToEquip.Item == itemInfo.Item) {
                    m_AboutToEquip = ItemInfo.None;
                }
                
                return ItemInfo.None;
            }

            //If the item is not equippable do nothing.
            if (m_InventoryBridge.EquippableCategory.InherentlyContains(itemInfo.Item) == false) {
                return itemInfo;
            }

            List<Items.Item> characterItems;
            if(m_InventoryItemToCharacterItems.TryGetValue(itemInfo.Item, out characterItems) == false)
            {
                characterItems = new List<Items.Item>();
                m_InventoryItemToCharacterItems.Add(itemInfo.Item, characterItems);
            }
            
            //Spawn the Item that is being added
            if (m_InventoryBridge.IsMultiItem(itemInfo.Item)) {
                //This is a multi Item

                var itemPrefabs = GetPrefabsAttributeValue(itemInfo.Item);
                if (itemPrefabs == null || itemPrefabs.Length == 0) {
                    Debug.LogError($"Error: Unable to get the item prefabs on item {itemInfo}.");
                    return ItemInfo.None;
                }
                
                for (int i = 0; i < itemPrefabs.Length; ++i) {
                    var itemPrefab = itemPrefabs[i];
                    var characterItem = CreateCharacterItem(itemInfo, itemPrefab);
                    if (characterItem == null) {
                        Debug.LogError($"Error: The item {itemInfo} has a \"{MultiItemPrefabsAttributeName}\" " +
                                       $"attribute which is null or is missing the Item component at index {i}.");
                        return ItemInfo.None;
                    }
                    //Add the item to the list first before adding it to the Inventory such that GetItem works.
                    characterItems.Add(characterItem);
                    m_InventoryBridge.AddItem(characterItem, false, false);
                }

            } else {
                
                //Single Item.
                var itemPrefab = GetPrefabAttributeValue(itemInfo.Item);
                var characterItem = CreateCharacterItem(itemInfo, itemPrefab);
                if (characterItem == null) {
                    Debug.LogError($"Error: The item {itemInfo} has a \"{PrefabAttributeName}\" " +
                                   $"attribute which is null or is missing the Item component.");
                    return ItemInfo.None;
                }
                //Add the item to the list first before adding it to the Inventory such that GetItem works.
                characterItems.Add(characterItem);
                m_InventoryBridge.AddItem(characterItem, false, false);
            }

            var isAboutToEquip = m_AboutToEquip.Item != null;
            
            UpdateItemSetItems(isAboutToEquip == false);

            if (m_AboutToEquip.Item == itemInfo.Item) {
                m_AboutToEquip = ItemInfo.None;
            } 
            return itemInfo;
        }

        /// <summary>
        /// Create a character item from an item info.
        /// </summary>
        /// <param name="itemInfo">The item info.</param>
        /// <param name="itemPrefab">The item prefab.</param>
        /// <returns>The instanced Character item.</returns>
        protected virtual Items.Item CreateCharacterItem(ItemInfo itemInfo, GameObject itemPrefab)
        {
            if (itemPrefab == null) {
                return null;
            }
                
            var characterItemPrefabComponent = itemPrefab.GetCachedComponent<Items.Item>();
                
            if (characterItemPrefabComponent == null) {
                return null;
            }

            return CreateCharacterItem(itemInfo, characterItemPrefabComponent);
        }

        /// <summary>
        /// Create the character item.
        /// </summary>
        /// <param name="itemInfo">The item info.</param>
        /// <param name="characterItemPrefabComponent">The character item prefab component.</param>
        /// <returns>The instanced character item.</returns>
        protected virtual Items.Item CreateCharacterItem(ItemInfo itemInfo, Items.Item characterItemPrefabComponent)
        {
            // Instantiate the item that will be added to the character.
            var characterItem = Items.Item.SpawnItem(m_CharacterGameobject, characterItemPrefabComponent);

            var itemObject = characterItem.GetComponent<ItemObject>();
            if (itemObject == null) { itemObject = characterItem.gameObject.AddComponent<ItemObject>(); }

            characterItem.ItemDefinition = itemInfo.Item.ItemDefinition;
            characterItem.ItemIdentifier = itemInfo.Item;
            itemObject.SetItem(itemInfo);

            return characterItem;
        }

        /// <summary>
        /// Get the prefab attribute value.
        /// </summary>
        /// <param name="item">The inventory item.</param>
        /// <returns>The prefab.</returns>
        public GameObject GetPrefabAttributeValue(Item item)
        {
            var itemGameObjectPrefabAttribute = item.GetAttribute<Attribute<GameObject>>(PrefabAttributeName);
            if (itemGameObjectPrefabAttribute == null) {
                Debug.LogError($"Error: The item {item} does not have the \"{PrefabAttributeName}\" attribute.");
                return null;
            }

            return itemGameObjectPrefabAttribute.GetValue();
        }

        /// <summary>
        /// Get the prefabs attribute value.
        /// </summary>
        /// <param name="item">The inventory item.</param>
        /// <returns>The prefabs array.</returns>
        public GameObject[] GetPrefabsAttributeValue(Item item)
        {
            var itemGameObjectPrefabsAttribute = item.GetAttribute<Attribute<GameObject[]>>(MultiItemPrefabsAttributeName);
            if (itemGameObjectPrefabsAttribute == null) {
                Debug.LogError($"Error: The item {item} does not have the \"{MultiItemPrefabsAttributeName}\" attribute.");
                return null;
            }

            return itemGameObjectPrefabsAttribute.GetValue();
        }
        
        /// <summary>
        /// An item will be equipped, force the Item Object to rebind.
        /// </summary>
        /// <param name="characterItem">The character item that will be equipped.</param>
        /// <param name="slotID">The item set Slot ID where the item will be equipped.</param>
        private void OnWillEquipItem(Items.Item characterItem, int slotID)
        {
            //Multi Items have many items bound, refresh the bindings such that the equipped item has priority.
            var itemObject = characterItem.gameObject.GetCachedComponent<ItemObject>();
            itemObject.ForceChangeEvent();
        }
        
        /// <summary>
        /// The item finished equipping.
        /// </summary>
        /// <param name="characterItem">The character item.</param>
        /// <param name="slotID">The item set slot ID.</param>
        protected virtual void OnEquipItemComplete(Items.Item characterItem, int slotID)
        {
            //Update the Inventory after the Item Set changes to force update the UI and other things.
            m_InventoryBridge.Inventory.UpdateInventory(false);
        }

        /// <summary>
        /// An inventory item was removed from the equippable item collection.
        /// </summary>
        /// <param name="itemInfo">The item info.</param>
        /// <param name="immediateRemove">Immediatly remove the item?</param>
        private void OnItemRemovedFromEquippable(ItemInfo itemInfo, bool immediateRemove = false)
        {
#if DEBUG_BRIDGE
            Debug.Log("Item was removed from equippable: "+itemInfo);
#endif
            //If not all the item amount was removed, the character item should not be removed.
            if(itemInfo.ItemStack.Amount > 0){ return; }

            //Get the character item before it is removed.
            //There can be multiple character items for the same items when using multi items.
            if (m_InventoryItemToCharacterItems.TryGetValue(itemInfo.Item, out var characterItems) == false) {
                Debug.LogWarning("The item you are trying to remove does not have Character Items.");
                return;
            }

            var isDropping = m_AboutToDropItemInfo.Item == itemInfo.Item;
            var skipUnequip = immediateRemove || isDropping;
            
            if (isDropping) {
                m_AboutToDropItemInfo = ItemInfo.None;
            }
            
            m_PreviousActiveSets.RecordSets(ItemSetManager, false);

            //Unequip the items if necessary.
            for (int i = characterItems.Count - 1; i >= 0; i--) {
                var characterItem = characterItems[i];

                m_RemovingFromItemSet.Add(new CharacterItemInfo(characterItem, itemInfo));

                UnequipIfActive(characterItem, false);
            }
            
            //Once the items are being unequipped start removing them. Reverse loop as items are removed.
            for (int i = characterItems.Count - 1; i >= 0; i--) {
                //Fail safe in case two items are removed in one unequip
                if( i >= characterItems.Count){ continue; }
                
                var characterItem = characterItems[i];
                var slotID = characterItem.SlotID;

                var active = characterItem.IsActive();
                var activeItem = m_InventoryBridge.GetActiveItem(slotID); 
                var itemIsActive = active && activeItem == characterItem;

                if (skipUnequip || itemIsActive == false) {
                    OnUnequipItemComplete(characterItem, slotID);
                }
            }
        }

        /// <summary>
        /// Unequip the item if it is active.
        /// </summary>
        /// <param name="characterItem">The character item to unequip.</param>
        /// <param name="immediate">Immediatly unequip if active?</param>
        private void UnequipIfActive(Items.Item characterItem, bool immediate)
        {
            var slotID = characterItem.SlotID;
            var itemIsActive = characterItem.IsActive() && m_InventoryBridge.GetActiveItem(slotID) == characterItem;

            if (!itemIsActive) { return; }

            for (int categoryIndex = 0; categoryIndex < ItemSetManager.CategoryItemSets.Length; categoryIndex++) {
                var activeIndex = ItemSetManager.ActiveItemSetIndex[categoryIndex];
                if (activeIndex == -1) { continue; }

                var nextIndex = ItemSetManager.GetItemSetIndexExcludingItem(categoryIndex, activeIndex,
                    characterItem.ItemIdentifier);

                if (nextIndex == activeIndex) { continue; }

                
#if DEBUG_BRIDGE
                Debug.Log($"{categoryIndex}: Unequip {activeIndex} to equip {nextIndex}");
#endif
                m_InventoryBridge.Equip(categoryIndex, nextIndex, true, immediate);
            }
        }

        /// <summary>
        /// The item finished unequipping.
        /// </summary>
        /// <param name="characterItem">The character item that was unequipped.</param>
        /// <param name="slotID">The slot ID it was unequipped from.</param>
        private void OnUnequipItemComplete(Items.Item characterItem, int slotID)
        {
            var removeSlotIndex= GetRemovingIndexOf(characterItem);
            if (removeSlotIndex == -1) {
                return;
            }

            var characterItemInfo = m_RemovingFromItemSet[removeSlotIndex];
            m_RemovingFromItemSet.RemoveAt(removeSlotIndex);

            var inventoryItem = characterItemInfo.ItemInfo.Item;
            
            // Unbind the item before it is removed from the inventory. Such that the ammo and other properties can be saved in attributes using bindings.
            var itemObject = characterItem.gameObject.GetCachedComponent<ItemObject>();
            itemObject.SetItem(null);
            
            int totalCharacterItems = 1;
            if (m_InventoryBridge.IsMultiItem(inventoryItem)) {
                totalCharacterItems = GetPrefabsAttributeValue(inventoryItem)?.Length ?? 1;
            }
            
            // Keep track of the previously equipped items such that they can be re-equipped.
            if (m_InventoryItemToCharacterItems[inventoryItem].Count == totalCharacterItems) {
                m_PreviousActiveSets.RecordSets(ItemSetManager, true);
            }

            m_InventoryBridge.BaseRemoveItem(inventoryItem, slotID, characterItemInfo.ItemInfo.Amount, false);

            // Do this only for the first character Item being removed.
            if (m_InventoryItemToCharacterItems[inventoryItem].Count == 1) {
                var isAboutToEquip = m_AboutToEquip.Item != null;
                UpdateItemSetItems(isAboutToEquip == false);
            }
            
            m_InventoryItemToCharacterItems[inventoryItem].Remove(characterItem);
            // Completely remove the item.
            Items.Item.ResetInitialization(characterItem);

            // Update the Inventory after the Item Set changes to force update the UI and other things.
            m_InventoryBridge.Inventory.UpdateInventory(false);
        }

        /// <summary>
        /// Update the item set items.
        /// </summary>
        /// <param name="equip">Should an item be equipped once the update is done?</param>
        public virtual void UpdateItemSetItems(bool equip)
        {
            m_CurrentItemSet.Clear();

            var equippableItemStacks = EquippableItemCollections.GetAllItemStacks();
            for (int i = 0; i < equippableItemStacks.Count; i++) {
                if(equippableItemStacks[i] == null){continue;}

                m_CurrentItemSet.Add(equippableItemStacks[i].Item);
            }

            for (int i = 0; i < m_RemovingFromItemSet.Count; i++) {
                m_CurrentItemSet.Add(m_RemovingFromItemSet[i].ItemInfo.Item);
            }

            //Keep track of the previously equipped items such that they can be re-equipped.
            m_PreviousActiveSets.RecordSets(ItemSetManager, true);

            // Add the ItemSet before the item so the item can use the added ItemSet.
            ItemSetManager.UpdateItemSets(m_CurrentItemSet);
            
            //Equip items.
            if (m_EquipOnItemSetUpdate && equip) {
                var allowedSlotsLayerMask = int.MaxValue;
                for (int i = 0; i < ItemSetManager.CategoryItemSets.Length; i++) {
                    var categoryIndex = i;
                    ReEquipItems(categoryIndex, ref allowedSlotsLayerMask);
                }
            }

            //Reset the previous active sets.
            m_PreviousActiveSets.Reset();

            if (m_StateChangeOnItemSetUpdate) {
                //This is required in cases where items are being equipped in parallel.
                ItemSetManager.StateChange();
            }
        }
        
        /// <summary>
        /// Just before the item sets will be update, make sure the active item set won't be removed.
        /// </summary>
        /// <param name="itemSetStateInfos">The item set state infos.</param>
        private void OnItemSetsWillUpdate(List<ItemSetStateInfo> itemSetStateInfos)
        {
            for (int i = 0; i < itemSetStateInfos.Count; i++) {
                var itemSetStateInfo = itemSetStateInfos[i];
                
                if (itemSetStateInfo.State == ItemSetStateInfo.SetState.Remove) {
                    var categoryIndex = itemSetStateInfo.RuleInfo.CategoryIndex;
                    var nextItemSet = ItemSetManager.GetNextItemSet(categoryIndex);

                    // An Item Set which will become active is about to be removed. Force unequip it, to prevent it.
                    if (nextItemSet == itemSetStateInfo.ItemSet) {
                        m_InventoryBridge.Equip(categoryIndex, -1, true, true);
                    }
                }
            }
        }

        /// <summary>
        /// Reequip the items if possible.
        /// </summary>
        /// <param name="categoryIndex">The category index.</param>
        /// <param name="allowedSlotsLayerMask">The allowed slots layer mask.</param>
        protected virtual void ReEquipItems(int categoryIndex, ref int allowedSlotsLayerMask)
        {
            //An item is already equipped in the slot.
            if(ItemSetManager.ActiveItemSetIndex[categoryIndex] != -1){ return; }
            
            var previousItemSet = m_PreviousActiveSets.Active.Data[categoryIndex];
            
            //TODO is this even necessary now that the item sets aren't removed when updated? Maybe not...
            //TODO Actually for some cases it's useful (i.e swordshield -> equip new sword) but maybe it should be implemented slightly differently
            //TODO Perhaps by doing similar checks within the the InventoryItemSetManager... to investigate.
/*
            //Try to equip the perfect match.
            var perfectMatchIndex = m_PreviousActiveSets.Active.GetMatchIndex(categoryIndex, previousItemSet,ItemSetManager);
            if (EquipIfValid(categoryIndex, perfectMatchIndex, true, ref allowedSlotsLayerMask)) { return; }

            //Equip back the items if they still exist.
            var itemSetIndex = -1;
            var differentSlotItemSetIndex = -1;
            for (int j = 0; j < m_InventoryBridge.SlotCount; j++) {
                var previousActiveItem = previousItemSet.Items[j];

                if (previousActiveItem == null) { continue; }

                itemSetIndex = ItemSetManager.GetItemSetIndexFor(categoryIndex, previousActiveItem, j);

                if (differentSlotItemSetIndex == -1) {
                    differentSlotItemSetIndex = ItemSetManager.GetItemSetIndexFor(categoryIndex, previousActiveItem);
                }

                if (itemSetIndex != -1) { break; }
            }

            //Re-equip the previous item.
            if (EquipIfValid(categoryIndex, itemSetIndex, false, ref allowedSlotsLayerMask)) { return; }

            //Perhaps the item is in another slot (example pistol left hand/right hand)
            if (EquipIfValid(categoryIndex, differentSlotItemSetIndex, false, ref allowedSlotsLayerMask)) { return; }
*/
            if (ItemSetManager.ActiveItemSetIndex[categoryIndex] == -1) {

                //Equip a new item not immediate
                var itemSetIndex = ItemSetManager.GetNextOrDefaultItemSetIndex(categoryIndex, previousItemSet.Index, allowedSlotsLayerMask);
                if (itemSetIndex == -1) {
                    itemSetIndex = ItemSetManager.GetTargetItemSetIndex(categoryIndex, allowedSlotsLayerMask);
                }
                //Debug.Log($"Try Equip next item: category {categoryIndex}, item set index {itemSetIndex}");
                if (EquipIfValid(categoryIndex, itemSetIndex, false, ref allowedSlotsLayerMask)) { return; }
            }
        }

        /// <summary>
        /// Equip if valid.
        /// </summary>
        /// <param name="categoryIndex">The category index.</param>
        /// <param name="itemSetIndex">The item set index.</param>
        /// <param name="immediate">Immediatly equip.</param>
        /// <param name="allowedSlotsLayerMask">The allowed slots layer mask.</param>
        /// <returns>True if the item was valid and equipped.</returns>
        private bool EquipIfValid(int categoryIndex, int itemSetIndex, bool immediate, ref int allowedSlotsLayerMask)
        {
            if (itemSetIndex == -1) { return false; }
            
            if (ItemSetManager.IsItemSetValid(categoryIndex, itemSetIndex, false, allowedSlotsLayerMask)) {
                allowedSlotsLayerMask = UpdateLayerMask(allowedSlotsLayerMask, categoryIndex, itemSetIndex, true);
                m_InventoryBridge.Equip(categoryIndex, itemSetIndex, immediate, immediate);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Update the layer mask.
        /// </summary>
        /// <param name="slotLayerMask">The layer mask.</param>
        /// <param name="categoryIndex">The category index.</param>
        /// <param name="itemSetIndex">The item set index.</param>
        /// <param name="remove">Should it be added or removed?</param>
        /// <returns>The new layer mask.</returns>
        private int UpdateLayerMask(int slotLayerMask, int categoryIndex, int itemSetIndex, bool remove)
        {
            if (itemSetIndex == -1) {
                return slotLayerMask;
            }
            
            var itemSet = 
                ItemSetManager.CategoryItemSets[categoryIndex].ItemSetList[itemSetIndex];

            for (int i = 0; i < itemSet.ItemIdentifiers.Length; i++) {
                if (remove && MathUtility.InLayerMask(i, slotLayerMask) && itemSet.ItemIdentifiers[i] != null) {
                    slotLayerMask -= 1 << i;
                }
                
                if (!remove && !MathUtility.InLayerMask(i, slotLayerMask) && itemSet.ItemIdentifiers[i] != null) {
                    slotLayerMask += 1 << i;
                }
            }

            return slotLayerMask;
        }

        /// <summary>
        /// Is the item being unequipped.
        /// </summary>
        /// <param name="item">The inventory item.</param>
        /// <returns>True if it is being unequipped.</returns>
        public bool IsItemBeingUnequipped(Item item)
        {
            for (int i = 0; i < m_RemovingFromItemSet.Count; i++) {
                if (m_RemovingFromItemSet[i].ItemInfo.Item == item) {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Get the removing index of the item info.
        /// </summary>
        /// <param name="itemInfo">The item info.</param>
        /// <returns>The index</returns>
        public int GetRemovingIndexOf(ItemInfo itemInfo)
        {
            return GetRemovingIndexOf(itemInfo.Item);
        }
        
        /// <summary>
        /// Get the removing index of the item info.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>The index</returns>
        public int GetRemovingIndexOf(Item item)
        {
            for (int i = 0; i < m_RemovingFromItemSet.Count; i++) {
                if (m_RemovingFromItemSet[i].ItemInfo.Item == item) {
                    return i;
                }
            }
            return -1;
        }
        
        /// <summary>
        /// Get the removing index of the item info.
        /// </summary>
        /// <param name="characterItem">The item.</param>
        /// <returns>The index</returns>
        public int GetRemovingIndexOf(Items.Item characterItem)
        {
            for (int i = 0; i < m_RemovingFromItemSet.Count; i++) {
                if (m_RemovingFromItemSet[i].CharacterItem == characterItem) {
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// Is the item Equippable?
        /// </summary>
        /// <param name="characterItem">The item.</param>
        /// <returns>True if it can be equipped.</returns>
        public bool IsItemEquippable(Items.Item characterItem)
        {
            var itemStacks = EquippableItemCollections.GetAllItemStacks();
            for (int i = 0; i < itemStacks.Count; i++) {
                var inventoryItem = itemStacks[i]?.Item;
                if(inventoryItem == null){ continue; }
                
                //Check if the item has the bound inventoryItem
                if (inventoryItem == characterItem.GetComponent<ItemObject>()?.Item) {
                    return true;
                }

                //Sometimes the item is not bound yet but it is equipping.
                //Check that the Item Prefab matches the item.
                if (m_InventoryBridge.IsMultiItem(inventoryItem)) {
                    //Multi Item
                    
                    var itemPrefabs = GetPrefabsAttributeValue(inventoryItem);
                    if(itemPrefabs == null || itemPrefabs.Length == 0){continue;}

                    for (int j = 0; j < itemPrefabs.Length; j++) {
                        var itemPrefab = itemPrefabs[j];
                        if (itemPrefab != null && ObjectPool.GetOriginalObject(characterItem.gameObject) == itemPrefab) {
                            return true;
                        }
                    }
                    
                } else {
                    //Single Item
                    
                    var itemPrefab = GetPrefabAttributeValue(inventoryItem);
                    if (itemPrefab != null && ObjectPool.GetOriginalObject(characterItem.gameObject) == itemPrefab) {
                        return true;
                    }
                }
                
            }

            return false;
        }

        /// <summary>
        /// Initialize the item restriction.
        /// </summary>
        /// <param name="inventory">The inventory.</param>
        /// <param name="force">Force initialize?</param>
        void IItemRestriction.Initialize(IInventory inventory, bool force)
        {
        }

        /// <summary>
        /// Condition when adding an item?
        /// </summary>
        /// <param name="itemInfo">The item info.</param>
        /// <param name="receivingCollection">The receiving collection.</param>
        /// <returns>The item info to add.</returns>
        ItemInfo? IItemRestriction.CanAddItem(ItemInfo itemInfo, ItemCollection receivingCollection)
        {
            if (!EquippableItemCollections.Contains(receivingCollection)) {
                return itemInfo;
            }

            if (m_InventoryBridge.EquippableCategory.InherentlyContains(itemInfo.Item) == false) {

                if (m_InventoryBridge.AllowNonEquippableItemsInEquippableCollections == false) {
                    Debug.LogWarning($"{itemInfo} is a non equippable item it cannot be added to the item set manager.", m_InventoryBridge);
                    return null;
                }
                    
                return itemInfo;
            }
                
            for (int i = m_RemovingFromItemSet.Count - 1; i >= 0; i--) {
                //Fail safe in case two items are removed in one unequip
                if( i >= m_RemovingFromItemSet.Count){ continue; }
                    
                var characterItemInfo = m_RemovingFromItemSet[i];
                    
                //If adding an item that is unequipped force unequip it.
                if (characterItemInfo.ItemInfo.Item == itemInfo.Item) {
                        
                    //Force remove the item such that it can be equipped
                    UnequipIfActive(characterItemInfo.CharacterItem, true);
                }
            }

            return itemInfo;
        }

        /// <summary>
        /// Remove condition.
        /// </summary>
        /// <param name="itemInfo">The item info.</param>
        /// <returns>The item to remove.</returns>
        ItemInfo? IItemRestriction.CanRemoveItem(ItemInfo itemInfo)
        {
            return itemInfo;
        }
        
        /// <summary>
        /// An Item has been added to the Default ItemCollection.
        /// </summary>
        /// <param name="itemInfo">The info that describes hte item.</param>
        /// <param name="addedItemStack">The ItemCollection that the item was added to.</param>
        private void OnAddItemToInventory(ItemInfo itemInfo, ItemStack addedItemStack)
        {
            if(addedItemStack == null){ return; }

            var originItemCollection = itemInfo.ItemCollection;
            var destinationItemCollection = addedItemStack.ItemCollection;

            //The item was added to the equipped items.
            if (EquippableItemCollections.Contains(destinationItemCollection)) {
                OnItemAddedToEquippable(itemInfo, addedItemStack);
                return;
            }
        }
        
        /// <summary>
        /// Remove an item from the inventory.
        /// </summary>
        /// <param name="itemInfoRemoved">The item info to remove.</param>
        private void OnRemoveItemFromInventory(ItemInfo itemInfoRemoved)
        {
#if DEBUG_BRIDGE
            Debug.Log("Removed Item from inventory "+itemInfoRemoved);
#endif
            //The item was added to the equipped items.
            if (EquippableItemCollections.Contains(itemInfoRemoved.ItemCollection)) {
                OnItemRemovedFromEquippable(itemInfoRemoved);
                return;
            }
        }

        /// <summary>
        /// The item specified is about to be dropped.
        /// </summary>
        /// <param name="itemInfo">The item info.</param>
        public void AboutToDrop(ItemInfo itemInfo)
        {
            m_AboutToDropItemInfo = itemInfo;
        }
        
        /// <summary>
        /// The item specified is about to be equipped.
        /// </summary>
        /// <param name="itemInfo">The item info.</param>
        public void AboutToEquip(ItemInfo itemInfo)
        {
            m_AboutToEquip = itemInfo;
        }

        /// <summary>
        /// Load the default loadout.
        /// </summary>
        public void LoadDefaultLoadout()
        {
            for (int i = 0; i < EquippableItemCollections.GetItemCollectionCount(); i++) {
                var equipppableItemCollection = EquippableItemCollections.GetItemCollection(i);

                var itemStacks = equipppableItemCollection.GetAllItemStacks();

                for (int j = 0; j < itemStacks.Count; j++) {
                    var itemStack = itemStacks[j];
                    //The origin is from nowhere in particular.
                    var itemInfo = new ItemInfo(itemStack.ItemAmount);
                    OnItemAddedToEquippable(itemInfo, itemStack);
                }
            }
        }

        /// <summary>
        /// Remove the event listeners.
        /// </summary>
        public void Destroy()
        {
            EventHandler.UnregisterEvent<ItemInfo, ItemStack>(m_InventoryBridge.Inventory, 
                EventNames.c_Inventory_OnAdd_ItemInfo_ItemStack, OnAddItemToInventory);
            EventHandler.UnregisterEvent<ItemInfo>(m_InventoryBridge.Inventory, 
                EventNames.c_Inventory_OnRemove_ItemInfo, OnRemoveItemFromInventory);
            EventHandler.UnregisterEvent<Items.Item, int>(m_CharacterGameobject, 
                "OnAbilityUnequipItemComplete", OnUnequipItemComplete);
            EventHandler.UnregisterEvent<List<ItemSetStateInfo>>(m_CharacterGameobject,
                IntegrationEventNames.c_GameObject_ItemSetsWillUpdate_ListOfItemSetStateInfo, OnItemSetsWillUpdate);
        }
    }
}