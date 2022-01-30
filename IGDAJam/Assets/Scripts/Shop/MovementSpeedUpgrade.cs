using Entities;
using UnityEngine;

namespace Gameplay
{
    [CreateAssetMenu(menuName = "Item/MovementSpeedUpgrade", fileName = "MovementSpeedUpgrade", order = 0)]
    public class MovementSpeedUpgrade : ShopItemModel
    {
        [SerializeField] private float percentIncrease;
        
        public override void ApplyTo(GameObject player)
        {
            if (player.TryGetComponent(out InputMovement movement))
                movement.Multiplier += percentIncrease;
        }
    }
}