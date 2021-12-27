/// ---------------------------------------------
/// Ultimate Character Controller
/// Copyright (c) Opsive. All Rights Reserved.
/// https://www.opsive.com
/// ---------------------------------------------

namespace Opsive.UltimateCharacterController.Integrations.UltimateInventorySystem.Editor
{
    using Opsive.Shared.Editor.UIElements;
    using Opsive.Shared.Editor.UIElements.Managers;
    using Opsive.Shared.Utility;
    using Opsive.UltimateCharacterController.Character;
    using Opsive.UltimateCharacterController.Character.Abilities;
    using Opsive.UltimateCharacterController.Character.Abilities.Items;
    using Opsive.UltimateCharacterController.Editor.Inspectors.Utility;
    using Opsive.UltimateCharacterController.Game;
    using Opsive.UltimateCharacterController.Items.Actions;
    using Opsive.UltimateCharacterController.Objects;
    using Opsive.UltimateInventorySystem.Core;
    using Opsive.UltimateInventorySystem.Core.AttributeSystem;
    using Opsive.UltimateInventorySystem.Core.DataStructures;
    using Opsive.UltimateInventorySystem.Core.InventoryCollections;
    using Opsive.UltimateInventorySystem.Editor.Managers;
    using Opsive.UltimateInventorySystem.Editor.Styles;
    using Opsive.UltimateInventorySystem.Editor.Utility;
    using Opsive.UltimateInventorySystem.Editor.VisualElements;
    using Opsive.UltimateInventorySystem.Exchange;
    using Opsive.UltimateInventorySystem.Interactions;
    using Opsive.UltimateInventorySystem.ItemActions;
    using Opsive.UltimateInventorySystem.Storage;
    using System;
    using System.Collections.Generic;
    using UnityEditor;
    using UnityEditor.UIElements;
    using UnityEngine;
    using UnityEngine.UIElements;
    using Object = UnityEngine.Object;

    /// <summary>
    /// Draws an inspector that can be used within the Inspector Manager.
    /// </summary>
    [OrderedEditorItem("Ultimate Character Controller", 1)]
    public class UltimateCharacterControllerIntegration : IntegrationInspector
    {
        public const string c_AmmoItemCategoryName = "Ammo";
        public const string c_EquippableItemCategoryName = "Equippable";
        
        private CharacterSetup m_CharacterSetup;
        protected ItemSetup m_CharacterItemSetup;
        protected ItemPickupSetup m_ItemPickupSetup;
        
        protected ObjectField m_BridgeComponentField;
        
        /// <summary>
        /// Draws the integration inspector.
        /// </summary>
        /// <param name="parent">The parent VisualElement.</param>
        public override void ShowInspector(VisualElement parent)
        {
            //parent.Add(new Label("The integration is located within the Ultimate Character Controller Manager."));
            var label = new Label("Version 2.0.7\n" +
                                  "Compatible with the Ultimate Character Controller v2.4.4 and the Ultimate Inventory System v1.2.3.\n");
            label.AddToClassList(InventoryManagerStyles.SubMenuIconDescription);
            parent.Add(label);
            
            m_BridgeComponentField = new ObjectField("Character Inventory Bridge");
            m_BridgeComponentField.objectType = typeof(CharacterInventoryBridge);
            m_BridgeComponentField.value = Object.FindObjectOfType<CharacterInventoryBridge>();
            m_BridgeComponentField.RegisterValueChangedCallback(evt =>
            {
                Refresh();
            });
            parent.Add(m_BridgeComponentField);
            
            var label2 = new Label("The Character and Character Items must be created using the Character Manager. " +
                                   "Once create they can be converted to work with the Inventory System using the fields below.");
            label2.AddToClassList(InventoryManagerStyles.SubMenuIconDescription);
            parent.Add(label2);
            
            var button = IntegrationControlBox.CreateButton("Open the Character Item Manager", 
                Opsive.UltimateCharacterController.Editor.Managers.MainManagerWindow.ShowItemManagerWindow);
            parent.Add(button);

            m_CharacterSetup = new CharacterSetup();
            m_CharacterSetup.OnSetupCharacter += (character) =>
            {
                m_BridgeComponentField.value = character.GetComponent<CharacterInventoryBridge>();
            };
            parent.Add(m_CharacterSetup);

            m_CharacterItemSetup = new ItemSetup();
            parent.Add(m_CharacterItemSetup);
            
            m_ItemPickupSetup = new ItemPickupSetup();
            parent.Add(m_ItemPickupSetup);
            

            Refresh();
        }

