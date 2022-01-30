using UnityEngine;

namespace Gameplay
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class ShopTrigger : MonoBehaviour
    {
        [SerializeField] private GameObject shopObject;

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                // todo: switch input to ui 
                // todo: maybe import leantween for easy animations
                Instantiate(shopObject);
            }
        }
    }
}