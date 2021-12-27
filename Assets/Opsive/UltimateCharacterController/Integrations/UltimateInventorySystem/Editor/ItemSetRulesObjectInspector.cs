/// ---------------------------------------------
/// Ultimate Character Controller
/// Copyright (c) Opsive. All Rights Reserved.
/// https://www.opsive.com
/// ---------------------------------------------

namespace Opsive.UltimateCharacterController.Integrations.UltimateInventorySystem.Editor
{
    using Opsive.Shared.Editor.UIElements;
    using Opsive.UltimateCharacterController.Inventory;
    using Opsive.UltimateInventorySystem.Core;
    using Opsive.UltimateInventorySystem.Editor.Inspectors;
    using Opsive.UltimateInventorySystem.Editor.VisualElements;
    using Opsive.UltimateInventorySystem.Editor.VisualElements.ViewNames;
    using Opsive.UltimateInventorySystem.Storage;
    using System;
    using System.Collections.Generic;
    using UnityEditor;
    using UnityEditor.UIElements;
    using UnityEngine;
    using UnityEngine.UIElements;
    using Opsive.Shared.Editor.Utility;

    /// <summary>
    /// Custom inspector for the ItemSetRulesObject component.
    /// </summary>
    [CustomEditor(typeof(ItemSetRulesObject))]
    public class ItemSetRulesObjectInspector : DatabaseInspectorBase
    {
        protected override List<string> PropertiesToExclude => new List<string>() { "m_SlotCount", "m_CategoryItemSetRules" };

        protected IntegerField m_SlotCountField;
        protected ItemSetRulesObject m_ItemSetRulesObject;
        
        protected CategoryItemSetRulesReorderableList m_ItemSetRulesCategoriesField;

        /// <summary>
        /// Initialize the inspector when it is first selected.
        /// </summary>
        protected override void InitializeInspector()
        {
            m_ItemSetRulesObject = target as ItemSetRulesObject;

            m_ItemSetRulesObject.Initialize(false);
            
            if (m_ItemSetRulesObject.CategoryItemSetRules == null) {
                m_ItemSetRulesObject.SetCategoryItemSetRules(new CategoryItemSetRule[0]);
                return;
            }

            base.InitializeInspector();
        }
        
        protected override void CreateInspector(VisualElement container)
        {
            container.styleSheets.Add(CharacterInventoryStyles.StyleSheet);
            
            m_SlotCountField = new IntegerField("Slot Count");
            m_SlotCountField.value = m_ItemSetRulesObject.SlotCount;
            m_SlotCountField.isDelayed = true;
            m_SlotCountField.RegisterValueChangedCallback(evt =>
            {
                Shared.Editor.Utility.EditorUtility.RecordUndoDirtyObject(m_ItemSetRulesObject, "SlotValueChange");
                m_ItemSetRulesObject.SetSlotCount(evt.newValue);
                m_ItemSetRulesCategoriesField.Refresh();
                m_ItemSetRulesObject.Serialize();
                Shared.Editor.Utility.EditorUtility.SetDirty(m_ItemSetRulesObject);
            });
            container.Add(m_SlotCountField);

            m_ItemSetRulesCategoriesField = new CategoryItemSetRulesReorderableList("Category Item Set Rules", m_Database, () =>
                {
                    return m_ItemSetRulesObject.CategoryItemSetRules;
                },
                (value) =>
                {
                    Shared.Editor.Utility.EditorUtility.RecordUndoDirtyObject(m_ItemSetRulesObject, "ItemSetCategoryChange");
                    m_ItemSetRulesObject.SetCategoryItemSetRules(value);
                    m_ItemSetRulesObject.SetSlotCount(m_ItemSetRulesObject.SlotCount);
                    m_ItemSetRulesObject.Serialize();
                    Shared.Editor.Utility.EditorUtility.SetDirty(m_ItemSetRulesObject);
                });
            container.Add(m_ItemSetRulesCategoriesField);
        }
    }
    
    /// <summary>
    /// base class for Reorderable list for Inventory Objects.
    /// </summary>
    /// <typeparam name="T">The Inventory object type.</typeparam>
    public class CategoryItemSetRulesReorderableList : VisualElement
    {
        private InventorySystemDatabase m_InventorySystemDatabase;
        Func<CategoryItemSetRule[]> m_GetObject;
        private Action<CategoryItemSetRule[]> m_SetObjects;

        protected List<CategoryItemSetRule> m_List;
        protected ReorderableList m_ReorderableList;

        protected VisualElement m_SelectionContainer;
        protected CategoryItemSetRuleField m_SelectedCategoryItemSetRuleFields;

