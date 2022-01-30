﻿using System.Collections;
using System.Threading;
using System.Threading.Tasks;
using Entities;
using Unity.Mathematics;
using UnityEngine;
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
        [SerializeField] private Display waveDisplay;

        private int _remainingEnemies;
        private bool _playerIsDead;
        private Vector2 screenBounds;
        
        private void Awake()
        {
            if (Camera.main != null)
                screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
            
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
                var spawnPos = new Vector2(screenBounds.x + xScreenBoundOffset, Random.Range(-screenBounds.y, screenBounds.y));
                Health newEnemy = Instantiate(health, spawnPos, quaternion.identity);
                newEnemy.onDeath.AddListener(OnEnemyDeath);
                
                yield return new WaitForSeconds(spawnDelay);
            }
        }

        private async Task<bool> WaitForEnd(CancellationToken token)
        {
            while (_remainingEnemies > 0)
            {
                waveDisplay.UpdateText($"{gameObject.name}: Remaining enemies: {_remainingEnemies}...");

                if (_playerIsDead)
                {
                    waveDisplay.UpdateText("");
                    return false;
                }

                await Task.Delay(500, token);
            }

            waveDisplay.UpdateText("");
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