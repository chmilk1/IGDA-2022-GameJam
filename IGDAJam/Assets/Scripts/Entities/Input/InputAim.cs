using UnityEngine;
using UnityEngine.InputSystem;

namespace Entities
{
    // todo: mouse support
    public class InputAim : MonoBehaviour
    {
        [SerializeField] private Transform aimTransform;
        [SerializeField] private Camera cam;
        
        private Vector2 _aimDirection;
        private bool _hasController;
        
        private void Update()
        {
            if (_hasController)
                aimTransform.up = _aimDirection.normalized;

            else
            {
                Vector3 currentPos = cam.ScreenToWorldPoint(Mouse.current.position.ReadValue());
                currentPos.z = 0;

                aimTransform.up = currentPos - transform.position;
            }
        }

        public void HandleAimX(InputAction.CallbackContext context)
        {
            _hasController = true;
            _aimDirection.x = context.ReadValue<float>();
        }
        
        public void HandleAimY(InputAction.CallbackContext context)
        {
            _hasController = true;
            _aimDirection.y = context.ReadValue<float>();
        }
    }
}