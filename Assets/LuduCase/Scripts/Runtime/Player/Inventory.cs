using System.Collections.Generic;
using UnityEngine;
using LuduCase.Runtime.Core;

namespace LuduCase.Runtime.Player
{
    /// <summary>
    /// Oyuncunun topladýðý eþyalarý tutan basit envanter sistemi.
    /// </summary>
    public class Inventory : MonoBehaviour
    {
        #region Fields

        [Header("Debug")]
        [Tooltip("Toplanan eþyalarýn listesi.")]
        [SerializeField] private List<ItemData> m_Items = new List<ItemData>();
        [SerializeField] private LuduCase.Runtime.UI.InventoryUI m_InventoryUI;
        #endregion

        #region Methods

        /// <summary>
        /// Envantere yeni bir eþya ekler.
        /// </summary>
        /// <param name="item">Eklenecek eþya.</param>
        public void AddItem(ItemData item)
        {
            if (!m_Items.Contains(item))
            {
                m_Items.Add(item);
                Debug.Log($"Inventory: Added {item.ItemName}");

                // UI'ý güncelle
                if (m_InventoryUI != null)
                {
                    m_InventoryUI.AddItemToUI(item);
                }
            }
        }

        /// <summary>
        /// Belirtilen eþyanýn envanterde olup olmadýðýný kontrol eder.
        /// </summary>
        /// <param name="item">Aranan eþya.</param>
        /// <returns>Varsa true.</returns>
        public bool HasItem(ItemData item)
        {
            return m_Items.Contains(item);
        }

        #endregion
    }
}