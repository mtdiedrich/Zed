/// ---------------------------------------------
/// Ultimate Character Controller
/// Copyright (c) Opsive. All Rights Reserved.
/// https://www.opsive.com
/// ---------------------------------------------

namespace Opsive.UltimateCharacterController.Integrations.UltimateInventorySystem.Editor
{
    using Opsive.UltimateCharacterController.Editor.Managers;

    /// <summary>
    /// Draws an inspector that can be used within the Inspector Manager.
    /// </summary>
    [OrderedEditorItem("Ultimate Inventory System", 1)]
    public class InventorySystemIntegration : IntegrationInspector
    {
        /// <summary>
        /// Draws the integration inspector.
        /// </summary>
        public override void DrawInspector()
        {
            ManagerUtility.DrawControlBox("Setup Location", null,
                "The integration is located within the Ultimate Inventory System Manager.",
                true, "Open",
                Opsive.UltimateInventorySystem.Editor.Managers.InventoryMainWindow.ShowIntegrationsManagerWindow, null);
        }

    }
}