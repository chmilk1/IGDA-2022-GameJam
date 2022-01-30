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

        public float Multiplier { get; set; } = 1f;
        
        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        public void ApplyMovement(InputAction.CallbackContext context)
        {
            _inputDirection = context.ReadValue<Vector2>();
            _rigidbody2D.velocity = _inputDirection * (movementSpeed * Multiplier);
        }
    }
}