        private void Refresh()
        {
            var inventoryBridge = m_BridgeComponentField.value as CharacterInventoryBridge;
            if (inventoryBridge == null) {
                inventoryBridge = Object.FindObjectOfType<CharacterInventoryBridge>();
                m_BridgeComponentField.SetValueWithoutNotify(inventoryBridge);
            }

            m_CharacterSetup.Refresh();
            
            m_CharacterItemSetup.InventoryBridge = inventoryBridge;
            m_CharacterItemSetup.Refresh();
        }
    }

    public class CharacterSetup : IntegrationControlBox
    {
        public event Action<GameObject> OnSetupCharacter;
        
        public override string Title => "Character Setup";
        public override string Description => "Sets up the character to work with the Ultimate Inventory System by replacing and adding required components.\n" +
                                              "The character must be first created using the Character Controller Manager and then converted here.";

        protected ObjectField m_CharacterField;
        protected Button m_SetupButton;
        
        public CharacterSetup()
        {
            m_CharacterField = new ObjectField("Character");
            m_CharacterField.objectType = typeof(GameObject);
            m_CharacterField.RegisterValueChangedCallback(evt=>
            {
                Refresh();
            });
            Add(m_CharacterField);
            
            m_SetupButton = CreateButton("Setup Character",SetupCharacter);
            Add(m_SetupButton);

            Refresh();
        }

        public void Refresh()
        {
            var canSetup = false;
            if (m_CharacterField.value is GameObject gameObject) {
                if (gameObject.GetComponent<UltimateCharacterLocomotion>() != null) {
                    canSetup = true;
                }
            }
            m_SetupButton.SetEnabled(canSetup);
        }

        private void SetupCharacter()
        {
            var character = m_CharacterField.value as GameObject;
            SetupCharacter(character);
            
            Debug.Log("Character was setup successfully.");
            m_CharacterField.value = null;
            
            OnSetupCharacter?.Invoke(character);
        }
        
