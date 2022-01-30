using System.Collections;
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
        [SerializeField] public bool isPlayer;
        [SerializeField] public float invulnTime;

        [Space(20f)]
        [SerializeField] public UnityEvent<Health> onDeath;
        [SerializeField] public UnityEvent<Health> onDamage;
        [SerializeField] public UnityEvent<Health> onHeal;

        public int RemainingHitPoints { get; private set; }
        public int MaxHealth { get; set; }

        private bool invuln = false;
        
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
            if (!invuln)
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

                if (isPlayer)
                {
                    invuln = true;
                    StartCoroutine(InvulnTimer());
                }
            }
        }

        private IEnumerator InvulnTimer()
        {
            yield return new WaitForSeconds(invulnTime);
            invuln = false;
        }
    }
}