using UnityEngine;
using UnityEngine.Events;

namespace Entities
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class DamageTrigger : MonoBehaviour
    {
        [SerializeField] private DimensionEntity owner;
        [SerializeField] private LayerMask targetLayers;
        [SerializeField] private int damage;

        [SerializeField] private UnityEvent onHit;

        private void OnTriggerStay2D(Collider2D other)
        {
            GameObject target = other.attachedRigidbody.gameObject;
            
            bool isTargetLayer = targetLayers.value == (targetLayers.value | (1 << target.layer));
            bool hasHealth = target.TryGetComponent(out Health health);

            if (isTargetLayer && hasHealth) {

                if (InDifferentDimension(target))
                    return;
                
                health.Damage(damage);
                onHit.Invoke();
            }
        }

        private bool InDifferentDimension(GameObject target)
        {
            return owner != null && !owner.CurrentDimension.IsActive ||
                   target.TryGetComponent(out DimensionEntity entity) &&
                   !entity.CurrentDimension.IsActive;
        }
    }
}