        private void SetupCharacter(GameObject characterObject)
        {
            var locomotion = characterObject.GetComponent<UltimateCharacterLocomotion>();
            if (locomotion == null) {
                Debug.LogWarning("object specified is not a character, please assign a character object");
                return;
            }

            // Ensure the database is valid.
            var inventorySystemManager = Object.FindObjectOfType<Opsive.UltimateInventorySystem.Core.InventorySystemManager>();
            var database = inventorySystemManager != null ? inventorySystemManager.Database :
                    Opsive.UltimateInventorySystem.Editor.Managers.InventoryMainWindow.InventorySystemDatabase;
            if (database == null) {
                Debug.LogError("Error: Unable to find the database. Ensure the database has been created and is assigned to the Inventory System Manager or " +
                               "database field of the Inventory Manager.");
                return;
            }

            // The database needs to be in the correct format.
            ItemCategory ammoItemCategory = null, equippableItemCategory = null;
            database.Initialize(false);
            if (database.ItemCategories != null) {
                for (int i = 0; i < database.ItemCategories.Length; ++i) {
                    if (database.ItemCategories[i].name == UltimateCharacterControllerIntegration.c_AmmoItemCategoryName) {
                        ammoItemCategory = database.ItemCategories[i];
                    } else if (database.ItemCategories[i].name == UltimateCharacterControllerIntegration.c_EquippableItemCategoryName) {
                        equippableItemCategory = database.ItemCategories[i];
                    }
                }
            }
            if (ammoItemCategory == null || equippableItemCategory == null) {
                Debug.LogWarning("Warning: Unable to find the Ammo Item Category or the Equippable Item Category. " +
                                 "You will be required to add those manually in the Ultimate Inventory System Bridge component.");
            }

            var characterInventory = characterObject.GetComponent<UltimateCharacterController.Inventory.Inventory>();
            if (characterInventory != null) {
                Object.DestroyImmediate(characterInventory, true);
            }
            var itemSetManager = characterObject.GetComponent<UltimateCharacterController.Inventory.ItemSetManager>();
            if (itemSetManager != null) {
                Object.DestroyImmediate(itemSetManager, true);
            }

            // Add the default ItemCollections to the character.
            var itemCollections = new List<ItemCollection>();
            var itemCollection = new ItemCollection();
            itemCollection.SetName("Default");
            InspectorUtility.SetFieldValue(itemCollection, "m_Purpose", ItemCollectionPurpose.Main);
            itemCollections.Add(itemCollection);
            var itemSlotCollection = new ItemSlotCollection(CreateSlotSet(database, equippableItemCategory));
            itemSlotCollection.SetName("Equippable Slots");
            InspectorUtility.SetFieldValue(itemSlotCollection, "m_Purpose", ItemCollectionPurpose.Equipped);
            itemCollections.Add(itemSlotCollection);
            itemCollection = new ItemCollection();
            itemCollection.SetName("Equippable");
            InspectorUtility.SetFieldValue(itemCollection, "m_Purpose", ItemCollectionPurpose.None);
            itemCollections.Add(itemCollection);
            itemCollection = new ItemCollection();
            itemCollection.SetName("Loadout");
            InspectorUtility.SetFieldValue(itemCollection, "m_Purpose", ItemCollectionPurpose.Loadout);
            itemCollections.Add(itemCollection);
            var inventory = Shared.Editor.Inspectors.Utility.InspectorUtility.AddComponent<Inventory>(characterObject);
            InspectorUtility.SetFieldValue(inventory, "m_ItemCollections", itemCollections);
            inventory.Serialize();

            // Add the Ultimate Inventory System integration components.
            var bridge = Shared.Editor.Inspectors.Utility.InspectorUtility.AddComponent<CharacterInventoryBridge>(characterObject);
            InspectorUtility.SetFieldValue(bridge, "m_EquippableCategory", equippableItemCategory);
            InspectorUtility.SetFieldValue(bridge, "m_AmmoCategory", ammoItemCategory);
            InspectorUtility.SetFieldValue(bridge, "m_InventoryItemPickupPrefab", ItemPickupSetup.SetupItemPickup(null,null));
            EditorUtility.SetDirty(bridge);

            //Add the item set rules for the Inventory Item Set Manager
            var InventoryItemSetManager = Shared.Editor.Inspectors.Utility.InspectorUtility.AddComponent<InventoryItemSetManager>(characterObject);
            InventoryItemSetManager.ItemSetRulesObject = CreateItemSetRulesObject(database, equippableItemCategory);
            EditorUtility.SetDirty(InventoryItemSetManager);
            
            //Fix the categories on the item set abilities
            var abilities = locomotion.GetSerializedAbilities();
            if (abilities != null) {
                for (int i = 0; i < abilities.Length; i++) {
                    if (abilities[i] is ItemSetAbilityBase itemSetAbilityBase) {
                        InspectorUtility.SetFieldValue(itemSetAbilityBase, "m_ItemSetCategoryID", equippableItemCategory); 
                    }
                }
            }
            locomotion.AbilityData = Serialization.Serialize((IList<Ability>)abilities);


            // Add the additional Inventory System components for characters
            Shared.Editor.Inspectors.Utility.InspectorUtility.AddComponent<InventoryIdentifier>(characterObject);
            Shared.Editor.Inspectors.Utility.InspectorUtility.AddComponent<ItemUser>(characterObject);
            var input = Shared.Editor.Inspectors.Utility.InspectorUtility.AddComponent<Shared.Input.UnityInput>(characterObject);
            characterObject.GetComponent<ItemUser>().InventoryInput = input;
            Shared.Editor.Inspectors.Utility.InspectorUtility.AddComponent<CurrencyOwner>(characterObject);
            Shared.Editor.Inspectors.Utility.InspectorUtility.AddComponent<InventoryInteractor>(characterObject);
            
            // And finally add the saver
            Shared.Editor.Inspectors.Utility.InspectorUtility.AddComponent<InventoryBridgeSaver>(characterObject);
        }
        
        /// <summary>
        /// Creates the ItemSlotSet Scriptable Object at the same path as the database.
        /// </summary>
        /// <param name="database">The database that is being used.</param>
        /// <param name="equippableCategory">The equippable category.</param>
        /// <returns></returns>
        private static ItemSlotSet CreateSlotSet(InventorySystemDatabase database, Opsive.UltimateInventorySystem.Core.ItemCategory equippableCategory)
        {
            var directory = System.IO.Path.GetDirectoryName(AssetDatabase.GetAssetPath(database));
            var name = database.name + "EquippedSlots";
            var index = 1;
            // Ensure the ItemSlotSet is unique.
            while (AssetDatabase.LoadAssetAtPath(directory + "/" + name + ".asset", typeof(ItemSlotSet)) != null) {
                name = database.name + "EquippedSlots" + index;
                index++;
            }

            var itemSlotSet = ScriptableObject.CreateInstance<ItemSlotSet>();
            var itemSlots = new ItemSlot[3];
            itemSlots[0] = new ItemSlot("Primary", equippableCategory);
            itemSlots[1] = new ItemSlot("Secondary", equippableCategory);
            itemSlots[2] = new ItemSlot("Tactical", equippableCategory);
            InspectorUtility.SetFieldValue(itemSlotSet, "m_ItemSlots", itemSlots);
            itemSlotSet.name = name;
            EditorUtility.SetDirty(itemSlotSet);

            Opsive.UltimateInventorySystem.Editor.Utility.AssetDatabaseUtility.CreateAsset(itemSlotSet, directory + "/" + itemSlotSet.name, null);

            return itemSlotSet;
        }