        /// <summary>
        /// The constructor.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="getObject">A function to get the object.</param>
        /// <param name="setObjects">A function to set the object.</param>
        public CategoryItemSetRulesReorderableList(string title, InventorySystemDatabase database,
            Func<CategoryItemSetRule[]> getObject, 
            Action<CategoryItemSetRule[]> setObjects)
        {
            m_InventorySystemDatabase = database;
            m_GetObject = getObject;
            m_SetObjects = setObjects;
            
            m_SelectionContainer = new VisualElement();
            m_SelectedCategoryItemSetRuleFields = new CategoryItemSetRuleField(m_InventorySystemDatabase);
            m_SelectedCategoryItemSetRuleFields.OnValueChanged += HandleSelectedItemSetRuleValueCharged;

            var array = m_GetObject.Invoke();
            m_List = array == null ? new List<CategoryItemSetRule>() : new List<CategoryItemSetRule>(array);

            m_ReorderableList = new ReorderableList(
                m_List,
                (parent, index) =>
                {
                    var listElement = new CategoryItemSetRuleListElement(m_InventorySystemDatabase);
                    listElement.Index = index;
                    //listElement.OnValueChanged += OnCategoryItemCategorySetValueChanged;
                    parent.Add(listElement);
                }, (parent, index) =>
                {
                    var listElement = parent.ElementAt(0) as CategoryItemSetRuleListElement;
                    listElement.Index = index;
                    listElement.Refresh(m_ReorderableList.ItemsSource[index] as CategoryItemSetRule);
                }, (parent) =>
                {
                    parent.Add(new Label(title));
                }, (index) => { return 25f; },
                (index) =>
                {
                    //nothing
                    m_SelectionContainer.Clear();
                    m_SelectedCategoryItemSetRuleFields.Refresh(m_List[index]);
                    m_SelectionContainer.Add(m_SelectedCategoryItemSetRuleFields);
                }, () =>
                {
                    m_List.Add(new CategoryItemSetRule());

                    m_SetObjects.Invoke(m_List.ToArray());
                    Refresh();

                    m_ReorderableList.SelectedIndex = m_List.Count - 1;
                }, (index) =>
                {
                    if (index < 0 || index >= m_List.Count) { return; }

                    m_List.RemoveAt(index);

                    m_SetObjects.Invoke(m_List.ToArray());
                    Refresh();
                }, (i1, i2) =>
                {
                    var element1 = m_ReorderableList.ListItems[i1].ItemContents.ElementAt(0) as CategoryItemSetRuleListElement;
                    element1.Index = i1;
                    var element2 = m_ReorderableList.ListItems[i2].ItemContents.ElementAt(0) as CategoryItemSetRuleListElement;
                    element2.Index = i2;
                    m_SetObjects.Invoke(m_List.ToArray());
                });
            Add(m_ReorderableList);
            Add(m_SelectionContainer);
        }

        private void HandleSelectedItemSetRuleValueCharged()
        {
            var index = m_ReorderableList.SelectedIndex;
            if(index ==-1){return;}
            
            OnCategoryItemCategorySetValueChanged(index, m_List[index]);
        }
        
        /// <summary>
        /// Serialize and update the visuals.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="value">The value.</param>
        private void OnCategoryItemCategorySetValueChanged(int index, CategoryItemSetRule value)
        {
            m_List[index] = value;
            m_SetObjects.Invoke(m_List.ToArray());
            m_ReorderableList.Refresh(m_List);
        }

        public void Refresh()
        {
            m_SelectionContainer.Clear();
            m_ReorderableList.SelectedIndex = -1;
            
            var array = m_GetObject.Invoke();
            m_List = array == null ? new List<CategoryItemSetRule>() : new List<CategoryItemSetRule>(array);
            m_ReorderableList.Refresh(m_List);
        }
    }
    
    /// The list element for the tabs.
    /// </summary>
    public class CategoryItemSetRuleListElement : VisualElement
    {
        private InventorySystemDatabase m_Database;
        //public event Action<int, CategoryItemCategorySet> OnValueChanged;
        public int Index { get; set; }

        protected ItemCategoryViewName m_CategoryObjectViewName;

        /// <summary>
        /// The list element.
        /// </summary>
        public CategoryItemSetRuleListElement(InventorySystemDatabase database)
        {
            m_Database = database;
            m_CategoryObjectViewName = new ItemCategoryViewName();
            Add(m_CategoryObjectViewName);
        }

