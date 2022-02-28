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