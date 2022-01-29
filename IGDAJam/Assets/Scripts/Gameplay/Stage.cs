using System;
using System.Threading.Tasks;
using UnityEngine;

namespace Gameplay
{
    // Cycles through waves linearly.
    public class Stage : MonoBehaviour
    {
        [SerializeField] private Wave[] waves;
        [SerializeField] private bool autoRun = true;
        
        private async void Awake()
        {
            if (autoRun == false)
                return;
            
            bool result = await Run();
            Debug.Log($"Result: {result}");
        }

        /// <summary>
        /// Executes each wave in order.
        /// </summary>
        /// <returns>Whether or not the player beat this stage.</returns>
        public async Task<bool> Run()
        {
            foreach (var wave in waves)
            {
                bool completedWave = await wave.Run();

                if (completedWave == false)
                    return false;
            }

            return true;
        }
    }
}