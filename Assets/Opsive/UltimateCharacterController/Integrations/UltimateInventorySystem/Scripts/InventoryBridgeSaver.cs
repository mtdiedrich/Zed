/// ---------------------------------------------
/// Ultimate Inventory System
/// Copyright (c) Opsive. All Rights Reserved.
/// https://www.opsive.com
/// ---------------------------------------------

namespace Opsive.UltimateCharacterController.Integrations.UltimateInventorySystem
{
    using Opsive.Shared.Events;
    using Opsive.Shared.Game;
    using Opsive.Shared.Utility;
    using Opsive.UltimateCharacterController.Inventory;
    using Opsive.UltimateCharacterController.Items.Actions;
    using Opsive.UltimateInventorySystem.Core;
    using Opsive.UltimateInventorySystem.Core.AttributeSystem;
    using Opsive.UltimateInventorySystem.Core.DataStructures;
    using Opsive.UltimateInventorySystem.Core.InventoryCollections;
    using Opsive.UltimateInventorySystem.SaveSystem;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using Inventory = Opsive.UltimateInventorySystem.Core.InventoryCollections.Inventory;

    /// <summary>
    /// A saver component that saves the content of an inventory.
    /// </summary>
    public class InventoryBridgeSaver : SaverBase
    {
        /// <summary>
        /// The inventory save data.
        /// </summary>
        [System.Serializable]
        public struct InventoryBridgeSaveData
        {
            public IDAmountSaveData[][] ItemIDAmountsPerCollection;
            public UltimateCharacterController.Inventory.CategoryItemSet[] CategoryItemSets;
            public int[] ActiveItemSets;
        }

        private Character.UltimateCharacterLocomotion m_CharacterLocomotion;
        private Inventory m_Inventory;
        private InventoryItemSetManager m_ItemSetManager;
        private CharacterInventoryBridge m_InventoryBridge;

        /// <summary>
        /// Initialize the component.
        /// </summary>
        protected override void Awake()
        {
            m_CharacterLocomotion = gameObject.GetCachedComponent<Character.UltimateCharacterLocomotion>();
            m_Inventory = gameObject.GetCachedComponent<Inventory>();
            m_ItemSetManager = gameObject.GetCachedComponent<InventoryItemSetManager>();
            m_InventoryBridge = gameObject.GetCachedComponent<CharacterInventoryBridge>();
            
            EventHandler.RegisterEvent<int>(EventNames.c_WillStartLoadingSave_Index, OnWillStartLoading);

            base.Awake();
        }

        /// <summary>
        /// Serialize the save data.
        /// </summary>
        /// <returns>The serialized data.</returns>
        public override Serialization SerializeSaveData()
        {
            if (m_Inventory == null) { return null; }
            var itemCollectionCount = m_Inventory.GetItemCollectionCount();
            var newItemAmountsArray = new IDAmountSaveData[itemCollectionCount][];
            var listItemIDs = new List<uint>();

            for (int i = 0; i < itemCollectionCount; i++) {
                var itemCollection = m_Inventory.GetItemCollection(i);
                if (itemCollection.Purpose == ItemCollectionPurpose.Loadout) {
                    continue;
                }

                var allItemAmounts = itemCollection.GetAllItemStacks();
                var itemAmounts = new IDAmountSaveData[allItemAmounts.Count];
                for (int j = 0; j < itemAmounts.Length; j++) {
                    var itemAmount = allItemAmounts[j];
                    listItemIDs.Add(itemAmount.Item.ID);

                    itemAmounts[j] = new IDAmountSaveData() {
                        ID = itemAmount.Item.ID,
                        Amount = itemAmount.Amount
                    };
                }
                
                newItemAmountsArray[i] = itemAmounts;
            }
            
            SaveSystemManager.InventorySystemManagerItemSaver.SetItemsToSave(FullKey, listItemIDs);
            
            //Save only part of the category Item Set. Item Sets created by the Item Set Rules don't need to be saved.
            var categoryItemSetsToSave = new CategoryItemSet[m_ItemSetManager.CategoryItemSets.Length];
            for (int i = 0; i < m_ItemSetManager.CategoryItemSets.Length; i++) {

                var categoryItemSet = m_ItemSetManager.CategoryItemSets[i];
                categoryItemSetsToSave[i] = new CategoryItemSet(
                    categoryItemSet.CategoryID,
                    categoryItemSet.CategoryName,
                    categoryItemSet.ItemCategory);
                
                var itemSetList = new List<ItemSet>();
                for (int j = 0; j < categoryItemSet.ItemSetList.Count; j++) {
                    var itemSet = categoryItemSet.ItemSetList[j];
                    //Don't save ItemSets which are ignored.
                    if (m_ItemSetManager.IgnoreItemSetOnAddItem(itemSet)) {
                        continue;
                    }
                    itemSetList.Add(itemSet);
                }

                categoryItemSetsToSave[i].ItemSetList = itemSetList;
            }

            var saveData = new InventoryBridgeSaveData {
                ItemIDAmountsPerCollection = newItemAmountsArray,
                CategoryItemSets = categoryItemSetsToSave,
                ActiveItemSets = m_ItemSetManager.ActiveItemSetIndex
            };

            return Serialization.Serialize(saveData);
        }

