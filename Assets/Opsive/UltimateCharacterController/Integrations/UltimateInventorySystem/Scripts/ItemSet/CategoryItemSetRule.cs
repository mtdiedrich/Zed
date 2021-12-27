/// ---------------------------------------------
/// Ultimate Character Controller
/// Copyright (c) Opsive. All Rights Reserved.
/// https://www.opsive.com
/// ---------------------------------------------

namespace Opsive.UltimateCharacterController.Integrations.UltimateInventorySystem
{
    using Opsive.Shared.Utility;
    using Opsive.UltimateInventorySystem.Core;
    using System.Collections.Generic;
    using UnityEngine;

    /// <summary>
    /// Contains a list of ItemSets which belong in the same grouping.
    /// </summary>
    [System.Serializable]
    public class CategoryItemSetRule
    {
        [Tooltip("The ID of the category.")]
        [SerializeField] protected DynamicItemCategory m_ItemCategory;
        [Tooltip("A list of the belonging ItemSets.")]
        [SerializeField] protected Serialization[] m_ItemSetRulesData;

        [System.NonSerialized] protected List<IItemSetRule> m_ItemSetRules;

        [System.NonSerialized] protected bool m_Initialized;
        
        public List<IItemSetRule> ItemSetRules { get { return m_ItemSetRules; } set { m_ItemSetRules = value; } }

        public ItemCategory ItemCategory { get { return m_ItemCategory; } set { m_ItemCategory = value; } }

        /// <summary>
        /// CategoryItemSet default constructor.
        /// </summary>
        public CategoryItemSetRule()
        {
            m_ItemSetRules = new List<IItemSetRule>();
        }

        /// <summary>
        /// CategoryItemSet constructor with a single parameter.
        /// </summary>
        /// <param name="itemCategory">The category that the ItemSet belongs to.</param>
        public CategoryItemSetRule(ItemCategory itemCategory)
        {
            m_ItemCategory = itemCategory;
            m_ItemSetRules = new List<IItemSetRule>();
        }
        
        /// <summary>
        /// Initialize the collection.
        /// <param name="force">Force the initialization.</param>
        /// </summary>
        public void Initialize(bool force)
        {
            if (m_Initialized && !force) { return; }

            Deserialize();

            m_Initialized = true;
        }
        
        /// <summary>
        /// Deserializes the attributes and stores them in the list and dictionary.
        /// </summary>
        protected void Deserialize()
        {
            if (m_ItemSetRules == null) { m_ItemSetRules = new List<IItemSetRule>(); }
            m_ItemSetRules.Clear();
            
            if (m_ItemSetRulesData == null) { return; }

            for (int i = 0; i < m_ItemSetRulesData.Length; i++) {
                var itemAction = m_ItemSetRulesData[i].DeserializeFields(MemberVisibility.Public) as IItemSetRule;
                if (itemAction == null) { continue; }
                m_ItemSetRules.Add(itemAction);
            }
        }

        /// <summary>
        /// Deserializes the attributes and stores them in the list and dictionary.
        /// </summary>
        public void Serialize()
        {
            m_ItemSetRulesData = Serialization.Serialize<IItemSetRule>(m_ItemSetRules);
        }

        public void SetSlotCount(int slotCount)
        {
            if (slotCount < 0) {
                slotCount = 0;
            }
            
            for (int i = 0; i < m_ItemSetRules.Count; i++) {
                m_ItemSetRules[i].SetSlotCount(slotCount);
            }
        }
    }
}