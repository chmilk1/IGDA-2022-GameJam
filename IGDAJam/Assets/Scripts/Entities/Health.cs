using System.Collections;
using FMODUnity;
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
        [SerializeField] public bool explodes;
        [SerializeField] public GameObject explosion;
        [SerializeField] public bool isPlayer;
        [SerializeField] public float invulnTime;
        [SerializeField] public EventReference damageSound;
        [SerializeField] public EventReference deathSound;

        [Space(20f)]
        [SerializeField] public UnityEvent<Health> onDeath;
        [SerializeField] public UnityEvent<Health> onDamage;
        [SerializeField] public UnityEvent<Health> onHeal;

        public int RemainingHitPoints { get; private set; }
        public int MaxHealth { get; set; }

        private bool invuln = false;
        
        private void Awake()
        {
            MaxHealth = hitPoints;
            RemainingHitPoints = MaxHealth;
        }

        public void Heal(int amount)
        {
            RemainingHitPoints = Mathf.Min(RemainingHitPoints + amount, MaxHealth);
            onHeal.Invoke(this);
        }
        
        public void Damage(int amount)
        {
            if (!invuln)
            {
                if (RemainingHitPoints - amount <= 0)
                {
                    RuntimeManager.PlayOneShot(deathSound);
                    onDeath.Invoke(this);
                    if (explodes)
                    {
                        Instantiate(explosion, this.transform.position, this.transform.rotation);
                    }
                    if (destroyOnDeath)
                        Destroy(gameObject);
                }

                RemainingHitPoints -= amount;
                onDamage.Invoke(this);
                RuntimeManager.PlayOneShot(damageSound);

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