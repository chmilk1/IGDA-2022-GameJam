using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Entities
{
    public class InputRepeater : MonoBehaviour
    {
        [SerializeField] private float attackCooldown = 1f;
        [SerializeField] private UnityEvent repeatEvent;
        
        private float _cooldownTime;
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
            if (_holdingFire && _cooldownTime <= 0)
            {
                _cooldownTime = attackCooldown;
                repeatEvent.Invoke();
            }

            else _cooldownTime -= Time.deltaTime;
        }
    }
}