        private static ItemSetRulesObject CreateItemSetRulesObject(InventorySystemDatabase database, Opsive.UltimateInventorySystem.Core.ItemCategory equippableCategory)
        {
            var directory = System.IO.Path.GetDirectoryName(AssetDatabase.GetAssetPath(database));
            var name = database.name + "ItemSetRulesObject";
            var index = 1;
            // Ensure the ItemSlotSet is unique.
            while (AssetDatabase.LoadAssetAtPath(directory + "/" + name + ".asset", typeof(ItemSetRulesObject)) != null) {
                name = database.name + "ItemSetRulesObject" + index;
                index++;
            }

            var slotCount = 2;
            var itemSetRulesObject = ScriptableObject.CreateInstance<ItemSetRulesObject>();
            var categoryItemSetRules = new CategoryItemSetRule[1];
            categoryItemSetRules[0] = new CategoryItemSetRule();
            categoryItemSetRules[0].ItemCategory = equippableCategory;
            categoryItemSetRules[0].ItemSetRules = new List<IItemSetRule>();
            var itemSetRuleWithCategories = new ItemSetRuleWithCategories();
            itemSetRuleWithCategories.SetSlotCount(slotCount);
            itemSetRuleWithCategories.ItemCategorySlots[0] = equippableCategory;
            itemSetRuleWithCategories.ItemCategorySlots = itemSetRuleWithCategories.ItemCategorySlots;
            categoryItemSetRules[0].ItemSetRules.Add(itemSetRuleWithCategories);

            itemSetRulesObject.SetCategoryItemSetRules(categoryItemSetRules);
            itemSetRulesObject.SetSlotCount(slotCount);

            itemSetRulesObject.name = name;
            itemSetRulesObject.Serialize();
            EditorUtility.SetDirty(itemSetRulesObject);

            Opsive.UltimateInventorySystem.Editor.Utility.AssetDatabaseUtility.CreateAsset(itemSetRulesObject, directory + "/" + itemSetRulesObject.name, null);

            return itemSetRulesObject;
        }

        
    }

    public class ItemSetup : IntegrationControlBox
    {
        public override string Title => "Item Setup";

        public override string Description =>
            "Create or Update an Inventory Item Definition by Binding it to one or Many Character Items such that they can work with the integration.\n" +
            "The character Items must be first created using the Character Controller Manager and then converted here.\n" +
            "You may also do this manually, learn more about what is happening behind the scenes in the documentation.";

        public CharacterInventoryBridge InventoryBridge { get; set; }

        protected VisualElement m_ContentContainer;
        protected InventoryHelpBox m_HelpBox;
        protected VisualElement m_HelpBoxContainer;
        protected VisualElement m_ExtrasContainer;
        
        protected List<Items.Item> m_CharacterItems;
        protected ReorderableList m_ReorderableList;
        protected ItemDefinitionField m_ItemDefinitionField;
        protected Button m_SetupButton;

        protected VisualElement m_ShotableWeaponAmmoExtras;
        protected ItemDefinitionField m_AmmoItemDefinitionField;
        protected Toggle m_AmmoShootableWeaponBinding;

        protected InventorySystemDatabase m_Database;

        public ItemSetup()
        {
            // Ensure the database is valid.
            m_Database = GetDatabase();
            if (m_Database == null) {
                Debug.LogError("Error: Unable to find the database. Ensure the database has been created and is assigned to the Inventory System Manager or " +
                               "database field of the Inventory Manager.");
                return;
            }

            m_ContentContainer = new VisualElement();
            Add(m_ContentContainer);
            
            CreateVisualElements();

            Refresh();
        }

