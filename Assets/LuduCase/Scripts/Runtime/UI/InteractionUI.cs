using TMPro;
using UnityEngine;
using UnityEngine.UI; // Text ve Slider için

namespace LuduCase.Runtime.UI
{
    /// <summary>
    /// Etkileþim durumunu ekranda gösteren UI yöneticisi.
    /// </summary>
    public class InteractionUI : MonoBehaviour
    {
        #region Fields

        [Header("UI References")]
        [Tooltip("Mesaj metni.")]
        [SerializeField] private TextMeshProUGUI m_PromptText; 

        [Tooltip("Basýlý tutma barý.")]
        [SerializeField] private Slider m_ProgressBar;

        [Tooltip("Tüm paneli açýp kapatmak için.")]
        [SerializeField] private GameObject m_PanelRoot;

        #endregion

        #region Unity Methods

        private void Awake()
        {
            
            Hide();
        }

        #endregion

        #region Methods

        public void Show(string prompt)
        {
            m_PanelRoot.SetActive(true);
            m_PromptText.text = prompt;
            m_ProgressBar.gameObject.SetActive(false); 
        }

        public void Hide()
        {
            m_PanelRoot.SetActive(false);
        }

        public void UpdateProgress(float progress)
        {
            if (progress > 0)
            {
                m_ProgressBar.gameObject.SetActive(true);
                m_ProgressBar.value = progress;
            }
            else
            {
                m_ProgressBar.gameObject.SetActive(false);
            }
        }

        #endregion
    }
}