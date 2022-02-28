using Entities;
using UnityEngine;

namespace Gameplay
{
    [CreateAssetMenu(menuName = "Item/FullHeal", fileName = "FullHeal", order = 0)]
    public class FullHeal : ShopItemModel
    {
        public override void ApplyTo(GameObject player)
        {
            if (player.TryGetComponent(out Health health))
                health.Heal(health.MaxHealth);
        }
    }
}