using Opsive.Shared.Inventory;
using Opsive.UltimateCharacterController.Items.Actions;
using Opsive.UltimateInventorySystem.Core;
using Opsive.UltimateInventorySystem.Core.AttributeSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using EventHandler = Opsive.Shared.Events.EventHandler;
using Object = UnityEngine.Object;

/// <summary>
/// The Shootable Weapon Binding is used to bind the clip amount and clip size of the weapon with the attribute on the item.
/// </summary>
public class ShootableWeaponAmmoBinding : MonoBehaviour
{
    
#if !ULTIMATE_CHARACTER_CONTROLLER_SHOOTER
    [Header("WARNING: This component can only be used with the ULTIMATE_CHARACTER_CONTROLLER_SHOOTER.")]
#else
    
    [SerializeField] protected string m_AmmoDataAttributeName = "AmmoData";
    [SerializeField] protected ShootableWeapon m_ShootableWeapon;
    
    protected AmmoData m_AmmoData;

    public string AmmoDataAttributeName
    {
        get => m_AmmoDataAttributeName;
        set => m_AmmoDataAttributeName = value;
    }

    /// <summary>
    /// The ammo data is used by the bound attribute to update the shootable weapon or attribute values.
    /// </summary>
    public AmmoData AmmoData {
        get
        {
            IItemIdentifier consumableItemIdentifier = m_ShootableWeapon.GetConsumableItemIdentifier();

            if (consumableItemIdentifier == null) {
                Debug.Log("consumableItemIdentifier is null");
                return m_AmmoData;
            }
            
            m_AmmoData = new AmmoData(
                m_ShootableWeapon.GetConsumableItemIdentifier()?.GetItemDefinition(),
                m_ShootableWeapon.ClipSize,
                m_ShootableWeapon.GetConsumableItemIdentifierAmount()
                );
            
            return m_AmmoData;
        }
        set
        {
            m_AmmoData = value;

            SetAmmoToShootableWeapon(m_AmmoData);
        }
    }

    private void SetAmmoToShootableWeapon(AmmoData value)
    {
        if (value.ItemDefinition != null) {
            m_ShootableWeapon.SetConsumableItemIdentifier(value.ItemDefinition.DefaultItem);
        }
        
        m_ShootableWeapon.SetConsumableItemIdentifierAmount(value.ClipRemaining);
        m_ShootableWeapon.ClipSize = value.ClipSize;
    }

    protected ItemObject m_ItemObject;
    protected Item m_Item;

    protected AttributeBinding<AmmoData> m_AmmoDataAttributeBinding;

    public ItemObject ItemObject => m_ItemObject;
    public Item Item => m_Item;
    
    void Awake()
    {
        if (m_ShootableWeapon == null) {
            m_ShootableWeapon = GetComponent<ShootableWeapon>();
        }

        m_AmmoDataAttributeBinding = new AttributeBinding<AmmoData>(m_AmmoDataAttributeName, this, "AmmoData");
        m_AmmoDataAttributeBinding.CreatePropertyDelegates();
        
        if (m_ItemObject != null) { return; }

        var itemObject = GetComponent<ItemObject>();
        if (itemObject != null) {
            SetItemObject(itemObject);
        }
    }

    /// <summary>
    /// Set the item object.
    /// </summary>
    /// <param name="itemObject">The item object.</param>
    public virtual void SetItemObject(ItemObject itemObject)
    {
        if (m_ItemObject != null) {
            Opsive.Shared.Events.EventHandler.UnregisterEvent(m_ItemObject, EventNames.c_ItemObject_OnItemChanged, SetItem);
            return;
        }

        m_ItemObject = itemObject;
        if (m_ItemObject == null) { return; }

        EventHandler.RegisterEvent(m_ItemObject, EventNames.c_ItemObject_OnItemChanged, SetItem);
        SetItem();
    }
    
    private void SetItem()
    {
        if (m_ItemObject.isActiveAndEnabled) {
            SetItem(m_ItemObject.Item);
        } else {
            SetItem(null);
        }
    }

    /// <summary>
    /// Set the item.
    /// </summary>
    /// <param name="item">The item.</param>
    private void SetItem(Item item)
    {
        if (m_Item == item && m_Item == null) { return; }
        
        m_AmmoDataAttributeBinding.UnBindAttribute();
        m_AmmoData = AmmoData.None;

        m_Item = item;
        if (m_Item == null || m_Item.IsInitialized == false) {
            m_Item = null;
            return;
        }

        var ammoDataAttribute = m_Item.GetAttribute<Attribute<AmmoData>>(m_AmmoDataAttributeName);

        if (ammoDataAttribute == null) { return; }
        
        //A new Ammo Data must be created otherwise multiple items could be sharing the same ammo data object.
        AmmoData ammoData = ammoDataAttribute.GetValue();
        m_AmmoData = ammoData;
        if (ammoDataAttribute.VariantType != VariantType.Override) {
            m_AmmoData = new AmmoData(m_AmmoData);
            ammoDataAttribute.SetOverrideValue(m_AmmoData);
        }

        SetAmmoToShootableWeapon(m_AmmoData);
        m_AmmoDataAttributeBinding.BindAttribute(ammoDataAttribute);
    }

    private void OnDestroy()
    {
        if (m_ItemObject != null) {
            Opsive.Shared.Events.EventHandler.UnregisterEvent(m_ItemObject, EventNames.c_ItemObject_OnItemChanged, SetItem);
        }
    }
    
#endif
}
