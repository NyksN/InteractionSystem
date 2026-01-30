using UnityEngine;

namespace LuduCase.Runtime.Core
{
    /// <summary>
    /// Oyuncu nesneye baktýðýnda materyalin rengini açarak highlight efekti verir.
    /// </summary>
    [RequireComponent(typeof(Renderer))]
    public class InteractionHighlight : MonoBehaviour
    {
        [Header("Highlight Settings")]
        [SerializeField] private Color m_HighlightColor = Color.white;
        [SerializeField] private float m_Intensity = 0.2f;

        private Renderer m_Renderer;
        private Material m_OriginalMaterial;
        private Color m_OriginalColor;

        private void Awake()
        {
            m_Renderer = GetComponent<Renderer>();
            m_OriginalMaterial = m_Renderer.material; // Instance oluþturur
            m_OriginalColor = m_OriginalMaterial.color;
        }

        public void EnableHighlight()
        {
            if (m_Renderer != null)
            {
                
                m_Renderer.material.color = m_OriginalColor + (m_HighlightColor * m_Intensity);
            }
        }

        public void DisableHighlight()
        {
            if (m_Renderer != null)
            {
                m_Renderer.material.color = m_OriginalColor;
            }
        }
    }
}