using UnityEngine;
using LuduCase.Runtime.Core;

namespace LuduCase.Runtime.Interactables
{
    /// <summary>
    /// Basýlý tutularak açýlan sandýk sýnýfý.
    /// </summary>
    public class Chest : MonoBehaviour, IInteractable
    {
        #region Fields

        [Header("Settings")]
        [Tooltip("Sandýk þu an açýk mý?")]
        [SerializeField] private bool m_IsOpen;

        [Tooltip("Kapaðýn dönme hýzý.")]
        [SerializeField] private float m_OpenSpeed = 5f;

        [Header("Visual References")]
        [Tooltip("Kapaðýn dönme noktasý (Pivot).")]
        [SerializeField] private Transform m_Lid;

        [Tooltip("Kapaðýn açýlma açýsý (Genellikle eksi deðer).")]
        [SerializeField] private float m_OpenAngle = -60f;

        
        private Quaternion m_ClosedRotation;
        private Quaternion m_OpenRotation;

        #endregion

        #region IInteractable Implementation

        public InteractionType InteractionType => InteractionType.Hold;

        public string InteractionPrompt => m_IsOpen ? "Opened" : "Hold E to Open";

        public bool CanInteract(GameObject interactor)
        {
            return !m_IsOpen;
        }

        public void Interact(GameObject interactor)
        {
            
            if (!m_IsOpen)
            {
                m_IsOpen = true;
                Debug.Log("Chest Opened!");
            }
        }

        #endregion

        #region Unity Methods

        private void Start()
        {
            if (m_Lid != null)
            {
                
                m_ClosedRotation = m_Lid.localRotation;

                
                m_OpenRotation = Quaternion.Euler(m_OpenAngle, 0, 0) * m_ClosedRotation;
            }
            else
            {
                Debug.LogError($"{name}: Lid reference is missing!");
            }
        }

        private void Update()
        {
            if (m_Lid == null) return;

            Quaternion targetRotation = m_IsOpen ? m_OpenRotation : m_ClosedRotation;

            
            m_Lid.localRotation = Quaternion.Slerp(m_Lid.localRotation, targetRotation, Time.deltaTime * m_OpenSpeed);
        }

        #endregion
    }
}