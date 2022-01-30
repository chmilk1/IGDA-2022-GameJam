using System.Collections;
using System.Threading.Tasks;
using Entities;
using UnityEngine;

namespace Gameplay
{
    // Can spawn things into the game.
    // Use for spawning enemies, a restock station, or a boss.
    
    // todo: integrate into wave system being worked on
    
    public class Wave : MonoBehaviour
    {
        [SerializeField] private Health[] prefabsToSpawn;
        [SerializeField] private Health player;

        private int _remainingEnemies;
        private bool _playerIsDead;
        
        private void Awake()
        {
            _remainingEnemies = prefabsToSpawn.Length;
            player.onDeath.AddListener(OnPlayerDeath);
        }

        public async Task<bool> Run()
        {
            StartCoroutine(SpawnEnemies());
            return await WaitForEnd();
        }

        private IEnumerator SpawnEnemies()
        {
            foreach (var health in prefabsToSpawn)
            {
                Health newEnemy = Instantiate(health);
                newEnemy.onDeath.AddListener(OnEnemyDeath);
                
                yield return null;
            }
        }

        private async Task<bool> WaitForEnd()
        {
            while (_remainingEnemies > 0)
            {
                if (_playerIsDead)
                    return false;

                await Task.Delay(500);
            }

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