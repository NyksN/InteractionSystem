using UnityEngine;
using LuduCase.Runtime.Core;
using LuduCase.Runtime.Player;

namespace LuduCase.Runtime.Interactables
{
    /// <summary>
    /// Yerden alýnan ve envantere eklenen anahtar nesnesi.
    /// </summary>
    public class KeyPickup : MonoBehaviour, IInteractable
    {
        #region Fields

        [Tooltip("Bu nesne alýndýðýnda envantere eklenecek veri.")]
        [SerializeField] private ItemData m_ItemData;

        #endregion

        #region IInteractable Implementation

        public InteractionType InteractionType => InteractionType.Instant;

        public string InteractionPrompt => $"Pick up {m_ItemData.ItemName}";

        public bool CanInteract(GameObject interactor)
        {
            return true;
        }

        public void Interact(GameObject interactor)
        {
            
            var inventory = interactor.GetComponent<Inventory>();

            if (inventory != null)
            {
                
                inventory.AddItem(m_ItemData);

                
                Destroy(gameObject);
            }
            else
            {
                Debug.LogError("KeyPickup: Interactor does not have an Inventory component!");
            }
        }

        #endregion
    }
}