        /// <summary>
        /// Update the visuals.
        /// </summary>
        /// <param name="value">The new value.</param>
        public void Refresh(CategoryItemSetRule value)
        {
            m_CategoryObjectViewName.Refresh(value?.ItemCategory);
        }
    }

    public class CategoryItemSetRuleField : VisualElement
    {
        public event Action OnValueChanged;
        
        private InventorySystemDatabase m_InventorySystemDatabase;
        protected CategoryItemSetRule m_CategoryItemSetRule;

        protected ItemCategoryField m_ItemCategoryField;
        
        protected List<IItemSetRule> m_List;
        protected ReorderableList m_ReorderableList;

        public CategoryItemSetRuleField(InventorySystemDatabase database)
        {
            m_InventorySystemDatabase = database;
            
            m_ItemCategoryField = new ItemCategoryField( 
                "",
                database, new (string, Action<ItemCategory>)[]
                {
                    ("Set Category", (x) =>
                    {
                        m_CategoryItemSetRule.ItemCategory = x;
                        OnValueChanged?.Invoke();
                        Refresh();
                    })
                },
                (x) => true);

            m_List = new List<IItemSetRule>();

            m_ReorderableList = new ReorderableList(
                m_List,
                (parent, index) =>
                {
                    var listElement = new ItemSetRuleFieldContainer(m_InventorySystemDatabase);
                    listElement.Index = index;
                    listElement.OnValueChanged += OnItemCategorySetValueChanged;
                    parent.Add(listElement);
                }, (parent, index) =>
                {
                    if (index < 0 || index >= m_ReorderableList.ItemsSource.Count) {
                        return;
                    }
                    var listElement = parent.ElementAt(0) as ItemSetRuleFieldContainer;
                    listElement.Index = index;
                    listElement.Refresh(
                        m_ReorderableList.ItemsSource[index] as IItemSetRule, 
                        m_ReorderableList.SelectedIndex == index);
                }, (parent) =>
                {
                    parent.Add(m_ItemCategoryField);
                }, (index) =>
                {
                    if (index < 0 || index >= m_ReorderableList.ListItems.Count) {
                        return ItemSetRuleBaseField.DefaultHeight;
                    }
                    var listElement = m_ReorderableList.ListItems[index].ItemContents.ElementAt(0) as ItemSetRuleFieldContainer;
                    if (listElement == null) {
                        return ItemSetRuleBaseField.DefaultHeight;
                    }
                    
                    return listElement.GetHeight();
                },
                (index) =>
                {
                    for (int i = 0; i < m_ReorderableList.ListItems.Count; i++) {
                        var element1 = m_ReorderableList.ListItems[i].ItemContents.ElementAt(0) as ItemSetRuleFieldContainer;
                        element1.Select(i == index);
                    }
                    //Refresh to update the element size.
                    m_ReorderableList.Refresh();
                }, () =>
                {
                    var addMenu = new GenericMenu();
                    addMenu.AddItem(new GUIContent("Add Item Set Rule With Categories"), false,
                        () => {
                            m_List.Add(new ItemSetRuleWithCategories());
                            SetNewItemSetRuleArray();
                        });
                    addMenu.AddItem(new GUIContent("Add Item Set Rule With Definitions"), false, 
                        () => {
                            m_List.Add(new ItemSetRuleWithDefinitions());
                            SetNewItemSetRuleArray();
                        });
                    addMenu.AddItem(new GUIContent("Add Item Set Rule Object Container"), false, 
                        () => {
                            m_List.Add(new ItemSetRuleObjectContainer());
                            SetNewItemSetRuleArray();
                        });
                    addMenu.ShowAsContext();
                    
                }, (index) =>
                {
                    if (index < 0 || index >= m_List.Count) { return; }

                    m_List.RemoveAt(index);

                    SetNewItemSetRuleArray();
                }, (i1, i2) =>
                {
                    var element1 = m_ReorderableList.ListItems[i1].ItemContents.ElementAt(0) as ItemSetRuleFieldContainer;
                    element1.Index = i1;
                    var element2 = m_ReorderableList.ListItems[i2].ItemContents.ElementAt(0) as ItemSetRuleFieldContainer;
                    element2.Index = i2;
                    SetNewItemSetRuleArray();
                });
            Add(m_ReorderableList);
        }

        private void OnItemCategorySetValueChanged(int index, IItemSetRule value)
        {
            m_List[index] = value;
            SetNewItemSetRuleArray();
        }

        private void SetNewItemSetRuleArray()
        {
            m_CategoryItemSetRule.ItemSetRules = m_List;
            OnValueChanged?.Invoke();
            Refresh();
        }

