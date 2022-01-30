using UnityEngine;
using UnityEngine.InputSystem;

namespace Entities
{
    // todo: mouse support
    public class InputAim : MonoBehaviour
    {
        [SerializeField] private Transform aimTransform;
        
        private Vector2 _aimDirection;

        private void Update()
        {
            aimTransform.up = _aimDirection.normalized;
        }

        public void HandleAimX(InputAction.CallbackContext context)
        {
            _aimDirection.x = context.ReadValue<float>();
        }
        
        public void HandleAimY(InputAction.CallbackContext context)
        {
            _aimDirection.y = context.ReadValue<float>();
        }
    }
}