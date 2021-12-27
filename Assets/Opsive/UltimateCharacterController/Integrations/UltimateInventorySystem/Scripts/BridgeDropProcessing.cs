/// ---------------------------------------------
/// Ultimate Character Controller
/// Copyright (c) Opsive. All Rights Reserved.
/// https://www.opsive.com
/// ---------------------------------------------

namespace Opsive.UltimateCharacterController.Integrations.UltimateInventorySystem
{
    using Opsive.Shared.Game;
    using Opsive.Shared.Inventory;
    using Opsive.UltimateCharacterController.Items.Actions;
    using Opsive.UltimateInventorySystem.Core;
    using Opsive.UltimateInventorySystem.Core.AttributeSystem;
    using Opsive.UltimateInventorySystem.Core.DataStructures;
    using Opsive.UltimateInventorySystem.Core.InventoryCollections;
    using UnityEngine;

    /// <summary>
    /// The Bridge Drop processing is used to drop items with the character.
    /// </summary>
    public class BridgeDropProcessing
    {
        protected CharacterInventoryBridge m_InventoryBridge;

        public bool DropUsingCharacterItemWhenPossible => m_InventoryBridge.DropUsingCharacterItemWhenPossible;
        public ItemCollection DefaultItemCollection => m_InventoryBridge.DefaultItemCollection;
        public ItemCollectionGroup EquippableItemCollections => m_InventoryBridge.EquippableItemCollections;
        public InventoryItemSetManager ItemSetManager => m_InventoryBridge.ItemSetManager;
        public string PrefabAttributeName => m_InventoryBridge.SingleItemPrefabAttributeName;
        public string MultiItemPrefabsAttributeName => m_InventoryBridge.MultiItemPrefabsAttributeName;
        public GameObject InventoryItemPickupPrefab => m_InventoryBridge.InventoryItemPickupPrefab;

        public BridgeEquippableProcessing BridgeEquippableProcessing =>
            m_InventoryBridge.BridgeEquippableProcessing;

        protected Vector3 m_UnequipDropPosition;
        protected Quaternion m_UnequipDropRotation;
        
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="inventoryBridge">The inventory bridge.</param>
        public BridgeDropProcessing(CharacterInventoryBridge inventoryBridge)
        {
            m_InventoryBridge = inventoryBridge;
        }
        
        /// <summary>
        /// The Drop ItemAction has been triggered.
        /// </summary>
        /// <param name="item">The Item that should be dropped.</param>
        public virtual Inventory DropInventoryPickup(ItemInfo itemInfo, bool forceDrop, bool removeItemOnDrop)
        {
            var inventoryItem = itemInfo.Item;
            if (inventoryItem == null || itemInfo.Amount <= 0) {
                return null;
            }
            
            var characterItem = m_InventoryBridge.GetCharacterItem(inventoryItem);
            var doCharacterItemDrop = DropUsingCharacterItemWhenPossible && characterItem != null && characterItem.ActivePerspectiveItem != null;

            //Always remove first and drop after.
            
            if (doCharacterItemDrop) {
                //This value must be set to zero to prevent the Item from Dropping the item on unequip which drops the item twice.
                characterItem.UnequipDropAmount = 0;
                var itemObject = characterItem.GetVisibleObject().transform;
                m_UnequipDropPosition = itemObject.position;
                m_UnequipDropRotation = itemObject.rotation;
                
                if (removeItemOnDrop) { RemoveOnDrop(itemInfo); }
                return DropCharacterItem(itemInfo, characterItem, true);
            }
            
            if (removeItemOnDrop) { RemoveOnDrop(itemInfo); }
            return SpawnDropItem(itemInfo);
        }

        /// <summary>
        /// Remove the item when dropping the item.
        /// </summary>
        /// <param name="itemInfo">The item info dropped.</param>
        private void RemoveOnDrop(ItemInfo itemInfo)
        {
            if (EquippableItemCollections.Contains(itemInfo.ItemCollection)) {
                BridgeEquippableProcessing.AboutToDrop(itemInfo);
                EquippableItemCollections.RemoveItem(itemInfo);
            } else if (itemInfo.ItemCollection == DefaultItemCollection) {
                DefaultItemCollection.RemoveItem(itemInfo);
            } else {
                var result = m_InventoryBridge.Inventory.GetItemInfo(itemInfo.Item);
                if (result.HasValue) {
                    BridgeEquippableProcessing.AboutToDrop(itemInfo);
                    itemInfo = (itemInfo.Amount, result.Value);
                    itemInfo.ItemCollection.RemoveItem(itemInfo);
                }
            }
        }