        public void Refresh()
        {
            Refresh(m_CategoryItemSetRule);
        }
        
        public void Refresh(CategoryItemSetRule categoryItemSetRule)
        {
            m_CategoryItemSetRule = categoryItemSetRule;
            m_ItemCategoryField.Refresh(m_CategoryItemSetRule.ItemCategory);

            if (m_CategoryItemSetRule.ItemSetRules == null) {
                m_CategoryItemSetRule.ItemSetRules = new List<IItemSetRule>();
            }
            
            m_List = m_CategoryItemSetRule.ItemSetRules;
            
            m_ReorderableList.Refresh(m_List);
            
            //Refresh twice the reorderable list is required to draw the correct height
            if (m_ReorderableList.ListItems.Count != m_List.Count) {
                schedule.Execute((timerState) =>
                {
                    m_ReorderableList.Refresh();
                }).Every((long) 0.1f).Until(() => m_ReorderableList.ListItems.Count == m_List.Count);
            }
        }
    }
    
    public class ItemSetRuleFieldContainer : VisualElement
    {
        public event Action<int, IItemSetRule> OnValueChanged;
        
        protected int m_Index;
        protected bool m_Selected;
        protected IItemSetRule m_ItemSetRule;
        
        protected InventorySystemDatabase m_InventorySystemDatabase;
        protected Label m_Title;
        protected VisualElement m_Container;
        protected ItemSetRuleBaseField m_ItemSetRuleField;
        
        public int Index
        {
            get => m_Index;
            set
            {
                m_Index = value;
                Refresh(m_ItemSetRule,m_Selected);
            }
        }
        
        public ItemSetRuleFieldContainer(InventorySystemDatabase database)
        {
            m_InventorySystemDatabase = database;
            
            m_Container = new VisualElement();
            Add(m_Container);
            
            m_Title = new Label("Item Set Rule ");
            m_Title.style.paddingBottom = 10;
            m_Title.style.paddingTop = 2;
            m_Title.style.paddingLeft = 5;
            m_Title.style.unityFontStyleAndWeight = FontStyle.Bold;
        }
        
        public virtual float GetHeight()
        {
            if (m_ItemSetRuleField != null) {
                return m_ItemSetRuleField.GetHeight(m_Selected);
            }
            return ItemSetRuleBaseField.DefaultHeight;
        }
        
        public void Select(bool select)
        {
            if(m_Selected == select){return;}

            m_Selected = select;
            
            Refresh(m_ItemSetRule, m_Selected);
        }
        
        /// <summary>
        /// Update the visuals.
        /// </summary>
        /// <param name="newItemSetRule">The new value.</param>
        public virtual void Refresh(IItemSetRule newItemSetRule, bool selected)
        {
            m_Selected = selected;
            m_ItemSetRule = newItemSetRule;

            m_Container.Clear();
            if (m_ItemSetRule == null) {
                m_Container.Add(new Label("The Item Set Rule is null"));
                return;
            }

            m_Title.text = "Item Set Rule " + m_Index;

            m_Container.Add(m_Title);

            if (m_ItemSetRuleField == null || m_ItemSetRuleField.ItemSetRule.GetType() != m_ItemSetRule.GetType()) {
                switch (m_ItemSetRule) {
                    case ItemSetRuleWithCategories withCategories:
                        m_ItemSetRuleField = new ItemSetRuleWithCategoriesField(m_InventorySystemDatabase);
                        break;
                    case ItemSetRuleWithDefinitions withDefinitions:
                        m_ItemSetRuleField = new ItemSetRuleWithDefinitionsField(m_InventorySystemDatabase);
                        break;
                    case ItemSetRuleObjectContainer custom:
                        m_ItemSetRuleField = new ItemSetRuleObjectContainerField(m_InventorySystemDatabase);
                        break;
                    default:
                        m_ItemSetRuleField = new ItemSetRuleNotSupportedTypeField(m_InventorySystemDatabase);
                        break;
                }

                m_ItemSetRuleField.OnValueChanged += (x) => OnValueChanged?.Invoke(m_Index,x);
            }

            m_ItemSetRuleField.Refresh(m_ItemSetRule, selected);
            m_Title.text += m_ItemSetRuleField.TitleSuffix;
            
            m_Container.Add(m_ItemSetRuleField);

        }
    }

    public abstract class ItemSetRuleBaseField : VisualElement
    {
        public event Action<IItemSetRule> OnValueChanged;
        
