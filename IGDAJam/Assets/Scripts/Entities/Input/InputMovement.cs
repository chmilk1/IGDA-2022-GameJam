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

        public Vector2 InputDirection { get; private set; }
        public float Multiplier { get; set; } = 1f;
        
        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        public void ApplyMovement(InputAction.CallbackContext context)
        {
            InputDirection = context.ReadValue<Vector2>();
            _rigidbody2D.velocity = InputDirection * (movementSpeed * Multiplier);
        }
    }
}