        private void OnWillStartLoading(int saveIndex)
        {
            //Items Need to be unequipped and removed before the items are loaded from the save data otherwise
            //Item Object bound attribute values might be updated when unequipping item after they were loaded from save.
            
            m_InventoryBridge.OnWillLoadSaveData();
            EventHandler.ExecuteEvent(gameObject, IntegrationEventNames.c_GameObject_OnInventoryBridgeSaverWillLoad);
            
            //Unequip everything first.
            var categoryCounts = m_ItemSetManager.CategoryCount;
            for (int i = 0; i < categoryCounts; i++) {
                m_InventoryBridge.Equip(i,-1,true,true);
            }
            
            // The previous inventory should be cleared.
            var itemCollectionCount = m_Inventory.GetItemCollectionCount();
            for (int i = 0; i < itemCollectionCount; i++) {
                var itemCollection = m_Inventory.GetItemCollection(i);
                if (itemCollection.Purpose == ItemCollectionPurpose.Loadout) {
                    continue;
                }
                itemCollection.RemoveAll();
            }
            m_InventoryBridge.RemoveAllItems(false);
        }
        
        /// <summary>
        /// Deserialize and load the save data.
        /// </summary>
        /// <param name="serializedSaveData">The serialized save data.</param>
        public override void DeserializeAndLoadSaveData(Serialization serializedSaveData)
        {
            if (m_Inventory == null) { return; }

            var savedData = serializedSaveData.DeserializeFields(MemberVisibility.All) as InventoryBridgeSaveData?;
            if (savedData.HasValue == false) {
                return;
            }

            var inventorySaveData = savedData.Value;
            if (inventorySaveData.ItemIDAmountsPerCollection == null) { return; }
            
            EventHandler.ExecuteEvent(m_Inventory.gameObject, EventNames.c_InventoryGameObject_InventoryMonitorListen_Bool, false);

            // Restore the ItemSets. This should be done before adding any items so the ItemSets are correct.
            m_ItemSetManager.CopyFrom(inventorySaveData.CategoryItemSets);

            // Restore the items.
            for (int i = 0; i < inventorySaveData.ItemIDAmountsPerCollection.Length; i++) {
                var itemCollection = m_Inventory.GetItemCollection(i);
                if (itemCollection == null) {
                    Debug.LogWarning("Item Collection from save data is missing in the scene.");
                    continue;
                }

                // The Loadout should not be restored as it stays constant.
                if (itemCollection.Purpose == ItemCollectionPurpose.Loadout) {
                    continue;
                }

                var itemIDAmounts = inventorySaveData.ItemIDAmountsPerCollection[i];
                var itemAmounts = new ItemAmount[itemIDAmounts.Length];
                for (int j = 0; j < itemIDAmounts.Length; j++) {
                    if (InventorySystemManager.ItemRegister.TryGetValue(itemIDAmounts[j].ID, out var item) == false) {
                        Debug.LogWarning($"Saved Item ID {itemIDAmounts[j].ID} could not be retrieved from the Inventory System Manager.");
                        continue;
                    }

                    itemAmounts[j] = new ItemAmount(item, itemIDAmounts[j].Amount);
                }
                
                itemCollection.AddItems(itemAmounts);
            }
            
            EventHandler.ExecuteEvent(m_Inventory.gameObject, EventNames.c_InventoryGameObject_InventoryMonitorListen_Bool, true);


            //Wait for a frame such that the start function of items can get called.
            StartCoroutine(EquipItemNextFrame(inventorySaveData));
        }

        private IEnumerator EquipItemNextFrame(InventoryBridgeSaveData inventorySaveData)
        {
            //Wait a frame
            yield return null;
            
            // Restore the active ItemSets.
            if (inventorySaveData.ActiveItemSets != null && inventorySaveData.ActiveItemSets.Length > 0) {
                for (int i = 0; i < inventorySaveData.ActiveItemSets.Length; i++) {
                    m_InventoryBridge.Equip(i,inventorySaveData.ActiveItemSets[i],true,true);
                }
            }
            
            //Send event that the bridge finished
            m_InventoryBridge.OnSaveDataLoaded();
            EventHandler.ExecuteEvent(gameObject, IntegrationEventNames.c_GameObject_OnInventoryBridgeSaverLoaded);
        }

        /// <summary>
        /// Unregister events on destroy.
        /// </summary>
        protected override void OnDestroy()
        {
            base.OnDestroy();
            EventHandler.UnregisterEvent<int>(EventNames.c_WillStartLoadingSave_Index, OnWillStartLoading);
        }
    }
}