        public const float SLOT_HEIGHT = 28;
        public const float HEADERS_HEIGHT = 75;
        public const float STATE_HEIGHT = 22;
        public const float OTHERS_HEIGHT = 105;
        public static float DefaultHeight => SLOT_HEIGHT*3 + OTHERS_HEIGHT;
        
        protected bool m_Selected;
        protected IItemSetRule m_ItemSetRule;
        
        protected InventorySystemDatabase m_InventorySystemDatabase;
        protected VisualElement m_Container;

        public IItemSetRule ItemSetRule => m_ItemSetRule;

        public virtual string TitleSuffix => "";

        public ItemSetRuleBaseField(InventorySystemDatabase database)
        {
            m_InventorySystemDatabase = database;
            
            m_Container = new VisualElement();
            Add(m_Container);
        }
        
        public virtual float GetHeight(bool selected)
        {
            return DefaultHeight;
        }
        
        /// <summary>
        /// Update the visuals.
        /// </summary>
        /// <param name="newItemSetRule">The new value.</param>
        public virtual void Refresh(IItemSetRule newItemSetRule, bool selected)
        {
            m_Selected = selected;
            m_ItemSetRule = newItemSetRule;
            m_Container.Clear();
        }

        protected void HandleValueChanged()
        {
            OnValueChanged?.Invoke(m_ItemSetRule);
        }
    }
    
    public class ItemSetRuleObjectContainerField : ItemSetRuleBaseField
    {
        protected ItemSetRuleObjectContainer m_ItemSetRuleObjectContainer;
        
        protected ObjectField m_ObjectField;
        protected Label m_Label;

        public override float GetHeight(bool selected)
        {
            return 100;
        }

        public ItemSetRuleObjectContainerField(InventorySystemDatabase database) : base(database)
        {
            m_ObjectField = new ObjectField("Item Set Rule Object");
            m_ObjectField.objectType = typeof(ItemSetRuleObject);
            m_ObjectField.RegisterValueChangedCallback(evt =>
            {
                m_ItemSetRuleObjectContainer.ItemSetRuleObject = evt.newValue as ItemSetRuleObject;
                HandleValueChanged();
            });
            
            m_Label = new Label("Inherit the ItemSetRuleObject script to create custom Item Set Rules.");
        }

        public override void Refresh(IItemSetRule newItemSetRule, bool selected)
        {
            m_ItemSetRuleObjectContainer = newItemSetRule as ItemSetRuleObjectContainer;
            
            base.Refresh(newItemSetRule, selected);

            if (m_ItemSetRuleObjectContainer?.ItemSetRuleObject == null) {
                m_Container.Add(m_Label);
            }
            
            m_ObjectField.SetValueWithoutNotify(m_ItemSetRuleObjectContainer?.ItemSetRuleObject);
            m_Container.Add(m_ObjectField);
        }
    }

    public class ItemSetRuleNotSupportedTypeField : ItemSetRuleBaseField
    {
        public ItemSetRuleNotSupportedTypeField(InventorySystemDatabase database) : base(database)
        {
            Add(new Label("This Type of Item Set Rule is not supported: "+m_ItemSetRule));
        }
    }

    public abstract class ItemSetRuleWithSlotsField : ItemSetRuleBaseField
    {
        protected ItemSetRule m_ItemSetRuleWithSlots;

        protected TextField m_State;
        protected Toggle m_DefaultField;
        protected Toggle m_EnabledField;
        protected Toggle m_CanSwitchToField;
        protected IntegerField m_DisabledIndexField;
        protected StatesReorderableList<ItemSet> m_States;

        public override string TitleSuffix
        {
            get
            {
                if (m_ItemSetRuleWithSlots == null) {
                    return "";
                }
                
                var stateText = string.IsNullOrWhiteSpace(m_ItemSetRuleWithSlots.State) ? "" : $" ('{m_ItemSetRuleWithSlots.State}')";
                return stateText;
            }
        }

        public abstract int SlotCount { get; }

