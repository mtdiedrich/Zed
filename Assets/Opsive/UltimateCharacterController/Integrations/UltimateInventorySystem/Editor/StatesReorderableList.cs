/// ---------------------------------------------
/// Ultimate Character Controller
/// Copyright (c) Opsive. All Rights Reserved.
/// https://www.opsive.com
/// ---------------------------------------------

namespace Opsive.UltimateCharacterController.Integrations.UltimateInventorySystem.Editor
{
    using Opsive.Shared.Editor.UIElements;
    using Opsive.Shared.StateSystem;
    using Opsive.UltimateInventorySystem.Storage;
    using Opsive.UltimateInventorySystem.Utility;
    using System;
    using System.Collections.Generic;
    using UnityEditor;
    using UnityEditor.UIElements;
    using UnityEngine;
    using UnityEngine.UIElements;
    using Opsive.Shared.Utility;

    public class StatesReorderableList<T> : VisualElement
    {
        private const string c_EditorPrefsLastPresetPathKey = "Opsive.Shared.Editor.Inspectors.LastPresetPath";

        private Action<State[]> m_SetObjects;

        protected VisualElement m_Header;
        protected List<State> m_List;
        protected ReorderableList m_ReorderableList;

        // <summary>
        public StatesReorderableList(Action<State[]> setObjects)
        {
            m_SetObjects = setObjects;

            m_Header = new VisualElement();
            m_Header.AddToClassList("states-reorderable-list__header");
            m_Header.Add(new Label("State Name"));
            m_Header.Add(new Label("Preset"));
            m_Header.Add(new Label("Blocked By"));
            
            m_List = new List<State>();

            m_ReorderableList = new ReorderableList(
                m_List,
                (parent, index) =>
                {
                    var listElement = new StateListElement();
                    listElement.Index = index;
                    listElement.OnValueChanged += OnValueChanged;
                    parent.Add(listElement);
                }, (parent, index) =>
                {
                    if(index<0 || index >= m_ReorderableList.ItemsSource.Count){return;}
                    
                    var listElement = parent.ElementAt(0) as StateListElement;
                    listElement.Index = index;
                    listElement.Refresh(m_ReorderableList.ItemsSource[index] as State);
                }, (parent) =>
                {
                    parent.Add(m_Header);
                }, (index) => { return 18f; },
                (index) =>
                {
                    //nothing
                }, () =>
                {
                    //Add existing or new item set preset.
                    var addMenu = new GenericMenu();
                    if (!Application.isPlaying) {
                        addMenu.AddItem(new GUIContent("Add Existing Preset"), false,
                            () =>
                            {
                                AddStateWithPreset(GetExistingPreset(typeof(T)));
                            });
                    }
                    addMenu.AddItem(new GUIContent("Create New Preset"), false, () =>
                    {
                        AddStateWithPreset(CreatePreset(typeof(T)));
                    });
                    addMenu.ShowAsContext();
                    
                }, (index) =>
                {
                    if (index < 0 || index >= m_List.Count) { return; }

                    m_List.RemoveAt(index);

                    UpdateBlockListChoices();
                    InvokeListChanged();
                },
                (i1, i2) =>
                {
                    var element1 = m_ReorderableList.ListItems[i1].ItemContents.ElementAt(0) as StateListElement;
                    var element2 = m_ReorderableList.ListItems[i2].ItemContents.ElementAt(0) as StateListElement;

                    //don't switch if one is default
                    if (element1.State.Default || element2.State.Default) {
                        InvokeListChanged();
                        return;
                    }
                    
                    element1.Index = i1;
                    element2.Index = i2;
                    InvokeListChanged();
                });
            Add(m_ReorderableList);
        }

        private void AddStateWithPreset(Preset preset)
        {
            if (preset == null) { return; }

            var startName = typeof(T).Name + "Preset";
            var name = preset.name;
            if (!string.IsNullOrEmpty(name.Replace(startName, ""))) { name = name.Replace(startName, ""); }

            var state = new State(name, preset, null);
            m_List.Insert(0, state);

            UpdateBlockListChoices();
            InvokeListChanged();
        }

        private void InvokeListChanged()
        {
            //The last element must be the default one.
            if (m_List.Count == 0) {
                m_List.Add(new State("Default", true));
            }else if( m_List[m_List.Count - 1].Default == false) {
                for (int i = 0; i < m_List.Count; i++) {
                    if (!m_List[i].Default) { continue; }

                    m_List.RemoveAt(i);
                    break;
                }
                
                m_List.Add(new State("Default", true));
            }
            for (int i = 0; i < m_List.Count; i++) {
                m_List[i].Default = i == m_List.Count-1;
            }
            
            m_SetObjects.Invoke(m_List.ToArray());
        }

