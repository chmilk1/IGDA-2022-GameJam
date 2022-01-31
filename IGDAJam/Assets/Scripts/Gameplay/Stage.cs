using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using Display = UI.Display;

namespace Gameplay
{
    // Cycles through waves linearly.
    public class Stage : MonoBehaviour
    {
        [SerializeField] private Wave[] waves;
        [SerializeField] private bool autoRun = true;

        private CancellationTokenSource _cts;
        
        private async void Start()
        {
            _cts = new CancellationTokenSource();
            
            if (autoRun == false)
                return;

            bool result = await Run(_cts.Token);
        }

        private void OnDestroy()
        {
            _cts.Cancel();
        }

        /// <summary>
        /// Executes each wave in order.
        /// </summary>
        /// <returns>Whether or not the player beat this stage.</returns>
        public async Task<bool> Run(CancellationToken token)
        {
            foreach (var wave in waves)
            {
                bool completedWave = await wave.Run(token);

                if (completedWave == false || _cts.IsCancellationRequested)
                    return false;
            }

            return true;
        }
    }
}