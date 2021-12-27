/// ---------------------------------------------
/// Ultimate Character Controller
/// Copyright (c) Opsive. All Rights Reserved.
/// https://www.opsive.com
/// ---------------------------------------------

namespace Opsive.UltimateCharacterController.Integrations.UltimateInventorySystem.Editor
{
    using Opsive.Shared.Editor.UIElements.Managers;
    using Opsive.Shared.Inventory;
    using Opsive.UltimateCharacterController.Editor.Inspectors.Inventory;
    using Opsive.UltimateInventorySystem.Core;
    using Opsive.UltimateInventorySystem.Editor.Styles;
    using Opsive.UltimateInventorySystem.Editor.VisualElements;
    using Opsive.UltimateInventorySystem.Storage;
    using UnityEditor;
    using UnityEngine;
    using UnityEngine.UIElements;

    /// <summary>
    /// Custom inspector for the InventoryItemSetManager component.
    /// </summary>
    [CustomEditor(typeof(InventoryItemSetManager))]
    public class InventoryItemSetManagerInspector : ItemSetManagerBaseInspector
    {
        protected InventoryItemSetManager m_InventoryItemSetManager;
        
        protected ObjectFieldWithNestedInspector<ItemSetRulesObject, ItemSetRulesObjectInspector>
            m_InventorySystemDataNestedInspector;
        protected InventorySystemDatabase m_Database;
        protected InventorySystemDatabase m_OriginalDatabase;

        /// <summary>
        /// Create a custom inspector by drawing all serialized fields as UIElements.
        /// </summary>
        /// <returns>The custom inspector.</returns>
        public override VisualElement CreateInspectorGUI()
        {
            m_InventoryItemSetManager = target as InventoryItemSetManager;
            
            var container = new VisualElement();
            
            container.styleSheets.Add(Shared.Editor.Utility.EditorUtility.LoadAsset<StyleSheet>("e70f56fae2d84394b861a2013cb384d0")); // Shared stylesheet.
            container.styleSheets.Add(CommonStyles.StyleSheet);
            container.styleSheets.Add(ManagerStyles.StyleSheet);
            container.styleSheets.Add(ControlTypeStyles.StyleSheet);
            
            var inventoryBridge = m_InventoryItemSetManager.GetComponent<CharacterInventoryBridge>();

            if (inventoryBridge == null) {
                var helpBox = new InventoryHelpBox("The Inventory Bridge component is missing.");
                container.Add(helpBox);
            }else if (m_InventoryItemSetManager.ItemSetRulesObject != null
                      && m_InventoryItemSetManager.ItemSetRulesObject.SlotCount !=
                      inventoryBridge.SlotCount) {
                var helpBox = new InventoryHelpBox($"The Inventory Bridge Slot Count ({inventoryBridge.SlotCount}) does not match the item set data slot count.");
                container.Add(helpBox);
            }

            m_InventorySystemDataNestedInspector = new ObjectFieldWithNestedInspector<ItemSetRulesObject, ItemSetRulesObjectInspector>(
                "Inventory System Item Set Data",
                m_InventoryItemSetManager.ItemSetRulesObject,
                "The Inventory Item Set Data is used to define the item sets.",
                newValue =>
                {
                    m_InventoryItemSetManager.ItemSetRulesObject = newValue;
                    Shared.Editor.Utility.EditorUtility.SetDirty(m_InventoryItemSetManager);
                }, true);

            container.Add(m_InventorySystemDataNestedInspector);

            if (Application.isPlaying) {
                var baseInspector = new IMGUIContainer(base.OnInspectorGUI);
                container.Add(baseInspector);
            }

            return container;
        }
        
        /// <summary>
        /// Initializes the ItemSet categories.
        /// </summary>
        /// <returns>True if the categories were initialized.</returns>
        protected override bool InitializeCategories()
        {
            var InventoryItemSetManager = m_ItemSetManager as InventoryItemSetManager;

            var previousDatabase = m_Database;

            if (m_Database == null) {
                var inventorySystemManager = FindObjectOfType<InventorySystemManager>();
                m_OriginalDatabase = m_Database = inventorySystemManager != null ? inventorySystemManager.Database :
                    Opsive.UltimateInventorySystem.Editor.Managers.InventoryMainWindow.InventorySystemDatabase;
            }

            m_Database = EditorGUILayout.ObjectField("Database", m_Database, typeof(InventorySystemDatabase), false) as InventorySystemDatabase;
            if (m_Database == null) {
                EditorGUILayout.HelpBox("A database reference is required.", MessageType.Error);
                return false;
            }

            if (m_Database != previousDatabase || m_OriginalDatabase != m_Database) {
                if (previousDatabase == null && !Application.isPlaying) {
                    InventoryItemSetManager.Initialize(true);
                    m_ItemSetReorderableList = null;
                } else {
                    //TODO does this require a refactor?
                    /*if (!InventoryItemSetManager.IsComponentValidForDatabase(m_Database)) {
                        EditorGUILayout.HelpBox("An inventory object referenced by this component is not part of the selected database. " +
                                                "Select the correct database for this object or replace the referenced object by matching ones for the currently selected database." +
                                                "This process cannot be done at runtime.", MessageType.Warning);
                        GUI.enabled = !Application.isPlaying;
                        if (GUILayout.Button("Convert Inventory Objects")) {
                            InventoryItemSetManager.Initialize(previousDatabase);
                            InventoryItemSetManager.ReplaceInventoryObjectsBySelectedDatabaseEquivalents(m_Database);
                            InventoryItemSetManager.Initialize(m_Database.ItemCategories);
                            m_ItemSetReorderableList = null;
                            m_OriginalDatabase = m_Database;
                            Shared.Editor.Utility.EditorUtility.SetDirty(InventoryItemSetManager);
                        }
                        GUI.enabled = true;
                        return false;
                    }*/
                }
            }

            if (InventoryItemSetManager.ItemSetRulesObject == null) { return false ;}
            

            var categories = new IItemCategoryIdentifier[InventoryItemSetManager.ItemSetRulesObject.CategoryItemSetRules.Length];
            for (int i = 0; i < categories.Length; i++) {
                categories[i] = InventoryItemSetManager.ItemSetRulesObject.CategoryItemSetRules[i].ItemCategory;
            }

            CheckCategories(categories);
            CheckItemSetAbilities(categories);
            return true;
        }

        /// <summary>
        /// Is the category an ItemSet category?
        /// </summary>
        /// <param name="category">The category that may be an ItemSet category.</param>
        /// <returns>True if the category is an ItemSet category.</returns>
        protected override bool IsItemSetCategory(IItemCategoryIdentifier categoryIdentifier)
        {
            return categoryIdentifier != null;
        }
    }
}