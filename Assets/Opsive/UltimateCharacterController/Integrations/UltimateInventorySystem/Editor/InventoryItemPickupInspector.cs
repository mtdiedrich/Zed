/// ---------------------------------------------
/// Ultimate Character Controller
/// Copyright (c) Opsive. All Rights Reserved.
/// https://www.opsive.com
/// ---------------------------------------------

namespace Opsive.UltimateCharacterController.Integrations.UltimateInventorySystem.Editor
{
    using Opsive.UltimateCharacterController.Editor.Inspectors.Objects.CharacterAssist;
    using Opsive.UltimateCharacterController.Objects.CharacterAssist;
    using Opsive.UltimateInventorySystem.Core;
    using Opsive.UltimateInventorySystem.Storage;
    using UnityEditor;
    using UnityEngine;

    /// <summary>
    /// Custom inspector for the InventoryItemPickup component.
    /// </summary>
    [CustomEditor(typeof(InventoryItemPickup), true)]
    public class InventoryItemPickupInspector : ItemPickupBaseInspector
    {
        private InventorySystemDatabase m_Database;

        /// <summary>
        /// Finds the database.
        /// </summary>
        protected override void OnEnable()
        {
            base.OnEnable();
            
            var inventorySystemManager = Object.FindObjectOfType<Opsive.UltimateInventorySystem.Core.InventorySystemManager>();
            m_Database = inventorySystemManager != null ? inventorySystemManager.Database :
                                                        Opsive.UltimateInventorySystem.Editor.Managers.InventoryMainWindow.InventorySystemDatabase;
        }

        /// <summary>
        /// Draws the object pickup fields.
        /// </summary>
        protected override void DrawObjectPickupFields()
        {
            EditorGUILayout.PropertyField(serializedObject.FindProperty("m_EquipOnPickup"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("m_PickupItemCopies"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("m_RemoveItemsOnPickup"));
            base.DrawObjectPickupFields();
        }

        /// <summary>
        /// Draws the header fields for the ItemPickupSet.
        /// </summary>
        protected override void DrawItemPickupSetHeaderFields()
        {
            m_Database = EditorGUILayout.ObjectField("Database", m_Database, typeof(InventorySystemDatabase), false) as InventorySystemDatabase;
            if (m_Database != null) {
                m_Database.Initialize(false);
            }
        }

        /// <summary>
        /// Draws the field that displays the available categories.
        /// </summary>
        /// <param name="pickupSet">The PickupSet that should be drawn.</param>
        /// <param name="objRect">The location the categories should draw.</param>
        protected override void DrawAvailableCategories(ItemPickupBase.PickupSet pickupSet, Rect objRect)
        {
            var validCategoryCount = 1;
            if (m_Database != null && m_Database.ItemCategories != null) {
                for (int i = 0; i < m_Database.ItemCategories.Length; ++i) {
                    if (IsItemSetCategory(m_Database.ItemCategories[i])) {
                        validCategoryCount++;
                    }
                }
            }

            var categoryNames = new string[validCategoryCount];
            categoryNames[0] = "(Not Specified)";
            var selected = -1;
            if (validCategoryCount > 1) {
                var index = 1;
                for (int i = 0; i < m_Database.ItemCategories.Length; ++i) {
                    if (!IsItemSetCategory(m_Database.ItemCategories[i])) {
                        continue;
                    }
                    categoryNames[index] = m_Database.ItemCategories[i].name;
                    if (pickupSet.CategoryID == m_Database.ItemCategories[i].ID) {
                        selected = index;
                    }
                    index++;
                }
            }
            int newSelected;
            if (objRect.width == 0) {
                newSelected = EditorGUILayout.Popup("Category", selected != -1 ? selected : 0, categoryNames);
            } else {
                newSelected = EditorGUI.Popup(objRect, selected != -1 ? selected : 0, categoryNames);
            }
            if (selected != newSelected) {
                if (newSelected == 0) {
                    pickupSet.CategoryID = 0;
                } else {
                    var index = 1;
                    for (int i = 0; i < m_Database.ItemCategories.Length; ++i) {
                        if (!IsItemSetCategory(m_Database.ItemCategories[i])) {
                            continue;
                        }
                        if (index == newSelected) {
                            pickupSet.CategoryID = m_Database.ItemCategories[i].ID;
                            break;
                        }
                        index++;
                    }
                }
                GUI.changed = true;
            }
        }

        protected bool IsItemSetCategory(ItemCategory itemCategory)
        {
            return InventoryUtility.IsItemSetCategory(itemCategory);
        }
    }
}