        public ItemSetRuleWithSlotsField(InventorySystemDatabase database) : base(database)
        {
            m_State = new TextField("State");
            m_State.RegisterValueChangedCallback(evt =>
            {
                m_ItemSetRuleWithSlots.State = evt.newValue;
                HandleValueChanged();
            });
            
            m_DefaultField = new Toggle("Default");
            m_DefaultField.RegisterValueChangedCallback(evt =>
            {
                m_ItemSetRuleWithSlots.Default = evt.newValue;
                HandleValueChanged();
            });
            
            m_EnabledField = new Toggle("Enabled");
            m_EnabledField.RegisterValueChangedCallback(evt =>
            {
                m_ItemSetRuleWithSlots.Enabled = evt.newValue;
                HandleValueChanged();
            });
            
            m_CanSwitchToField = new Toggle("Can Switch To");
            m_CanSwitchToField.RegisterValueChangedCallback(evt =>
            {
                m_ItemSetRuleWithSlots.CanSwitchTo = evt.newValue;
                HandleValueChanged();
            });
            
            m_DisabledIndexField = new IntegerField("DisabledIndex");
            m_DisabledIndexField.RegisterValueChangedCallback(evt =>
            {
                m_ItemSetRuleWithSlots.DisabledIndex = evt.newValue;
                HandleValueChanged();
            });

            m_States = new StatesReorderableList<ItemSet>((newValue) =>
            {
                m_ItemSetRuleWithSlots.States = newValue;
                HandleValueChanged();
            });
        }

        public override float GetHeight(bool selected)
        {
            if (SlotCount < 0) {
                return DefaultHeight;
            }
            
            if (selected) {
                return SLOT_HEIGHT * SlotCount 
                       + STATE_HEIGHT * m_ItemSetRuleWithSlots.States.Length
                       + HEADERS_HEIGHT 
                       + OTHERS_HEIGHT;
            } else {
                return SLOT_HEIGHT*SlotCount + HEADERS_HEIGHT;
            }
        }
        
        /// <summary>
        /// Update the visuals.
        /// </summary>
        /// <param name="newItemSetRule">The new value.</param>
        public override void Refresh(IItemSetRule newItemSetRule, bool selected)
        {
            base.Refresh(newItemSetRule, selected);

            Refresh(newItemSetRule as ItemSetRule, selected);
        }
        
        /// <summary>
        /// Update the visuals.
        /// </summary>
        /// <param name="newItemSetRule">The new value.</param>
        public virtual void Refresh(ItemSetRule newItemSetRule, bool selected)
        {
            m_ItemSetRuleWithSlots = newItemSetRule;

            
            if (m_ItemSetRuleWithSlots == null) {
                m_Container.Add(new Label("The Item Set Rule is null"));
                return;
            }
            
            m_States.Refresh(m_ItemSetRuleWithSlots.States);

            if (!selected) {
                AddSlotContent();
                return;
            }

            m_State.SetValueWithoutNotify(m_ItemSetRuleWithSlots.State);
            m_DefaultField.SetValueWithoutNotify(m_ItemSetRuleWithSlots.Default);
            m_EnabledField.SetValueWithoutNotify(m_ItemSetRuleWithSlots.Enabled);
            m_CanSwitchToField.SetValueWithoutNotify(m_ItemSetRuleWithSlots.CanSwitchTo);
            m_DisabledIndexField.SetValueWithoutNotify(m_ItemSetRuleWithSlots.DisabledIndex);

            m_Container.Add(m_State);
            AddSlotContent();
            m_Container.Add(m_DefaultField);
            m_Container.Add(m_EnabledField);
            m_Container.Add(m_CanSwitchToField);
            m_Container.Add(m_DisabledIndexField);
            m_Container.Add(m_States);
        }

        protected abstract void AddSlotContent();
    }
    
    public class ItemSetRuleWithCategoriesField : ItemSetRuleWithSlotsField
    {
        protected ItemSetRuleWithCategories m_ItemSetRuleWithCategories;
        
        protected ItemCategorySlotReorderableList m_ItemCategories;

        public ItemSetRuleWithCategoriesField(InventorySystemDatabase database) : base(database)
        {
            m_ItemCategories = new ItemCategorySlotReorderableList("Item Category Slots", m_InventorySystemDatabase, () =>
                {
                    if (m_ItemSetRuleWithCategories?.ItemCategorySlots == null) {
                        return new ItemCategory[0];
                    }
                    return m_ItemSetRuleWithCategories.ItemCategorySlots;
                },
                (value) =>
                {
                    m_ItemSetRuleWithCategories.ItemCategorySlots = value;
                    HandleValueChanged();
                });
        }

        public override int SlotCount
        {
            get { return m_ItemSetRuleWithCategories?.ItemCategorySlots?.Length ?? -1; }
        }

        /// <summary>
        /// Update the visuals.
        /// </summary>
        /// <param name="newItemSetRule">The new value.</param>
        public override void Refresh(ItemSetRule newItemSetRule, bool selected)
        {
            m_ItemSetRuleWithCategories = newItemSetRule as ItemSetRuleWithCategories;
            m_ItemCategories.Refresh();
            base.Refresh(newItemSetRule, selected);
        }

        protected override void AddSlotContent()
        {
            m_Container.Add(m_ItemCategories);
        }
    }

