using UnityEngine;
using UnityEngine.Events;
using LuduCase.Runtime.Core;

namespace LuduCase.Runtime.Interactables
{
    /// <summary>
    /// Baþka nesneleri tetiklemek için kullanýlan þalter/kol.
    /// </summary>
    public class Switch : MonoBehaviour, IInteractable
    {
        #region Fields

        [Header("Settings")]
        [Tooltip("Þalter açýk mý?")]
        [SerializeField] private bool m_IsOn;

        [Tooltip("Kolun döneceði açý.")]
        [SerializeField] private float m_HandleAngle = 45f;

        [Header("Events")]
        [Tooltip("Þalter durumu deðiþtiðinde tetiklenecek olaylar.")]
        public UnityEvent OnSwitchToggle;

        [Tooltip("Þalter açýldýðýnda tetiklenir.")]
        public UnityEvent OnSwitchActivate;

        [Tooltip("Þalter kapandýðýnda tetiklenir.")]
        public UnityEvent OnSwitchDeactivate;

        [Header("Visual References")]
        [Tooltip("Hareket edecek kol parçasý (Opsiyonel).")]
        [SerializeField] private Transform m_HandleVisual;

        private Quaternion m_InitialRotation;
        private Quaternion m_ActiveRotation;

        #endregion

        #region IInteractable Implementation

        public InteractionType InteractionType => InteractionType.Toggle;

        public string InteractionPrompt => m_IsOn ? "Turn Off" : "Turn On";

        public bool CanInteract(GameObject interactor)
        {
            return true;
        }

        public void Interact(GameObject interactor)
        {
            ToggleSwitch();
        }

        #endregion

        #region Unity Methods

        private void Start()
        {
            if (m_HandleVisual != null)
            {
                m_InitialRotation = m_HandleVisual.localRotation;
                m_ActiveRotation = Quaternion.Euler(m_HandleAngle, 0, 0) * m_InitialRotation;

                // Baþlangýç durumunu ayarla
                UpdateVisual(true);
            }
        }

        #endregion

        #region Methods

        private void ToggleSwitch()
        {
            m_IsOn = !m_IsOn;

            
            OnSwitchToggle?.Invoke();

            
            if (m_IsOn)
            {
                OnSwitchActivate?.Invoke();
            }
            else
            {
                OnSwitchDeactivate?.Invoke();
            }

            UpdateVisual();
        }

        private void UpdateVisual(bool instant = false)
        {
            if (m_HandleVisual == null) return;

            Quaternion targetRot = m_IsOn ? m_ActiveRotation : m_InitialRotation;

            if (instant)
            {
                m_HandleVisual.localRotation = targetRot;
            }
            else
            {
                
                
                m_HandleVisual.localRotation = targetRot;
            }
        }

        #endregion
    }
}