﻿using UnityEngine;
using UnityEngine.Events;

namespace Entities
{
    public class Health : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private int hitPoints = 1;

        [Space(20f)]
        [SerializeField] public UnityEvent<Health> onDeath;
        [SerializeField] public UnityEvent<Health> onDamage;

        public int RemainingHitPoints => hitPoints;
        public bool IsDead => hitPoints <= 0;

        public void Damage(int amount)
        {
            if (hitPoints - amount <= 0)
                onDeath.Invoke(this);

            hitPoints -= amount;
            onDamage.Invoke(this);
        }
    }
}