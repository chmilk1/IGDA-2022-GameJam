using FMODUnity;
using UnityEngine;

namespace Entities
{
    public class PlayerDamageUpdater : MonoBehaviour
    {
        public StudioEventEmitter emitter;
        public Health playerHealth;
        public AnimationCurve curve;
        
        private void Update()
        {
            float healthPercent = Mathf.Clamp01((float) playerHealth.RemainingHitPoints / playerHealth.MaxHealth);
            emitter.SetParameter("Health", curve.Evaluate(healthPercent));
        }
    }
}