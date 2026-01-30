using UnityEngine;

namespace LuduCase.Runtime.Player
{
    /// <summary>
    /// CharacterController tabanlý, çarpýþma destekli FPS kontrolcüsü.
    /// </summary>
    [RequireComponent(typeof(CharacterController))]
    public class SimpleFPSController : MonoBehaviour
    {
        #region Fields

        [Header("Movement Settings")]
        [SerializeField] private float m_MoveSpeed = 5f;
        [SerializeField] private float m_LookSensitivity = 2f;
        [SerializeField] private float m_Gravity = -9.81f;

        [Header("References")]
        [SerializeField] private Camera m_Camera;

        private CharacterController m_CharacterController;
        private float m_RotationX = 0f;
        private Vector3 m_Velocity;

        #endregion

        #region Unity Methods

        private void Start()
        {
            m_CharacterController = GetComponent<CharacterController>();

            
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            if (m_Camera == null)
            {
                m_Camera = GetComponentInChildren<Camera>();
            }
        }

        private void Update()
        {
            HandleMouseLook();
            HandleMovement();
        }

        #endregion

        #region Methods

        private void HandleMovement()
        {
            
            if (m_CharacterController.isGrounded && m_Velocity.y < 0)
            {
                m_Velocity.y = -2f; 
            }

            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            
            Vector3 move = transform.right * x + transform.forward * z;

            
            m_CharacterController.Move(move * m_MoveSpeed * Time.deltaTime);

            
            m_Velocity.y += m_Gravity * Time.deltaTime;
            m_CharacterController.Move(m_Velocity * Time.deltaTime);
        }

        private void HandleMouseLook()
        {
            float mouseX = Input.GetAxis("Mouse X") * m_LookSensitivity;
            float mouseY = Input.GetAxis("Mouse Y") * m_LookSensitivity;

            m_RotationX -= mouseY;
            m_RotationX = Mathf.Clamp(m_RotationX, -90f, 90f);

            if (m_Camera != null)
            {
                m_Camera.transform.localRotation = Quaternion.Euler(m_RotationX, 0f, 0f);
            }

            transform.Rotate(Vector3.up * mouseX);
        }

        #endregion
    }
}