    public class ItemCategorySlotReorderableList : VisualElement
    {
        protected InventorySystemDatabase m_Database;
        Func<ItemCategory[]> m_GetObject;
        private Action<ItemCategory[]> m_SetObjects;

        protected List<ItemCategory> m_List;
        protected ReorderableList m_ReorderableList;

        // <summary>
        public ItemCategorySlotReorderableList(string title, InventorySystemDatabase database,
            Func<ItemCategory[]> getObject, Action<ItemCategory[]> setObjects)
        {
            m_Database = database;
            m_GetObject = getObject;
            m_SetObjects = setObjects;

            var array = m_GetObject.Invoke();
            m_List = array == null ? new List<ItemCategory>() : new List<ItemCategory>(array);

            m_ReorderableList = new ReorderableList(
                m_List,
                (parent, index) =>
                {
                    var listElement = new ItemCategoryListElement(m_Database);
                    listElement.Index = index;
                    listElement.OnValueChanged += OnValueChanged;
                    parent.Add(listElement);
                }, (parent, index) =>
                {
                    var listElement = parent.ElementAt(0) as ItemCategoryListElement;
                    listElement.Index = index;
                    listElement.Refresh(m_ReorderableList.ItemsSource[index] as ItemCategory);
                }, (parent) =>
                {
                    parent.Add(new Label(title));
                }, (index) => { return 25f; },
                (index) =>
                {
                    //nothing
                }, null, null,
                (i1, i2) =>
                {
                    var element1 = m_ReorderableList.ListItems[i1].ItemContents.ElementAt(0) as ItemCategoryListElement;
                    element1.Index = i1;
                    var element2 = m_ReorderableList.ListItems[i2].ItemContents.ElementAt(0) as ItemCategoryListElement;
                    element2.Index = i2;
                    m_SetObjects.Invoke(m_List.ToArray());
                });
            Add(m_ReorderableList);
        }

        /// <summary>
        /// Serialize and update the visuals.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="value">The value.</param>
        private void OnValueChanged(int index, ItemCategory value)
        {
            m_List[index] = value;
            m_SetObjects.Invoke(m_List.ToArray());
            m_ReorderableList.Refresh(m_List);
        }

        public void Refresh()
        {
            var array = m_GetObject.Invoke();
            m_List = array == null ? new List<ItemCategory>() : new List<ItemCategory>(array);
            
            m_ReorderableList.Refresh(m_List);
        }

        /// The list element for the tabs.
        /// </summary>
        public class ItemCategoryListElement : InventoryObjectListElement<ItemCategory>
        {
            protected VisualElement m_Container;
            protected Label m_SlotLabel;
            protected ItemCategoryField m_CategoryObjectField;

            /// <summary>
            /// The list element.
            /// </summary>
            public ItemCategoryListElement(InventorySystemDatabase database) : base(database)
            {
                m_Container = new VisualElement();
                m_Container.style.flexDirection = FlexDirection.Row;
                
                m_SlotLabel = new Label("Slot");
                m_Container.Add(m_SlotLabel);
                
                m_CategoryObjectField = new ItemCategoryField(
                    "",
                    database, new (string, Action<ItemCategory>)[]
                    {
                        ("Set Category", (x) =>
                        {
                            HandleValueChanged(x);
                        })
                    },
                    (x) => true);
                
                
                m_Container.Add(m_CategoryObjectField);
                Add(m_Container);
            }

            /// <summary>
            /// Update the visuals.
            /// </summary>
            /// <param name="value">The new value.</param>
            public override void Refresh(ItemCategory value)
            {
                m_SlotLabel.text = "Slot " + Index;
                m_CategoryObjectField.Refresh(value);
            }
        }
    }
    
    public class ItemSetRuleWithDefinitionsField : ItemSetRuleWithSlotsField
    {
        protected ItemSetRuleWithDefinitions m_ItemSetRuleWithDefinitions;
        
        protected ItemDefinitionSlotReorderableList m_ItemDefinitions;

        public ItemSetRuleWithDefinitionsField(InventorySystemDatabase database) : base(database)
        {
            m_ItemDefinitions = new ItemDefinitionSlotReorderableList("Item Definition Slots", m_InventorySystemDatabase, () =>
                {
                    if (m_ItemSetRuleWithDefinitions?.ItemDefinitionSlots == null) {
                        return new ItemDefinition[0];
                    }
                    return m_ItemSetRuleWithDefinitions.ItemDefinitionSlots;
                },
                (value) =>
                {
                    m_ItemSetRuleWithDefinitions.ItemDefinitionSlots = value;
                    HandleValueChanged();
                });
        }

