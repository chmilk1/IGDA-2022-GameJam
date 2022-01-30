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
        [SerializeField] public UnityEvent<Health> onHeal;

        public int RemainingHitPoints { get; private set; }
        public int MaxHealth { get; set; }
        
        private void Start()
        {
            MaxHealth = hitPoints;
            RemainingHitPoints = MaxHealth;
            
            if (healthDisplay != null)
                healthDisplay.UpdateText(RemainingHitPoints.ToString());
        }

        public void Heal(int amount)
        {
            RemainingHitPoints = Mathf.Min(RemainingHitPoints + amount, MaxHealth);
            onHeal.Invoke(this);
            
            if (healthDisplay != null)
                healthDisplay.UpdateText(RemainingHitPoints.ToString());
        }
        
        public void Damage(int amount)
        {
            if (RemainingHitPoints - amount <= 0)
            {
                onDeath.Invoke(this);
                
                if (destroyOnDeath)
                    Destroy(gameObject);
            }

            RemainingHitPoints -= amount;
            onDamage.Invoke(this);
            
            if (healthDisplay != null)
                healthDisplay.UpdateText(RemainingHitPoints.ToString());
        }
    }
}