        private void CreateVisualElements()
        {
            m_ContentContainer.Clear();
            
            m_HelpBoxContainer = new VisualElement();
            m_ContentContainer.Add(m_HelpBoxContainer);

            m_HelpBox = new InventoryHelpBox("help box");

            m_CharacterItems = new List<Items.Item>();
            m_ReorderableList = new ReorderableList(
                m_CharacterItems,
                (parent, index) =>
                {
                    var listElement = new ListElement();
                    listElement.Index = index;
                    listElement.OnValueChanged += OnValueChanged;
                    parent.Add(listElement);
                }, (parent, index) =>
                {
                    var listElement = parent.ElementAt(0) as ListElement;
                    listElement.Index = index;
                    listElement.Refresh(m_ReorderableList.ItemsSource[index] as Items.Item);
                }, (parent) => { parent.Add(new Label("Character Items")); }, (index) => { return 25f; },
                (index) =>
                {
                    //nothing
                },
                () =>
                {
                    m_CharacterItems.Add(null);
                    Refresh();
                }, (index) =>
                {
                    m_CharacterItems.RemoveAt(index);
                    Refresh();
                },
                (i1, i2) =>
                {
                    var element1 = m_ReorderableList.ListItems[i1].ItemContents.ElementAt(0) as ListElement;
                    element1.Index = i1;
                    var element2 = m_ReorderableList.ListItems[i2].ItemContents.ElementAt(0) as ListElement;
                    element2.Index = i2;
                });
            m_ContentContainer.Add(m_ReorderableList);

            m_ItemDefinitionField = new ItemDefinitionField("Item Definition", m_Database,
                (itemDefinition) =>
                {
                    m_ItemDefinitionField.Refresh(itemDefinition);
                    Refresh();
                }, null);
            m_ItemDefinitionField.style.flexShrink = 0;
            m_ContentContainer.Add(m_ItemDefinitionField);


            m_ExtrasContainer = new VisualElement();
            m_ContentContainer.Add(m_ExtrasContainer);

            m_SetupButton = CreateButton("Setup Character Item", SetupCharacterItem);
            m_ContentContainer.Add(m_SetupButton);


            m_ShotableWeaponAmmoExtras = new VisualElement();
            var ammoExtraDescription = new Label(
                "Detected Shootable Weapon,\n" +
                "Optionally define the ammo below and whether of not to bind the AmmoData between the Inventory and Character Items.");
            ammoExtraDescription.AddToClassList(InventoryManagerStyles.SubMenuIconDescription);
            m_ShotableWeaponAmmoExtras.Add(ammoExtraDescription);
            m_AmmoItemDefinitionField = new ItemDefinitionField("Ammo", m_Database,
                (itemDefinition) =>
                {
                    m_AmmoItemDefinitionField.Refresh(itemDefinition);
                    Refresh();
                }, null);
            m_AmmoItemDefinitionField.style.flexShrink = 0;
            m_ShotableWeaponAmmoExtras.Add(m_AmmoItemDefinitionField);

            m_AmmoShootableWeaponBinding = new Toggle("Bind Shootable Weapon");
            m_AmmoShootableWeaponBinding.value = true;
            m_AmmoShootableWeaponBinding.RegisterValueChangedCallback(evt => { Refresh(); });
            m_ShotableWeaponAmmoExtras.Add(m_AmmoShootableWeaponBinding);
        }

        private InventorySystemDatabase GetDatabase()
        {
            var inventorySystemManager = Object.FindObjectOfType<InventorySystemManager>();

            if (inventorySystemManager != null && inventorySystemManager.Database != null) {
                return inventorySystemManager.Database;
            }
            
            return InventoryMainWindow.InventorySystemDatabase;
        }

        private void OnValueChanged(int index, Items.Item characterItem)
        {
            m_CharacterItems[index] = characterItem;

            if (index == 0 && m_ItemDefinitionField.Value == null && characterItem != null) {
                m_ItemDefinitionField.Refresh(characterItem.ItemDefinition as ItemDefinition);
            }

            Refresh();
        }

        public void Refresh()
        {
            var database = GetDatabase();
            if (m_Database != database) {
                m_Database = database;
                CreateVisualElements();
            }

            if (m_Database == null) {
                Debug.LogError("Error: Unable to find the database. Ensure the database has been created and is assigned to the Inventory System Manager or " +
                               "database field of the Inventory Manager.");
                return;
            }
            
            if (m_CharacterItems.Count == 0) {
                m_CharacterItems.Add(null);
            }
            m_ReorderableList.Refresh(m_CharacterItems);
            
            var canSetup = CheckForWarning();

            if (canSetup == false) {
                m_SetupButton.SetEnabled(false);
                return;
            }

            m_SetupButton.SetEnabled(canSetup);
        }

