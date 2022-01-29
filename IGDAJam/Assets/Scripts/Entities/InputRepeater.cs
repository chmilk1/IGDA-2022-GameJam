using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Entities
{
    public class InputRepeater : MonoBehaviour
    {
        [SerializeField] private float fireSpeed = 1f;
        [SerializeField] private UnityEvent repeatEvent;
        
        private float _lastShotTime;
        private bool _holdingFire;
        private Controls _controls;
        
        private void Awake()
        {
            _controls = new Controls();
            _controls.Enable();
            _controls.Player.Fire.started += HandleFire;
            _controls.Player.Fire.canceled += HandleFire;
        }
        
        private void OnDestroy()
        {
            _controls.Disable();
            _controls.Dispose();
            _controls = null;
        }

        private void HandleFire(InputAction.CallbackContext context)
        {
            _holdingFire = context.started;
        }

        private void Update()
        {
            if (_holdingFire && Time.time - _lastShotTime > fireSpeed)
            {
                _lastShotTime = Time.time;
                repeatEvent.Invoke();
            }
        }
    }
}