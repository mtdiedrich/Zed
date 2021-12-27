/// ---------------------------------------------
/// Ultimate Character Controller
/// Copyright (c) Opsive. All Rights Reserved.
/// https://www.opsive.com
/// ---------------------------------------------

namespace Opsive.UltimateCharacterController.Integrations.UltimateInventorySystem
{
    using Opsive.Shared.Utility;
    using Opsive.UltimateCharacterController.Inventory;
    using Opsive.UltimateCharacterController.StateSystem;
    using Opsive.UltimateInventorySystem.Core;
    using Opsive.UltimateInventorySystem.Storage;
    using System;
    using System.Collections.Generic;
    using UnityEngine;
    
    [Serializable]
    public class ItemSetRuleWithCategories : ItemSetRule
    {
        [Tooltip("The Item Definitions that occupy the inventory slots.")]
        [SerializeField] protected DynamicItemCategoryArray m_ItemCategorySlots;

        [Shared.Utility.NonSerialized] public ItemCategory[] ItemCategorySlots { get { return m_ItemCategorySlots; } set { m_ItemCategorySlots = value; } }

        public override void SetSlotCount(int slotCount)
        {
            if (m_ItemCategorySlots.Count == slotCount) { return; }

            var array = m_ItemCategorySlots.Value;
            if (array != null) {
                Array.Resize(ref array, slotCount);
            } else {
                array = new ItemCategory[slotCount];
            }
            
            m_ItemCategorySlots = new DynamicItemCategoryArray(array);
        }

        public override bool DoesItemMatchRule(Item item)
        {
            var foundMatch = false;
            var emptySet = true;
            for (int k = 0; k < m_ItemCategorySlots.Count; k++) {
                var itemCategory = m_ItemCategorySlots.Value[k];
                if(itemCategory == null){ continue; }

                emptySet = false;
                if (itemCategory.InherentlyContains(item)) {
                    foundMatch = true;
                    break;
                }
            }

            return emptySet || foundMatch;
        }

        public override bool IsComponentValidForDatabase(InventorySystemDatabase database)
        {
            for (int k = 0; k < m_ItemCategorySlots.Count; k++) {
                if (database.Contains(m_ItemCategorySlots.Value[k]) == false) {
                    return false;
                }
            }

            return true;
        }

        public override ModifiedObjectWithDatabaseObjects
            ReplaceInventoryObjectsBySelectedDatabaseEquivalents(InventorySystemDatabase database)
        {
            var itemCategories = m_ItemCategorySlots.Value;
            for (int k = 0; k < itemCategories.Length; k++) {
                if (database.Contains(itemCategories[k]) == false) {
                    itemCategories[k] = database.FindSimilar(itemCategories[k]);
                }
            }
                    
            m_ItemCategorySlots = new DynamicItemCategoryArray(itemCategories);
            return null;
        }

        public override ListSlice<ItemSet> GetItemSetsFor(ListSlice<Item> items)
        {
            //Check that the itemcategories can all be part of items.
            var itemCategories = m_ItemCategorySlots.Value;
            for (int i = 0; i < itemCategories.Length; i++) {
                if(itemCategories[i] == null){continue;}

                var match = false;
                for (int j = 0; j < items.Count; j++) {
                    if(items[j] == null){ continue; }
                    if (itemCategories[i].InherentlyContains(items[j])) {
                        match = true;
                    }
                }

                if (match == false) {
                    return (null, 0, 0);
                }
            }

            var pooledList = GenericObjectPool.Get<List<Item[]>>();
            pooledList.Clear();
            var itemPermutations = InventorySystemItemSetUtility.GetAllSlotPermutations(itemCategories, items, pooledList);

            var slotCount = m_ItemCategorySlots.Value.Length;
            var result = GetItemSetsFor(slotCount, itemPermutations);

            GenericObjectPool.Return(pooledList);

            return result;
        }
    }
}