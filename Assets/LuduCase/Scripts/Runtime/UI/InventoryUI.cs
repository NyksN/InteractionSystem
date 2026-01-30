using UnityEngine;
using UnityEngine.UI;
using LuduCase.Runtime.Core; 

namespace LuduCase.Runtime.UI
{
    public class InventoryUI : MonoBehaviour
    {
        [Header("Settings")]
        [Tooltip("Ýkonlarýn oluþturulacaðý panel (Grid).")]
        [SerializeField] private Transform m_ItemContainer;

        [Tooltip("Ýkon prefabý.")]
        [SerializeField] private GameObject m_ItemIconPrefab;

        /// <summary>
        /// Envantere yeni eklenen eþyanýn ikonunu oluþturur.
        /// </summary>
        public void AddItemToUI(ItemData item)
        {
            if (m_ItemIconPrefab != null && m_ItemContainer != null)
            {
                GameObject newIcon = Instantiate(m_ItemIconPrefab, m_ItemContainer);
                Image imageComp = newIcon.GetComponent<Image>();

                if (imageComp != null)
                {
                    imageComp.sprite = item.Icon;
                }
            }
        }
    }
}