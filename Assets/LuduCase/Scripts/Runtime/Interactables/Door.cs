using UnityEngine;
using LuduCase.Runtime.Core;
using LuduCase.Runtime.Player; 

namespace LuduCase.Runtime.Interactables
{
    public class Door : MonoBehaviour, IInteractable
    {
        #region Fields

        [Header("Settings")]
        [SerializeField] private bool m_IsLocked;
        [SerializeField] private string m_LockedMessage = "Locked - Key Required";
        [SerializeField] private float m_OpenAngle = 90f;
        [SerializeField] private float m_Speed = 2f;

        [Header("Audio")]
        [SerializeField] private AudioSource m_AudioSource;
        [SerializeField] private AudioClip m_OpenSound;
        [SerializeField] private AudioClip m_CloseSound;
        [SerializeField] private AudioClip m_LockedSound;

        [Header("Lock Settings")]
        [Tooltip("Bu kapýyý açmak için gereken anahtar (Boþsa anahtar istemez).")]
        [SerializeField] private ItemData m_RequiredKey;

        // Runtime state
        private bool m_IsOpen;
        private Quaternion m_ClosedRotation;
        private Quaternion m_OpenRotation;

        #endregion

        #region IInteractable Implementation

        public InteractionType InteractionType => InteractionType.Toggle;

        public string InteractionPrompt
        {
            get
            {
                if (m_IsLocked) return m_LockedMessage;
                return m_IsOpen ? "Press E to Close" : "Press E to Open";
            }
        }

        public bool CanInteract(GameObject interactor)
        {
            
            return true;
        }

        public void Interact(GameObject interactor)
        {
            if (m_IsLocked)
            {
                TryUnlock(interactor);
            }
            else
            {
                ToggleDoor();
            }
        }

        #endregion

        #region Unity Methods

        private void Awake()
        {
            m_ClosedRotation = transform.localRotation;
            m_OpenRotation = Quaternion.Euler(0, m_OpenAngle, 0) * m_ClosedRotation;
        }

        private void Update()
        {
            Quaternion targetRotation = m_IsOpen ? m_OpenRotation : m_ClosedRotation;
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, Time.deltaTime * m_Speed);
        }

        #endregion

        #region Methods

        private void TryUnlock(GameObject interactor)
        {
            
           
            if (m_RequiredKey == null)
            {
                Debug.Log("Bu kapý kilitli ama uygun bir anahtar tanýmlanmamýþ. (Belki Switch ile açýlýr?)");
                PlaySound(m_LockedSound);
                return; 
                
            }

            
            Inventory inventory = interactor.GetComponent<Inventory>();
            if (inventory != null && inventory.HasItem(m_RequiredKey))
            {
                Debug.Log($"Door unlocked with {m_RequiredKey.ItemName}!");
                m_IsLocked = false;
                ToggleDoor();
            }
            else
            {
                Debug.Log("You don't have the key!");
                PlaySound(m_LockedSound);
                
            }
        }

        public void ToggleDoor()
        {
            m_IsOpen = !m_IsOpen;
            PlaySound(m_IsOpen ? m_CloseSound : m_OpenSound);
        }

        // Baþka scriptlerden çaðýrmak için
        public void ForceUnlock()
        {
            m_IsLocked = false;
        }

        /// <summary>
        /// Kapýyý doðrudan açar (Switch entegrasyonu için).
        /// </summary>
        public void Open()
        {
            if (!m_IsLocked)
            {
                m_IsOpen = true;
                PlaySound(m_OpenSound);
            }
        }

        /// <summary>
        /// Kapýyý doðrudan kapatýr (Switch entegrasyonu için).
        /// </summary>
        public void Close()
        {
            m_IsOpen = false;
            PlaySound(m_CloseSound);
        }

        private void PlaySound(AudioClip clip)
        {
            if (m_AudioSource != null && clip != null)
            {
                m_AudioSource.PlayOneShot(clip);
            }
        }
        #endregion
    }
}