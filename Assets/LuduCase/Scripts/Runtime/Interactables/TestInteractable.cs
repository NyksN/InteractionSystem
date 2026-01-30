using UnityEngine;
using LuduCase.Runtime.Core;

namespace LuduCase.Runtime.Interactables
{
    /// <summary>
    /// Etkileþim sistemini test etmek için geçici sýnýf.
    /// </summary>
    public class TestInteractable : MonoBehaviour, IInteractable
    {
        #region Fields

        [SerializeField] private string m_Prompt = "Press E to Test";

        #endregion

        #region IInteractable Implementation

        public InteractionType InteractionType => InteractionType.Instant;

        public string InteractionPrompt => m_Prompt;

        public bool CanInteract(GameObject interactor)
        {
            return true; 
        }

        public void Interact(GameObject interactor)
        {
            Debug.Log($"<color=green>SUCCESS:</color> {name} ile etkileþime geçildi!");

            // Görsel geri bildirim (Rengi rastgele deðiþtir)
            GetComponent<Renderer>().material.color = Random.ColorHSV();
        }

        #endregion
    }
}