        private bool CheckForWarning()
        {
            m_HelpBoxContainer.Clear();
            m_ExtrasContainer.Clear();
            
            if (InventoryBridge == null) {
                SetHelpBoxMessage("Please set a character Inventory Bridge above before creating items.");
                return false;
            }

            if (InventoryBridge.EquippableCategory == null || InventoryBridge.AmmoCategory == null) {
                SetHelpBoxMessage("The Character Inventory Bridge has a null Equippable or Ammo Category.\n" +
                                  "Please assign them values in the inspector.");
                return false;
            }

            if (m_CharacterItems.Contains(null)) {
                SetHelpBoxMessage("The Character Items cannot have a null value.");
                return false;
            }

            for (int i = 0; i < m_CharacterItems.Count; i++) {
                var characterItem = m_CharacterItems[i];
                if (characterItem != null && characterItem.GetComponent<Items.Item>() != null) { continue; }

                SetHelpBoxMessage("At least one of the Character Items is null or missing the Item component.");
                return false;
            }
            
            if (m_ItemDefinitionField.Value == null || InventoryBridge.EquippableCategory.InherentlyContains(m_ItemDefinitionField.Value) == false) {
                SetHelpBoxMessage("The Item Definition selected is null or it does not inherit from the Equippable Item Category.");
                return false;
            }
            
            if (m_ItemDefinitionField.Value == null || InventoryBridge.EquippableCategory.InherentlyContains(m_ItemDefinitionField.Value) == false) {
                SetHelpBoxMessage("The Item Definition selected is null or it does not inherit from the Equippable Item Category.");
                return false;
            }
            
            var singleItemAttribute = m_ItemDefinitionField.Value.DefaultItem.GetAttribute<Attribute<GameObject>>(
                InventoryBridge.SingleItemPrefabAttributeName);
            
            var multiItemAttribute = m_ItemDefinitionField.Value.DefaultItem.GetAttribute<Attribute<GameObject[]>>(
                InventoryBridge.MultiItemPrefabsAttributeName);
            
            if (singleItemAttribute == null && multiItemAttribute == null) {
                SetHelpBoxMessage("The Item Definition is missing the attribute for single or multi items.\n" +
                                  "Please make sure the attribute name matches the name defined on the Character Inventory Bridge component.");
                return false;
            }

            if (singleItemAttribute == null && m_CharacterItems.Count != 1) {
                SetHelpBoxMessage("The item has a single Item attribute but you are trying to bind it to multiple Character Items.");
                return false;
            }
            

            var firstItem = m_CharacterItems[0].GetComponent<Items.Item>();
            
#if ULTIMATE_CHARACTER_CONTROLLER_SHOOTER
            if (firstItem.GetComponent<ShootableWeapon>()) {
               
                m_ExtrasContainer.Add(m_ShotableWeaponAmmoExtras);
                if (m_AmmoShootableWeaponBinding.value) {
                    var ammoDataAttribute = GetItemAttributeOfType<AmmoData>(m_ItemDefinitionField.Value);
                    if (ammoDataAttribute == null) {
                        m_HelpBox.SetMessage("The Shootable Weapon Binding requires the Item Definition Default Item to have an Item Attribute of type AmmoData. Please add one to your item.");
                        m_HelpBoxContainer.Add(m_HelpBox);
                        return false;
                    }
                }
            }
#endif

            return true;
        }

        private void SetHelpBoxMessage(string message)
        {
            m_HelpBox.SetMessage(message);
            m_HelpBoxContainer.Add(m_HelpBox);
        }


        private Attribute<T> GetItemAttributeOfType<T>(ItemDefinition itemDefinition)
        {
            var attributeList = itemDefinition.DefaultItem.GetAttributeList();
            for (int i = 0; i < attributeList.Count; i++) {
                if (attributeList[i].GetValueType() == typeof(T)) {
                    return attributeList[i] as Attribute<T>;
                }
            }

            return null;
        }

        private void SetupCharacterItem()
        {
            var itemDefinition = m_ItemDefinitionField.Value;

            SetAttributeValue(itemDefinition, m_CharacterItems);

            for (int i = 0; i < m_CharacterItems.Count; i++) {
                var characterItem = m_CharacterItems[i];
                characterItem.ItemDefinition = itemDefinition;
                characterItem.UniqueItemSet = false;
                
                Shared.Editor.Inspectors.Utility.InspectorUtility.AddComponent<ItemObject>(characterItem.gameObject);
                SetGenericItemBindings(itemDefinition, characterItem);
#if ULTIMATE_CHARACTER_CONTROLLER_SHOOTER
                SetShootableWeaponBinding(itemDefinition, characterItem);
#endif

                Shared.Editor.Utility.EditorUtility.SetDirty(characterItem);
                Shared.Editor.Utility.EditorUtility.SetDirty(characterItem.gameObject);
            }

            m_ItemDefinitionField.Refresh(null);
            m_CharacterItems.Clear();
            Debug.Log($"Success: the item {itemDefinition.name} was bound correctly!");
            Refresh();
        }

