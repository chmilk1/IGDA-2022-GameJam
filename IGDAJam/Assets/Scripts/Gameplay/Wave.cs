using System.Collections;
using System.Threading;
using System.Threading.Tasks;
using Entities;
using UnityEngine;
using UnityEngine.Events;
using Display = UI.Display;
using Random = UnityEngine.Random;

namespace Gameplay
{
    // Can spawn things into the game.
    // Use for spawning enemies, a restock station, or a boss.
    
    // todo: integrate into wave system being worked on
    
    public class Wave : MonoBehaviour
    {
        [SerializeField] private float xScreenBoundOffset;
        [SerializeField] private float spawnDelay = 1f;
        [SerializeField] private Health[] prefabsToSpawn;
        [SerializeField] private Health player;

        [SerializeField] private UnityEvent onStart;
        [SerializeField] private UnityEvent onEnd;
        
        private int _remainingEnemies;
        private bool _playerIsDead;
        private Vector2 _screenBounds;
        
        private void Start()
        {
            if (Camera.main != null)
                _screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
            
            _remainingEnemies = prefabsToSpawn.Length;
            player.onDeath.AddListener(OnPlayerDeath);
        }

        public async Task<bool> Run(CancellationToken token)
        {
            StartCoroutine(SpawnEnemies());
            return await WaitForEnd(token);
        }

        private IEnumerator SpawnEnemies()
        {
            foreach (var health in prefabsToSpawn)
            {
                float xSpawn = _screenBounds.y + xScreenBoundOffset;
                float ySpawn = Random.Range(-_screenBounds.x, _screenBounds.x);
                var spawnPos = new Vector2(ySpawn, xSpawn);
                
                Health newEnemy = Instantiate(health);
                newEnemy.transform.position = spawnPos;
                newEnemy.onDeath.AddListener(OnEnemyDeath);
                
                yield return new WaitForSeconds(spawnDelay);
            }
        }

        private async Task<bool> WaitForEnd(CancellationToken token)
        {
            onStart.Invoke();
            
            while (_remainingEnemies > 0)
            {

                if (_playerIsDead)
                {
                    onEnd.Invoke();
                    return false;
                }

                await Task.Delay(500, token);
            }

            onEnd.Invoke();
            return true;
        }

        private void OnEnemyDeath(Health _)
        {
            _remainingEnemies--;
        }

        private void OnPlayerDeath(Health _)
        {
            _playerIsDead = true;
        }
    }
}