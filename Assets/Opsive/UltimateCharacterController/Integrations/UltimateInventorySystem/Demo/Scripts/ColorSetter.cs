
namespace Opsive.UltimateCharacterController.Integrations.UltimateInventorySystem.Demo
{
    using System.Collections.Generic;
    using UnityEngine;

    /// <summary>
    /// Sets the color of the specified material.
    /// </summary>
    public class ColorSetter : MonoBehaviour
    {
        public Color Color {
            get { 
                if (m_Materials == null || m_Materials.Count == 0) { return Color.white; }
                return m_Materials[0].color; 
            }
            set {
                if (m_Materials == null) { return; }
                for (int i = 0; i < m_Materials.Count; ++i) {
                    m_Materials[i].color = value;
                }
            }
        }

        private List<Material> m_Materials;

        /// <summary>
        /// Find the material that should be set.
        /// </summary>
        public void Awake()
        {
            var perspectiveItems = GetComponents<Items.PerspectiveItem>();
            for (int i = 0; i < perspectiveItems.Length; ++i) {
                var renderer = perspectiveItems[i].GetVisibleObject().GetComponent<MeshRenderer>();
                SetRendererMaterial(renderer);
            }

            var localRenderer = GetComponentInChildren<MeshRenderer>();
            SetRendererMaterial(localRenderer);
        }

        /// <summary>
        /// Set the material for the renderer.
        /// </summary>
        /// <param name="renderer">The renderer.</param>
        protected void SetRendererMaterial(Renderer renderer)
        {
            if (renderer == null) { return; }
            if (m_Materials == null) { m_Materials = new List<Material>(); }

            m_Materials.Add(renderer.material);
        }
    }
}