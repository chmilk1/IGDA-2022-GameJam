using FMODUnity;
using UnityEngine;

namespace Entities
{
    public class PlayerDamageUpdater : MonoBehaviour
    {
        public StudioEventEmitter emitter;
        public Rigidbody2D rb;
        public float maxSpeed;
        public AnimationCurve curve;
        
        private void Update()
        {
            float speedPercent = Mathf.Clamp01(rb.velocity.magnitude / maxSpeed);
            emitter.SetParameter("Speed", curve.Evaluate(speedPercent));
        }
    }
}