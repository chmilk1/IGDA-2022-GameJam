using Entities;
using UnityEngine;

namespace DefaultNamespace
{
    public class PlayerShipAnimatorController : MonoBehaviour
    {
        [SerializeField] private Animator mainAnimator;
        [SerializeField] private SpriteRenderer engineSprite;
        [SerializeField] private float engineFadeTime = 1f;
        [SerializeField] private InputMovement inputMovement;
        
        private void Update()
        {
            float alpha = Mathf.MoveTowards(engineSprite.color.a, inputMovement.InputDirection == Vector2.zero ? 0 : 1, 1 / engineFadeTime * Time.deltaTime);
            Color cur = engineSprite.color;
            cur.a = alpha;
            engineSprite.color = cur;
            
            if (inputMovement.InputDirection.x == 0)
                mainAnimator.Play("Idle");
            
            else if (inputMovement.InputDirection.x < 0)
                mainAnimator.Play("Turn Left");
            
            else if (inputMovement.InputDirection.x > 0)
                mainAnimator.Play("Turn Right");
        }
    }
}