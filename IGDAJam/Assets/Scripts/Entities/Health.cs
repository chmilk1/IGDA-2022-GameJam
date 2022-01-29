using UnityEngine;
using UnityEngine.Events;

namespace Entities
{
    public class Health : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private int hitPoints = 1;

        [Space(20f)]
        [SerializeField] private UnityEvent<Health> onDeath;
        [SerializeField] private UnityEvent<Health> onDamage;

        public int RemainingHitPoints => hitPoints;

        public void Damage(int amount)
        {
            if (hitPoints - amount <= 0)
                onDeath.Invoke(this);

            hitPoints -= amount;
            onDamage.Invoke(this);
        }
    }
}