using Opsive.Shared.Inventory;
using Opsive.UltimateInventorySystem.Core;
using Opsive.UltimateInventorySystem.Core.DataStructures;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Item = Opsive.UltimateCharacterController.Items.Item;

[Serializable]
public struct AmmoData
{
    [SerializeField]  private DynamicItemDefinition m_ItemDefinition;
    [SerializeField] private int m_ClipSize;
    [SerializeField]  private int m_ClipRemaining;

    public ItemDefinition ItemDefinition => m_ItemDefinition;
    public int ClipSize => m_ClipSize;
    public int ClipRemaining => m_ClipRemaining;
    public static AmmoData None => new AmmoData(null,-1,-1);

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="itemDefinition">The ammo item definition.</param>
    /// <param name="clipSize">The clip size.</param>
    /// <param name="clipRemaining">The remaining amount.</param>
    public AmmoData(ItemDefinition itemDefinition, int clipSize, int clipRemaining)
    {
        m_ItemDefinition = itemDefinition;
        m_ClipSize = clipSize;
        m_ClipRemaining = clipRemaining;
    }
    
    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="itemDefinition">The ammo item definition.</param>
    /// <param name="clipSize">The clip size.</param>
    /// <param name="clipRemaining">The remaining amount.</param>
    public AmmoData(ItemDefinitionBase itemDefinition, int clipSize, int clipRemaining)
    {
        m_ItemDefinition = itemDefinition as ItemDefinition;
        m_ClipSize = clipSize;
        m_ClipRemaining = clipRemaining;
    }
    
    /// <summary>
    /// Constructor, copy.
    /// </summary>
    /// <param name="other">The other ammo data amount to copy.</param>
    public AmmoData(AmmoData other)
    {
        m_ItemDefinition = other.ItemDefinition;
        m_ClipSize = other.ClipSize;
        m_ClipRemaining = other.ClipRemaining;
    }

    /// <summary>
    /// To string.
    /// </summary>
    /// <returns>The string.</returns>
    public override string ToString()
    {
        var originalName = m_ItemDefinition.OriginalSerializedName;
        
        string definitionName = m_ItemDefinition.HasValue ?
            m_ItemDefinition.Value.name :
            string.IsNullOrWhiteSpace(originalName) ?
                "NULL":
                originalName;
        return $"{ClipRemaining}/{ClipSize} {definitionName}";
    }
}