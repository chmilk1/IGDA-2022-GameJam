using Entities;
using UnityEngine;

namespace Gameplay
{
    public abstract class ShopItemModel : ScriptableObject
    {
        [Header("Settings")]
        [SerializeField] public float cost;
        [SerializeField] public string itemName;
        [SerializeField] public string itemDescription;
        
        public abstract void ApplyTo(GameObject player);
    }

    public class MovementSpeedUpgrade : ShopItemModel
    {
        [SerializeField] private float percentIncrease;
        
        public override void ApplyTo(GameObject player)
        {
            if (player.TryGetComponent(out InputMovement movement))
                movement.Multiplier += percentIncrease;
        }
    }

    public class FullHeal : ShopItemModel
    {
        public override void ApplyTo(GameObject player)
        {
            if (player.TryGetComponent(out Health health))
                health.Heal(health.MaxHealth);
        }
    }
    
    public class MaxHealthUpgrade : ShopItemModel
    {
        [SerializeField] private int extraHealth;
        
        public override void ApplyTo(GameObject player)
        {
            if (player.TryGetComponent(out Health health))
                health.MaxHealth += extraHealth;
        }
    }
    
    // public class SpreadUpgrade : ShopItem
    // {
    //     public override void ApplyTo(GameObject player)
    //     {
    //         throw new System.NotImplementedException();
    //     }
    // }
    //
    // public class BulletSpeedUpgrade : ShopItem
    // {
    //     public override void ApplyTo(GameObject player)
    //     {
    //         throw new System.NotImplementedException();
    //     }
    // }
    //
    // public class BulletSizeUpgrade : ShopItem
    // {
    //     public override void ApplyTo(GameObject player)
    //     {
    //         throw new System.NotImplementedException();
    //     }
    // }
}