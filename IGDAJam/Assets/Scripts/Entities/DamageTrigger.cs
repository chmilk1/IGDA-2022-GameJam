using UnityEngine;
using UnityEngine.Events;

namespace Entities
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class DamageTrigger : MonoBehaviour
    {
        [SerializeField] private LayerMask targetLayers;
        [SerializeField] private int damage;

        [SerializeField] private UnityEvent onHit;

        private void OnTriggerEnter2D(Collider2D other)
        {
            bool isTargetLayer = targetLayers.value == (targetLayers.value | (1 << other.gameObject.layer));
            bool hasHealth = other.TryGetComponent(out Health health);

            if (isTargetLayer && hasHealth) {
                health.Damage(damage);
                onHit.Invoke();
            }
        }
    }
}