        /// <summary>
        /// Spawn the drop instance, also known as the item pickup.
        /// </summary>
        /// <param name="itemInfo">The item info to drop.</param>
        /// <returns>The Inventory of the item pickup dropped.</returns>
        protected virtual Inventory SpawnDropItem(ItemInfo itemInfo)
        {
            // Consumable and non character items do not have an item associated with them.
            if (InventoryItemPickupPrefab == null) {
                Debug.LogError(
                    $"Error: The InventoryItemPickup prefab is missing. The item {itemInfo} cannot be dropped.");
                return null;
            }

            var (position,rotation) = GetDropPositionAnRotation();
            var spawnedInventoryPickupObject = ObjectPool.Instantiate(InventoryItemPickupPrefab, position, rotation);

            var pickupInventory = spawnedInventoryPickupObject.GetCachedComponent<Inventory>();
            if (pickupInventory == null) {
                Debug.LogError(
                    $"Error: The prefab {InventoryItemPickupPrefab.name} must have an Inventory component.");
                return null;
            }

            pickupInventory.MainItemCollection.RemoveAll();
            pickupInventory.AddItem(itemInfo);

            var inventoryPickup = spawnedInventoryPickupObject.GetCachedComponent<InventoryItemPickup>();
            inventoryPickup?.Initialize(true);

            return pickupInventory;
        }

        /// <summary>
        /// Get the drop position and rotation.
        /// </summary>
        /// <returns>Tupple of the position and rotation.</returns>
        private (Vector3,Quaternion) GetDropPositionAnRotation()
        {
            var dropPositionOffset = m_InventoryBridge.ItemDropPositionOffset;
            var characterTransform = m_InventoryBridge.transform;

            // Spawn the inventory pickup, remove any children it has and place the drop prefab as a child.
            var localOffset = characterTransform.InverseTransformDirection(new Vector3(-dropPositionOffset.x,
                dropPositionOffset.y, -dropPositionOffset.z));

            var position = characterTransform.position + localOffset;
            var rotation = characterTransform.rotation;
            
            return (position,rotation);
        }

        /// <summary>
        /// Drop the character item.
        /// </summary>
        /// <param name="itemInfo">The item info.</param>
        /// <param name="characterItem">The character item.</param>
        /// <param name="forceDrop">Force drop.</param>
        /// <returns>the inventory of the pickup dropped.</returns>
        private Inventory DropCharacterItem(ItemInfo itemInfo, Items.Item characterItem, bool forceDrop)
        {
            Debug.Log("Character Drop");
            // If a drop prefab exists then the character should drop a prefab of the item so it can later be picked up.
            if (characterItem.DropPrefab == null) {
                if (characterItem.DropItemEvent != null) { characterItem.DropItemEvent.Invoke(); }
                return null;
            }

            Vector3 dropPosition = m_UnequipDropPosition;
            Quaternion dropRotation = m_UnequipDropRotation;

            var spawnedObject =
                ObjectPool.Instantiate(characterItem.DropPrefab, dropPosition, dropRotation);


            var pickupInventory = spawnedObject.GetCachedComponent<Inventory>();
            if (pickupInventory != null) {
                pickupInventory.MainItemCollection.RemoveAll();
                pickupInventory.AddItem(itemInfo);

                var inventoryPickup = spawnedObject.GetCachedComponent<InventoryItemPickup>();
                inventoryPickup?.Initialize(true);
            }

            // The ItemPickup may have a TrajectoryObject attached instead of a Rigidbody.
            var trajectoryObject = spawnedObject.GetCachedComponent<Objects.TrajectoryObject>();
            if (trajectoryObject != null) {
                var velocity = characterItem.CharacterLocomotion.Velocity;
#if ULTIMATE_CHARACTER_CONTROLLER_VR
                        if (item.HandHandler != null) {
                            velocity += item.HandHandler.GetVelocity(m_SlotID) * item.DropVelocityMultiplier;
                        }
#endif
                trajectoryObject.Initialize(velocity, characterItem.CharacterLocomotion.Torque.eulerAngles,
                    characterItem.Character);
            }

            if (characterItem.DropItemEvent != null) {
                characterItem.DropItemEvent.Invoke();
            }

            return pickupInventory;
        }
    }
}