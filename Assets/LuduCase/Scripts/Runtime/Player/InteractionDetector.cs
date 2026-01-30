using UnityEngine;
using LuduCase.Runtime.Core; 
using LuduCase.Runtime.UI;   

namespace LuduCase.Runtime.Player
{
    /// <summary>
    /// Oyuncunun nesneleri algýlamasýný, highlight etmesini ve etkileþime geçmesini saðlayan ana sýnýf.
    /// </summary>
    public class InteractionDetector : MonoBehaviour
    {
        #region Fields

        [Header("Detection Settings")]
        [Tooltip("Etkileþim için maksimum mesafe.")]
        [SerializeField] private float m_InteractionRange = 3f;

        [Tooltip("Etkileþime geçilebilecek layerlar.")]
        [SerializeField] private LayerMask m_InteractableLayer;

        [Tooltip("Raycast'in çýkacaðý kamera.")]
        [SerializeField] private Camera m_Camera;

        [Header("UI Reference")]
        [Tooltip("Ekranda mesaj ve bar gösterecek UI yöneticisi.")]
        [SerializeField] private InteractionUI m_InteractionUI;

        // Runtime State
        private IInteractable m_CurrentInteractable; 
        private InteractionHighlight m_CurrentHighlight; 

        private float m_HoldTimer = 0f;
        private bool m_IsHolding;
        private const float k_DefaultHoldDuration = 2f; 

        #endregion

        #region Unity Methods

        private void Awake()
        {
            
            if (m_Camera == null) m_Camera = GetComponentInParent<Camera>();
            if (m_InteractionUI == null) m_InteractionUI = FindFirstObjectByType<InteractionUI>();

            // Hata kontrolü
            if (m_Camera == null) Debug.LogError($"{name}: Camera reference is missing!");
        }

        private void Update()
        {
            DetectInteractable();
            HandleInput();
        }

        private void OnDrawGizmos()
        {
            if (m_Camera != null)
            {
                Gizmos.color = Color.yellow;
                Gizmos.DrawRay(m_Camera.transform.position, m_Camera.transform.forward * m_InteractionRange);
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Raycast atarak nesneleri tarar.
        /// </summary>
        private void DetectInteractable()
        {
            Ray ray = new Ray(m_Camera.transform.position, m_Camera.transform.forward);

            
            float checkDistance = 20f;

            if (Physics.Raycast(ray, out RaycastHit hitInfo, checkDistance, m_InteractableLayer))
            {
                IInteractable interactable = hitInfo.collider.GetComponentInParent<IInteractable>();

                if (interactable != null)
                {
                    
                    float distance = hitInfo.distance;
                    bool inRange = distance <= m_InteractionRange;

                    
                    if (interactable != m_CurrentInteractable)
                    {
                        
                        ClearInteractable();
                        m_CurrentInteractable = interactable;

                        
                        if (m_CurrentInteractable is MonoBehaviour mono)
                        {
                            m_CurrentHighlight = mono.GetComponentInChildren<InteractionHighlight>();
                            if (m_CurrentHighlight != null) m_CurrentHighlight.EnableHighlight();
                        }
                    }

                    
                    if (inRange)
                    {
                        
                        m_InteractionUI?.Show(m_CurrentInteractable.InteractionPrompt);
                    }
                    else
                    {
                        
                        m_InteractionUI?.Show("Too Far");
                        
                    }
                }
                else
                {
                    ClearInteractable();
                }
            }
            else
            {
                ClearInteractable();
            }
        }

        /// <summary>
        /// Girdi (Input) iþlemlerini yönetir.
        /// </summary>
        private void HandleInput()
        {
            if (m_CurrentInteractable == null) return;

            float distance = Vector3.Distance(transform.position, ((MonoBehaviour)m_CurrentInteractable).transform.position);
            if (distance > m_InteractionRange + 0.5f) return;

            // --- HOLD TÜRÜ ---
            if (m_CurrentInteractable.InteractionType == InteractionType.Hold)
            {
               
                if (m_CurrentInteractable.CanInteract(gameObject) && Input.GetKey(KeyCode.E))
                {
                    m_IsHolding = true;
                    m_HoldTimer += Time.deltaTime;

                   
                    float progress = Mathf.Clamp01(m_HoldTimer / k_DefaultHoldDuration);
                    m_InteractionUI?.UpdateProgress(progress);

                   
                    if (m_HoldTimer >= k_DefaultHoldDuration)
                    {
                        m_CurrentInteractable.Interact(gameObject);
                        ResetHold();
                    }
                }
                else
                {
                    
                    if (m_IsHolding) ResetHold();
                }
            }
            // --- INSTANT ve TOGGLE TÜRÜ ---
            else
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    
                    m_CurrentInteractable.Interact(gameObject);
                }
            }
        }

        /// <summary>
        /// Basýlý tutma iþlemini sýfýrlar.
        /// </summary>
        private void ResetHold()
        {
            m_IsHolding = false;
            m_HoldTimer = 0f;
            m_InteractionUI?.UpdateProgress(0);
        }

        /// <summary>
        /// Mevcut etkileþimi temizler, highlight'ý kapatýr ve UI'ý gizler.
        /// </summary>
        private void ClearInteractable()
        {
            if (m_CurrentInteractable != null)
            {
                // Varsa Highlight'ý kapat
                if (m_CurrentHighlight != null)
                {
                    m_CurrentHighlight.DisableHighlight();
                    m_CurrentHighlight = null;
                }

                m_CurrentInteractable = null;
                m_InteractionUI?.Hide();
                ResetHold();
            }
        }

        #endregion
    }
}