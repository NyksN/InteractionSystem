using UnityEngine;

namespace LuduCase.Runtime.Core
{
    /// <summary>
    /// Envanter öðeleri için veri tanýmý.
    /// </summary>
    [CreateAssetMenu(fileName = "New_Item", menuName = "LuduCase/Item Data")]
    public class ItemData : ScriptableObject
    {
        [Tooltip("Eþyanýn adý.")]
        public string ItemName;

        [Tooltip("Envanterde görünecek ikon.")]
        public Sprite Icon;
    }
}