/// ---------------------------------------------
/// Ultimate Inventory System
/// Copyright (c) Opsive. All Rights Reserved.
/// https://www.opsive.com
/// ---------------------------------------------

namespace Opsive.UltimateCharacterController.Integrations.UltimateInventorySystem
{
    /// <summary>
    /// A list of event names used by the EventHandler. The name syntax is defined as:
    /// c_TargetObjectType_EventDescription_Parameter1Type_Parameter2Type_...
    /// </summary>
    public static class IntegrationEventNames
    {
        //The Inventory Bridge Saver will start loading the items. GameoObject = Character.
        public const string c_GameObject_OnInventoryBridgeSaverWillLoad = "OnInventoryBridgeSaverWillLoad";
        //The Inventory Bridge Saver finished loading the items. GameoObject = Character.
        public const string c_GameObject_OnInventoryBridgeSaverLoaded = "OnInventoryBridgeSaverLoaded";

        //This event is executed just before the item sets are updated. The list parameter comes with
        //information about the item sets that will be added, removed and kept. GameObject = Character. 
        public const string c_GameObject_ItemSetsWillUpdate_ListOfItemSetStateInfo =
            "GameObject_ItemSetsWillUpdate_ListOfItemSetStateInfo";
        
        //Event executed when the Item Sets have been updated. GameObject = Character.
        public const string c_GameObject_ItemSetsUpdated = "GameObject_ItemSetsUpdated";
    }
}