        public void Refresh(State[] states)
        {
            m_List.Clear();
            
            m_List.AddRange(states);

            if (m_List.Count == 0 || m_List[m_List.Count - 1].Default == false) {
                InvokeListChanged();
            }
            
            m_ReorderableList.Refresh(m_List);

            UpdateBlockListChoices();
        }

        public void UpdateBlockListChoices()
        {
            var newChoices = new List<string>();
            for (int i = 0; i < m_List.Count; i++) {
                newChoices.Add(m_List[i].Name);
            }
            
            for (int i = 0; i < m_ReorderableList.ListItems.Count; i++) {
                var element = m_ReorderableList.ListItems[i].ItemContents.ElementAt(0) as StateListElement;
                element.UpdateBlockListChoices(newChoices);
            }
        }

        /// <summary>
        /// Serialize and update the visuals.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="value">The value.</param>
        private void OnValueChanged(int index, State value)
        {
            m_List[index] = value;
            InvokeListChanged();
            m_ReorderableList.Refresh(m_List);
        }

        /// <summary>
        /// Adds a new element to the state list which uses an existing preset.
        /// </summary>
        public static Preset GetExistingPreset(System.Type objType)
        {
            // A state must have a preset - open the file panel to select it.
            var path = EditorPrefs.GetString(c_EditorPrefsLastPresetPathKey, Shared.Editor.Inspectors.Utility.InspectorUtility.GetSaveFilePath());
            path = EditorUtility.OpenFilePanelWithFilters("Select Preset", path, new string[] { "Preset", "asset" });
            if (path.Length != 0 && Application.dataPath.Length < path.Length) {
                EditorPrefs.SetString(c_EditorPrefsLastPresetPathKey, System.IO.Path.GetDirectoryName(path));
                // The path is relative to the project.
                path = string.Format("Assets/{0}", path.Substring(Application.dataPath.Length + 1));
                var preset = AssetDatabase.LoadAssetAtPath<PersistablePreset>(path);
                if (preset == null) {
                    Debug.LogError($"Error: Unable to add preset. {System.IO.Path.GetFileName(path)} isn't located within the same project directory.");
                    return null;
                }
                // The preset object type has to belong to the same object type.
                if (preset.Data.ObjectType == objType.FullName) {
                    return preset;
                } else {
                    Debug.LogError($"Error: Unable to add preset. {preset.name} ({preset.Data.ObjectType}) doesn't use the same object type ({objType.FullName}).");
                    return null;
                }
            }
            return null;
        }

        /// <summary>
        /// Creates a new preset and adds it to a new state in the list.
        /// </summary>
        public static Preset CreatePreset(System.Type objType)
        {
            //Create an instance of the object type with Activator.CreateInstance(objType)
            var instance = Activator.CreateInstance(objType);
            var preset = PersistablePreset.CreatePreset(instance);
            if (preset != null) {
                var startName = objType.Name + "Preset.asset";
                var path = EditorPrefs.GetString(c_EditorPrefsLastPresetPathKey, Shared.Editor.Inspectors.Utility.InspectorUtility.GetSaveFilePath());
                path = EditorUtility.SaveFilePanel("Save Preset", path, startName, "asset");
                if (path.Length != 0 && Application.dataPath.Length < path.Length) {
                    EditorPrefs.SetString(c_EditorPrefsLastPresetPathKey, System.IO.Path.GetDirectoryName(path));
                    // The path is relative to the project.
                    path = string.Format("Assets/{0}", path.Substring(Application.dataPath.Length + 1));
                    // Do not delete/add if an existing preset already exists to prevent the references from being destroyed.
                    var existingPreset = AssetDatabase.LoadAssetAtPath<Preset>(path);
                    if (existingPreset != null) {
                        EditorUtility.DisplayDialog("Unable to Save Preset", "The preset must reference a unique file name.", "Okay");
                        return null;
                    }

                    AssetDatabase.CreateAsset(preset, path);
                    AssetDatabase.ImportAsset(path);
                    EditorGUIUtility.PingObject(preset);
                    if (!Application.isPlaying) {
                        return preset;
                    }
                }
            }
            return null;
        }

        /// The list element for the tabs.
        /// </summary>
        public class StateListElement : VisualElement
        {
            private const string c_Nothing = "Nothing";
            private const string c_Mixed = "Mixed";
            public event Action<int, State> OnValueChanged;

