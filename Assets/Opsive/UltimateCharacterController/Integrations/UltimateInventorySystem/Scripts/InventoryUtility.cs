/// Ultimate Character Controller
/// Copyright (c) Opsive. All Rights Reserved.
/// https://www.opsive.com
/// ---------------------------------------------

namespace Opsive.UltimateCharacterController.Integrations.UltimateInventorySystem
{
    using Opsive.UltimateInventorySystem.Core;
    using Opsive.UltimateInventorySystem.Core.AttributeSystem;
    using UnityEngine;

    /// <summary>
    /// Helper methods for the Ultimate Inventory System integration.
    /// </summary>
    public static class InventoryUtility
    {
        private static ItemSetRulesObject s_RulesObject;
        
        /// <summary>
        /// Is the category an ItemSet category?
        /// </summary>
        /// <param name="category">The category that may be an ItemSet category.</param>
        /// <returns>True if the category is an ItemSet category.</returns>
        public static bool IsItemSetCategory(ItemCategory itemCategory)
        {
            if (itemCategory == null) {
                return false;
            }
            
            if (s_RulesObject == null) {
                var itemSetManager = GameObject.FindObjectOfType<InventoryItemSetManager>();
                if (itemSetManager != null) {
                    s_RulesObject = itemSetManager.ItemSetRulesObject;
                }
            }
            
            if (s_RulesObject == null || s_RulesObject.CategoryItemSetRules == null) {
                return true;
            }

            for (int i = 0; i < s_RulesObject.CategoryItemSetRules.Length; i++) {
                if (s_RulesObject.CategoryItemSetRules[i].ItemCategory == itemCategory) {
                    return true;
                }
            }
            
            return false;
        }
    }
}