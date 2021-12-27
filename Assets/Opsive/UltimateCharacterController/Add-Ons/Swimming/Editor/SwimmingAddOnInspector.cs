/// ---------------------------------------------
/// Ultimate Character Controller
/// Copyright (c) Opsive. All Rights Reserved.
/// https://www.opsive.com
/// ---------------------------------------------
namespace Opsive.UltimateCharacterController.AddOns.Swimming.Editor
{
    using Opsive.UltimateCharacterController.AddOns.Shared.Editor;
    using Opsive.UltimateCharacterController.Editor.Managers;
    using UnityEditor.Animations;
    using UnityEngine;

    /// <summary>
    /// Draws the inspector for the swimming add-on.
    /// </summary>
    [OrderedEditorItem("Swimming Pack", 3)]
    public class SwimmingAddOnInspector : AddOnInspector, IAbilityAddOnInspector
    {
        private GameObject m_Character;
        private bool m_AddAbilities = true;
        private bool m_AddAnimations = true;
        private AnimatorController m_AnimatorController;

        public GameObject Character { get { return m_Character; } set { m_Character = value; } }
        public bool AddAbilities { get { return m_AddAbilities; } set { m_AddAbilities = value; } }
        public bool AddAnimations { get { return m_AddAnimations; } set { m_AddAnimations = value; } }
        public AnimatorController AnimatorController { get { return m_AnimatorController; } set { m_AnimatorController = value; } }
        public AnimatorController FirstPersonAnimatorController { get { return null; } set { } }
        public string AddOnName { get { return "Swimming"; } }
        public string AbilityNamespace { get { return "Opsive.UltimateCharacterController.AddOns.Swimming"; } }
        public bool ShowFirstPersonAnimatorController { get { return false; } }

        /// <summary>
        /// Draws the add-on inspector.
        /// </summary>
        public override void DrawInspector()
        {
            AddOnInspectorUtility.DrawInspector(this);
        }
    }
}