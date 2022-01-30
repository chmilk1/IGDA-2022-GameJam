using Entities;
using UnityEngine;

namespace Gameplay
{
    [CreateAssetMenu(menuName = "Item/MaxHealth", fileName = "MaxHealthUpgrade", order = 0)]
    public class MaxHealthUpgrade : ShopItemModel
    {
        [SerializeField] private int extraHealth;
        
        public override void ApplyTo(GameObject player)
        {
            if (player.TryGetComponent(out Health health))
                health.MaxHealth += extraHealth;
        }
    }
}