            protected State m_State;
            public State State => m_State;

            protected VisualElement m_Container;
            protected TextField m_SlotName;
            protected ObjectField m_PresetField;
            protected PopupField<string> m_BlockListField;

            protected List<string> m_BlockListChoices;
            protected List<string> m_BlockList;
            
            public int Index { get; set; }

            /// <summary>
            /// The list element.
            /// </summary>
            public StateListElement()
            {
                m_Container = new VisualElement();
                m_Container.AddToClassList("states-reorderable-list-element");

                m_SlotName = new TextField();
                m_SlotName.RegisterValueChangedCallback(evt =>
                {
                    m_State.Name = evt.newValue;
                    HandleValueChanged();
                });
                m_Container.Add(m_SlotName);

                m_PresetField = new ObjectField();
                m_PresetField.objectType = typeof(Preset);
                m_PresetField.RegisterValueChangedCallback(evt =>
                {
                    m_State.Preset = evt.newValue as Preset;
                    HandleValueChanged();
                });
                m_Container.Add(m_PresetField);
                
                m_BlockList = new List<string>();
                
                m_BlockListChoices = new List<string>();
                m_BlockListChoices.Add(c_Nothing);
                m_BlockListChoices.Add(c_Mixed);
                
                m_BlockListField = new PopupField<string>(m_BlockListChoices, 1,
                    selectedValue =>
                    {
                        if (m_BlockList.Count == 0) {
                            return c_Nothing;
                        }
                        
                        if (m_BlockList.Count == 1) {
                            return m_BlockList[0];
                        }
                        
                        return c_Mixed;
                    },
                    valueInList =>
                    {
                        if (valueInList == c_Nothing || valueInList == c_Mixed) {
                            return valueInList;
                        }
                        
                        if (m_BlockList.Contains(valueInList) == false) {
                            return $"  | {valueInList}";
                        }
                        
                        return $"x | {valueInList}";
                    });
                m_BlockListField.RegisterValueChangedCallback(evt =>
                {
                    if(evt.newValue == c_Mixed){return;}
                    
                    if (evt.newValue == c_Nothing) {
                        m_BlockList.Clear();
                    }else if (m_BlockList.Contains(evt.newValue)) {
                        m_BlockList.Remove(evt.newValue);
                    } else {
                        m_BlockList.Add(evt.newValue);
                    }

                    m_State.BlockList = m_BlockList.ToArray();
                    HandleValueChanged();
                });
                m_Container.Add(m_BlockListField);

                Add(m_Container);
            }

            /// <summary>
            /// Update the visuals.
            /// </summary>
            /// <param name="state">The new value.</param>
            public void Refresh(State state)
            {
                m_State = state;
                if (m_State == null) {
                    m_SlotName.value = "NULL";
                    return;
                }
                
                m_SlotName.SetValueWithoutNotify(m_State.Name);
                m_PresetField.SetValueWithoutNotify(m_State.Preset);
                m_BlockList.Clear();

                if (m_State.BlockList != null) {
                    m_BlockList.AddRange(m_State.BlockList);
                }
            }

            public void UpdateBlockListChoices(List<string> choices)
            {
                m_BlockListChoices.Clear();
                m_BlockListChoices.Add(c_Nothing);
                m_BlockListChoices.AddRange(choices);
                m_BlockListChoices.Add(c_Mixed);
                
                if(m_State == null){return;}

                var change = false;
                for (int i = m_BlockList.Count - 1; i >= 0; i--) {
                    if(m_BlockList[i] == c_Nothing){ continue; }
                    if(m_BlockList[i] == c_Mixed){ continue; }
                    
                    if (choices.Contains(m_BlockList[i]) == false ) {
                        m_BlockList.RemoveAt(i);
                        change = true;
                    }
                }
                
                string popupFieldValue = c_Nothing;
                if (m_BlockList.Count == 0) {
                    popupFieldValue = c_Nothing;
                }else if (m_BlockList.Count == 1) {
                    popupFieldValue =  m_BlockList[0];
                } else {
                    popupFieldValue = c_Mixed;
                }
                m_BlockListField.SetValueWithoutNotify(popupFieldValue);
                
                if(change == false){return;}
                
                m_State.BlockList = m_BlockList.ToArray();
                HandleValueChanged();
            }
            
            public void HandleValueChanged()
            {
                if (m_State.Name == "Default" && m_State.Preset == null) {
                    m_State.Default = true;
                } else {
                    m_State.Default = false;
                }
                
                OnValueChanged?.Invoke(Index, m_State);
            }
        }
    }
}