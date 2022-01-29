using UnityEngine;
using UnityEngine.InputSystem;

namespace Entities
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class InputMovement : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private float movementSpeed;
        
        private Rigidbody2D _rigidbody2D;
        private Vector2 _inputDirection;
        private Controls _controls;
        
        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _controls = new Controls();
            _controls.Enable();
            
            _controls.Player.Move.performed += ApplyMovement;
            _controls.Player.Move.canceled += ApplyMovement;
        }

        public void ApplyMovement(InputAction.CallbackContext context)
        {
            _inputDirection = context.ReadValue<Vector2>();
            _rigidbody2D.velocity = _inputDirection * movementSpeed;
        }
    }
}