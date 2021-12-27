/// ---------------------------------------------
/// Ultimate Character Controller
/// Copyright (c) Opsive. All Rights Reserved.
/// https://www.opsive.com
/// ---------------------------------------------

namespace Opsive.UltimateCharacterController.Integrations.UltimateInventorySystem
{
    using Opsive.Shared.Inventory;
    using Opsive.Shared.Utility;
    using Opsive.UltimateCharacterController.Inventory;
    using Opsive.UltimateInventorySystem.Core;
    using Opsive.UltimateInventorySystem.Core.DataStructures;
    using Opsive.UltimateInventorySystem.Storage;
    using System.Collections.Generic;
    using UnityEngine;
    using Opsive.UltimateInventorySystem.Utility;

    /// <summary>
    /// a struct with infomration about an item set rule.
    /// </summary>
    public struct ItemSetRuleInfo
    {
        private int m_CategoryIndex;
        private CategoryItemSetRule m_CategoryItemSetRule;
        private int m_SetIndex;
        private IItemSetRule m_ItemSetRule;

        public int CategoryIndex => m_CategoryIndex;
        public CategoryItemSetRule CategoryItemSetRule => m_CategoryItemSetRule;
        public int SetIndex => m_SetIndex;
        public IItemSetRule ItemSetRule => m_ItemSetRule;

        public ItemSetRuleInfo(int categoryIndex, CategoryItemSetRule categoryItemSetRule, int setIndex, IItemSetRule itemSetRule)
        {
            m_CategoryIndex = categoryIndex;
            m_CategoryItemSetRule = categoryItemSetRule;
            m_SetIndex = setIndex;
            m_ItemSetRule = itemSetRule;
        }
    }
    
    /// <summary>
    /// 
    /// </summary>
    [CreateAssetMenu(fileName = "ItemSetRulesObject", menuName = "Ultimate Inventory System/Integration/Ultimate Character Controller/Item Set Rules Object", order = 51)]
    public class ItemSetRulesObject : ScriptableObject, IDatabaseSwitcher
    {
        [Tooltip("The number of slots per item set.")]
        [SerializeField] protected int m_SlotCount;
        [Tooltip("The category Item set rules.")]
        [SerializeField] protected CategoryItemSetRule[] m_CategoryItemSetRules;

        [System.NonSerialized] protected bool m_Initialized;
        
        public CategoryItemSetRule[] CategoryItemSetRules => m_CategoryItemSetRules;
        public int SlotCount => m_SlotCount;

        /// <summary>
        /// Initialize the collection.
        /// <param name="force">Force the initialization.</param>
        /// </summary>
        public void Initialize(bool force)
        {
            if (m_Initialized && !force) { return; }

            if (m_CategoryItemSetRules == null) {
                m_CategoryItemSetRules = new CategoryItemSetRule[0];
            }
            
            for (int i = 0; i < m_CategoryItemSetRules.Length; i++) {
                m_CategoryItemSetRules[i].Initialize(force);
            }
            
            m_Initialized = true;
        }
        
        /// <summary>
        /// Set the category item set rules.
        /// </summary>
        /// <param name="categoryItemSetRules">The new category item set rules.</param>
        public void SetCategoryItemSetRules(CategoryItemSetRule[] categoryItemSetRules)
        {
            m_CategoryItemSetRules = categoryItemSetRules;
        }
        
        /// <summary>
        /// Set the slot count.
        /// </summary>
        /// <param name="slotCount">The slot count.</param>
        public void SetSlotCount(int slotCount)
        {
            m_SlotCount = slotCount;
            for (int i = 0; i < m_CategoryItemSetRules.Length; i++) {
                m_CategoryItemSetRules[i].SetSlotCount(m_SlotCount);
            }
        }

        /// <summary>
        /// Serialize the item set rules.
        /// </summary>
        public void Serialize()
        {
            for (int i = 0; i < m_CategoryItemSetRules.Length; i++) {

                for (int j = 0; j < m_CategoryItemSetRules[i].ItemSetRules.Count; j++) {
                    m_CategoryItemSetRules[i].Serialize();
                }
            }
        }
        
        /// <summary>
        /// Check fo valid inventory objects.
        /// </summary>
        /// <param name="database">The database to check against.</param>
        /// <returns>True if valid.</returns>
        public bool IsComponentValidForDatabase(InventorySystemDatabase database)
        {
            for (int i = 0; i < m_CategoryItemSetRules.Length; i++) {
                if (database.Contains(m_CategoryItemSetRules[i].ItemCategory) == false) {
                    return false;
                }

                for (int j = 0; j < m_CategoryItemSetRules[i].ItemSetRules.Count; j++) {
                    var itemSetRule = m_CategoryItemSetRules[i].ItemSetRules[j];

                    if (itemSetRule.IsComponentValidForDatabase(database) == false) {
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// replace the inventory objects by valid one.
        /// </summary>
        /// <param name="database">The database to check against.</param>
        /// <returns>objects to dirty.</returns>
        public ModifiedObjectWithDatabaseObjects
            ReplaceInventoryObjectsBySelectedDatabaseEquivalents(InventorySystemDatabase database)
        {
            for (int i = 0; i < m_CategoryItemSetRules.Length; i++) {
                if (database.Contains(m_CategoryItemSetRules[i].ItemCategory) == false) {
                    m_CategoryItemSetRules[i].ItemCategory =
                        database.FindSimilar(m_CategoryItemSetRules[i].ItemCategory);
                }

                for (int j = 0; j < m_CategoryItemSetRules[i].ItemSetRules.Count; j++) {
                    var itemSetRule = m_CategoryItemSetRules[i].ItemSetRules[j];

                    itemSetRule.ReplaceInventoryObjectsBySelectedDatabaseEquivalents(database);
                }
            }
            
            return null;
        }
    }
}