        private static void SetGenericItemBindings(ItemDefinition itemDefinition, Items.Item characterItem)
        {
            var itemBinding =
                Shared.Editor.Inspectors.Utility.InspectorUtility.AddComponent<ItemBinding>(characterItem.gameObject);
            if (itemBinding.ItemCategory == null || itemBinding.ItemCategory.InherentlyContains(itemDefinition) == false) {
                itemBinding.SetItemCategory(itemDefinition.Category);
                itemBinding.Serialize();
            }
            
            //TODO try to automatically set attributes to properties on ItemAction components?
            
            Shared.Editor.Utility.EditorUtility.SetDirty(itemBinding);
        }

#if ULTIMATE_CHARACTER_CONTROLLER_SHOOTER
        private void SetShootableWeaponBinding(ItemDefinition itemDefinition, Items.Item characterItem)
        {
            var shootableWeapon = characterItem.GetComponent<ShootableWeapon>();
            if (shootableWeapon == null){ return; }

            var ammoDefinition = m_AmmoItemDefinitionField.Value;
            if (m_AmmoItemDefinitionField.Value != null) {
                InspectorUtility.SetFieldValue(shootableWeapon, "m_ConsumableItemDefinition", ammoDefinition);
            }

            var ammoAttribute = GetItemAttributeOfType<AmmoData>(itemDefinition);

            if (m_AmmoShootableWeaponBinding.value) {
                var shootableWeaponAmmoBinding = 
                    Shared.Editor.Inspectors.Utility.InspectorUtility.AddComponent<ShootableWeaponAmmoBinding>(shootableWeapon.gameObject);
                shootableWeaponAmmoBinding.AmmoDataAttributeName = ammoAttribute.Name;

                var newAmmoData = new AmmoData(
                    shootableWeapon.ConsumableItemDefinition,
                    shootableWeapon.ClipSize,
                    0);
                AttributeEditorUtility.SetOverrideValueAsObject(ammoAttribute, newAmmoData);
                AttributeEditorUtility.SetVariantType(ammoAttribute, VariantType.Override);
                ItemDefinitionEditorUtility.SetItemDefinitionDirty(itemDefinition, true);
            }
            
            Shared.Editor.Utility.EditorUtility.SetDirty(shootableWeapon);
        }
    #endif

        private void SetAttributeValue(ItemDefinition itemDefinition, List<Items.Item> characterItems)
        {
            var singleItemAttribute = itemDefinition.DefaultItem.GetAttribute<Attribute<GameObject>>(
                InventoryBridge.SingleItemPrefabAttributeName);
            
            var multiItemAttribute = itemDefinition.DefaultItem.GetAttribute<Attribute<GameObject[]>>(
                InventoryBridge.MultiItemPrefabsAttributeName);

            if (characterItems.Count == 1 && singleItemAttribute != null) {
                AttributeEditorUtility.SetOverrideValueAsObject(singleItemAttribute, characterItems[0].gameObject);
                AttributeEditorUtility.SetVariantType(singleItemAttribute, VariantType.Override);
                ItemDefinitionEditorUtility.SetItemDefinitionDirty(itemDefinition, true);
            } else {
                var newArray = new GameObject[characterItems.Count];
                for (int i = 0; i < newArray.Length; i++) {
                    newArray[i] = characterItems[i].gameObject;
                }
                
                AttributeEditorUtility.SetOverrideValueAsObject(multiItemAttribute, newArray);
                AttributeEditorUtility.SetVariantType(multiItemAttribute, VariantType.Override);
                ItemDefinitionEditorUtility.SetItemDefinitionDirty(itemDefinition, true);
            }
        }

        public class ListElement : VisualElement
        {
            public event Action<int, Items.Item> OnValueChanged;
            
            public int Index { get; set; }

            protected ObjectField m_CharacterItemField;

            public ListElement()
            {
                m_CharacterItemField = new ObjectField();
                m_CharacterItemField.objectType = typeof(GameObject);
                m_CharacterItemField.RegisterValueChangedCallback(evt =>
                {
                    var gameObject = evt.newValue as GameObject;
                    var characterItem = gameObject?.GetComponent<Items.Item>();
                    if (characterItem == null) {
                        Debug.LogWarning("The GameObject selected is not an item.");
                        characterItem = null;
                        m_CharacterItemField.SetValueWithoutNotify(characterItem);
                    }
                    OnValueChanged?.Invoke(Index, characterItem);
                });
                Add(m_CharacterItemField);
            }
            
            public void Refresh(Items.Item characterItem)
            {
                m_CharacterItemField.SetValueWithoutNotify(characterItem);
            }
        }
    }
    
    public class ItemPickupSetup : IntegrationControlBox
    {
        public override string Title => "Item Pickup Setup";
        public override string Description => "Set up an Inventory Item Pickup that was made to work with the Character Inventory Bridge.\n" +
                                              "Note that there are many different ways to setup and use item Pickups, refer to the documentation to learn more.";