        public override int SlotCount
        {
            get { return m_ItemSetRuleWithDefinitions?.ItemDefinitionSlots.Count ?? -1; }
        }

        /// <summary>
        /// Update the visuals.
        /// </summary>
        /// <param name="newItemSetRule">The new value.</param>
        public override void Refresh(ItemSetRule newItemSetRule, bool selected)
        {
            m_ItemSetRuleWithDefinitions = newItemSetRule as ItemSetRuleWithDefinitions;
            m_ItemDefinitions.Refresh();
            base.Refresh(newItemSetRule, selected);
        }

        protected override void AddSlotContent()
        {
            m_Container.Add(m_ItemDefinitions);
        }
    }
    
    public class ItemDefinitionSlotReorderableList : VisualElement
    {
        protected InventorySystemDatabase m_Database;
        Func<ItemDefinition[]> m_GetObject;
        private Action<ItemDefinition[]> m_SetObjects;

        protected List<ItemDefinition> m_List;
        protected ReorderableList m_ReorderableList;

        // <summary>
        public ItemDefinitionSlotReorderableList(string title, InventorySystemDatabase database,
            Func<ItemDefinition[]> getObject, Action<ItemDefinition[]> setObjects)
        {
            m_Database = database;
            m_GetObject = getObject;
            m_SetObjects = setObjects;

            var array = m_GetObject.Invoke();
            m_List = array == null ? new List<ItemDefinition>() : new List<ItemDefinition>(array);

            m_ReorderableList = new ReorderableList(
                m_List,
                (parent, index) =>
                {
                    var listElement = new ItemDefinitionListElement(m_Database);
                    listElement.Index = index;
                    listElement.OnValueChanged += OnValueChanged;
                    parent.Add(listElement);
                }, (parent, index) =>
                {
                    var listElement = parent.ElementAt(0) as ItemDefinitionListElement;
                    listElement.Index = index;
                    listElement.Refresh(m_ReorderableList.ItemsSource[index] as ItemDefinition);
                }, (parent) =>
                {
                    parent.Add(new Label(title));
                }, (index) => { return 25f; },
                (index) =>
                {
                    //nothing
                }, null, null,
                (i1, i2) =>
                {
                    var element1 = m_ReorderableList.ListItems[i1].ItemContents.ElementAt(0) as ItemDefinitionListElement;
                    element1.Index = i1;
                    var element2 = m_ReorderableList.ListItems[i2].ItemContents.ElementAt(0) as ItemDefinitionListElement;
                    element2.Index = i2;
                    m_SetObjects.Invoke(m_List.ToArray());
                });
            Add(m_ReorderableList);
        }

        /// <summary>
        /// Serialize and update the visuals.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="value">The value.</param>
        private void OnValueChanged(int index, ItemDefinition value)
        {
            m_List[index] = value;
            m_SetObjects.Invoke(m_List.ToArray());
            m_ReorderableList.Refresh(m_List);
        }

        public void Refresh()
        {
            var array = m_GetObject.Invoke();
            m_List = array == null ? new List<ItemDefinition>() : new List<ItemDefinition>(array);
            
            m_ReorderableList.Refresh(m_List);
        }

        /// The list element for the tabs.
        /// </summary>
        public class ItemDefinitionListElement : InventoryObjectListElement<ItemDefinition>
        {
            protected VisualElement m_Container;
            protected Label m_SlotLabel;
            protected ItemDefinitionField m_DefinitionObjectField;

            /// <summary>
            /// The list element.
            /// </summary>
            public ItemDefinitionListElement(InventorySystemDatabase database) : base(database)
            {
                m_Container = new VisualElement();
                m_Container.style.flexDirection = FlexDirection.Row;
                
                m_SlotLabel = new Label("Slot");
                m_Container.Add(m_SlotLabel);
                
                m_DefinitionObjectField = new ItemDefinitionField(
                    "",
                    database, new (string, Action<ItemDefinition>)[]
                    {
                        ("Set Definition", (x) =>
                        {
                            HandleValueChanged(x);
                        })
                    },
                    (x) => true);
                
                
                m_Container.Add(m_DefinitionObjectField);
                Add(m_Container);
            }

            /// <summary>
            /// Update the visuals.
            /// </summary>
            /// <param name="value">The new value.</param>
            public override void Refresh(ItemDefinition value)
            {
                m_SlotLabel.text = "Slot " + Index;
                m_DefinitionObjectField.Refresh(value);
            }
        }
    }
}