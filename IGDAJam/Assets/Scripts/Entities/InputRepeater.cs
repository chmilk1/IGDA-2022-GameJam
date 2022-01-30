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
        
        public void HandleFire(InputAction.CallbackContext context)
        {
            if (context.started)
                _holdingFire = true;
            
            else if (context.canceled)
                _holdingFire = false;
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