        protected ObjectField m_ItemObjectField;
        protected ObjectField m_ModelObjectField;
        protected Button m_SetupButton;
        
        public ItemPickupSetup()
        {
            m_ItemObjectField = new ObjectField("Item Object");
            m_ItemObjectField.objectType = typeof(GameObject);
            m_ItemObjectField.RegisterValueChangedCallback(evt=>
            {
                Refresh();
            });
            Add(m_ItemObjectField);
            
            m_ModelObjectField = new ObjectField("Pickup Model Object");
            m_ModelObjectField.objectType = typeof(GameObject);
            m_ModelObjectField.RegisterValueChangedCallback(evt=>
            {
                Refresh();
            });
            Add(m_ModelObjectField);
            
            m_SetupButton = CreateButton("Setup Item Pickup",SetupItemPickup);
            Add(m_SetupButton);

            Refresh();
        }

        public void Refresh()
        { }

        private void SetupItemPickup()
        {
            var modelObject = m_ModelObjectField.value as GameObject;
            var characterItem = (m_ItemObjectField?.value as GameObject)?.GetComponent<Items.Item>();
            SetupItemPickup(characterItem, modelObject);
            m_ModelObjectField.value = null;
            m_ItemObjectField.value = null;
            
            Debug.Log($"Success: the item pickup was setup correctly!");
        }
        
        public static GameObject SetupItemPickup(Items.Item characterItem, GameObject ModelObject)
        {
            
            var pickupName = characterItem?.name ?? ModelObject?.name ?? "InventoryItem";
            pickupName += "Pickup";
            
            var path = EditorUtility.SaveFilePanel("Save Object", "Assets", pickupName + ".prefab", "prefab");
            if (path.Length == 0 || Application.dataPath.Length > path.Length) {
                return null;
            }

            var createdObject = ModelObject;
            if (createdObject == null) {
                createdObject = new GameObject();
            } else if (EditorUtility.IsPersistent(createdObject)) {
                createdObject = GameObject.Instantiate(createdObject) as GameObject;
            }
            createdObject.name = pickupName;
            
            createdObject.layer = LayerManager.VisualEffect;
            Shared.Editor.Inspectors.Utility.InspectorUtility.AddComponent<BoxCollider>(createdObject);
            var sphereCollider = Shared.Editor.Inspectors.Utility.InspectorUtility.AddComponent<SphereCollider>(createdObject);
            sphereCollider.isTrigger = true;
            Shared.Editor.Inspectors.Utility.InspectorUtility.AddComponent<Inventory>(createdObject);
            Shared.Editor.Inspectors.Utility.InspectorUtility.AddComponent<InventoryItemPickup>(createdObject);
            var trajectoryObject = Shared.Editor.Inspectors.Utility.InspectorUtility.AddComponent<TrajectoryObject>(createdObject);
            trajectoryObject.ImpactLayers =
                ~(1 << LayerManager.IgnoreRaycast | 1 << LayerManager.Water | 1 << LayerManager.SubCharacter |
                  1 << LayerManager.Overlay |
                  1 << LayerManager.VisualEffect | 1 << LayerManager.SubCharacter |
                  1 << LayerManager.Character);

            //Replace/Create prefab
            var relativePath = path.Replace(Application.dataPath, "");
            PrefabUtility.SaveAsPrefabAsset(createdObject, "Assets" + relativePath);
            var newPickup = AssetDatabase.LoadAssetAtPath("Assets" + relativePath, typeof(GameObject)) as GameObject;
            Selection.activeGameObject = newPickup;
            Object.DestroyImmediate(createdObject, true);
            
            
            //Add the item to the inventory pickup
            if (characterItem != null) {

                characterItem.DropPrefab = newPickup;

                if (characterItem.ItemDefinition is ItemDefinition itemDefinition) {
                    var inventory = newPickup.GetComponent<Inventory>();
                    inventory.Initialize(true);

                    var itemCollection = inventory.MainItemCollection;
                    var itemAmounts = new ItemAmount[1];

                    itemAmounts[0] = new ItemAmount(ItemField.CreateItem(itemDefinition),1);
                    itemCollection.DefaultLoadout = itemAmounts;

                    inventory.Serialize();
                    Shared.Editor.Utility.EditorUtility.SetDirty(inventory);
                    Shared.Editor.Utility.EditorUtility.SetDirty(inventory.gameObject);
                }
                
                Shared.Editor.Utility.EditorUtility.SetDirty(characterItem);
                Shared.Editor.Utility.EditorUtility.SetDirty(characterItem.gameObject);
            }

            return newPickup;
        }
    }
}