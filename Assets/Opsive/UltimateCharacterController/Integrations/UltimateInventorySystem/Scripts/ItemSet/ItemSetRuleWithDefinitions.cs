/// ---------------------------------------------
/// Ultimate Character Controller
/// Copyright (c) Opsive. All Rights Reserved.
/// https://www.opsive.com
/// ---------------------------------------------

namespace Opsive.UltimateCharacterController.Integrations.UltimateInventorySystem
{
    using Opsive.Shared.Utility;
    using Opsive.UltimateCharacterController.Inventory;
    using Opsive.UltimateInventorySystem.Core;
    using Opsive.UltimateInventorySystem.Storage;
    using System;
    using System.Collections.Generic;
    using UnityEngine;

    [Serializable]
    public class ItemSetRuleWithDefinitions : ItemSetRule
    {
        [Tooltip("The Item Definitions that occupy the inventory slots.")]
        [SerializeField] protected DynamicItemDefinitionArray m_ItemDefinitionsSlots;

        [Shared.Utility.NonSerialized] public DynamicItemDefinitionArray ItemDefinitionSlots { get { return m_ItemDefinitionsSlots; } set { m_ItemDefinitionsSlots = value; } }

        public override void SetSlotCount(int slotCount)
        {
            if (m_ItemDefinitionsSlots.Count == slotCount) { return; }

            var array = m_ItemDefinitionsSlots.Value;
            Array.Resize(ref array, slotCount);
            m_ItemDefinitionsSlots = new DynamicItemDefinitionArray(array);
        }

        public override bool DoesItemMatchRule(Item item)
        {
            var foundMatch = false;
            var emptySet = true;
            for (int k = 0; k < m_ItemDefinitionsSlots.Count; k++) {
                var itemCategory = m_ItemDefinitionsSlots.Value[k];
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
            for (int k = 0; k < m_ItemDefinitionsSlots.Count; k++) {
                if (database.Contains(m_ItemDefinitionsSlots.Value[k]) == false) {
                    return false;
                }
            }

            return true;
        }

        public override ModifiedObjectWithDatabaseObjects
            ReplaceInventoryObjectsBySelectedDatabaseEquivalents(InventorySystemDatabase database)
        {
            var itemDefinitions = m_ItemDefinitionsSlots.Value;
            for (int k = 0; k < itemDefinitions.Length; k++) {
                if (database.Contains(itemDefinitions[k]) == false) {
                    itemDefinitions[k] = database.FindSimilar(itemDefinitions[k]);
                }
            }
                    
            m_ItemDefinitionsSlots = new DynamicItemDefinitionArray(itemDefinitions);
            return null;
        }

        public override ListSlice<ItemSet> GetItemSetsFor(ListSlice<Item> items)
        {
            //Check that the itemcategories can all be part of items.
            var itemCategories = m_ItemDefinitionsSlots.Value;
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

            var slotCount = m_ItemDefinitionsSlots.Value.Length;
            var result = GetItemSetsFor(slotCount, itemPermutations);

            GenericObjectPool.Return(pooledList);

            return result;
        }
    }
}