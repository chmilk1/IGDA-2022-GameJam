using UnityEngine;
using UnityEngine.Events;
using Display = UI.Display;

namespace Entities
{
    public class Health : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private int hitPoints = 1;
        [SerializeField] private bool destroyOnDeath = true;
        [SerializeField] private Display healthDisplay;
        
        [Space(20f)]
        [SerializeField] public UnityEvent<Health> onDeath;
        [SerializeField] public UnityEvent<Health> onDamage;

        public int RemainingHitPoints => hitPoints;

        private void Start()
        {
            if (healthDisplay != null)
                healthDisplay.UpdateText(hitPoints.ToString());
        }

        public void Damage(int amount)
        {
            if (hitPoints - amount <= 0)
            {
                onDeath.Invoke(this);
                
                if (destroyOnDeath)
                    Destroy(gameObject);
            }

            hitPoints -= amount;
            onDamage.Invoke(this);
            
            if (healthDisplay != null)
                healthDisplay.UpdateText(hitPoints.ToString());
        }
    }
}