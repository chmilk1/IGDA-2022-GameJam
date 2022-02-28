using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//reference:
//https://youtu.be/E7gmylDS1C4

public class DeployEnemy : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab0;
    [SerializeField] private GameObject enemyPrefab1;
    [SerializeField] private GameObject enemyPrefab2;
    [SerializeField] private GameObject enemyPrefab3;
    [SerializeField] private float respawnTime;
    private Vector2 screenBounds;
    [SerializeField] private float yScreenBoundOffset;
    [SerializeField] private bool spawnEnemies = false; //mainly used to start and stop spawning
    private bool spawningEnemy = false;


    private void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    private void Update()
    {
        if(spawnEnemies)
        {
            StartCoroutine(enemyWave());
        }
    }

    public void startHazards()
    {
        spawnEnemies = true;
    }

    public void stopHazards()
    {
        spawnEnemies = false;
    }

    private void spawnEnemy()
    {
        GameObject enemy;
        int randomEnemy = Random.Range(0, 20);

        if(randomEnemy == 1)
        {
            enemy = Instantiate(enemyPrefab3) as GameObject;
        }
        else if (randomEnemy <= 5)
        {
            enemy = Instantiate(enemyPrefab1) as GameObject;
        }
        else if (randomEnemy <= 10)
        {
            enemy = Instantiate(enemyPrefab2) as GameObject;
        }
        else
        {
            enemy = Instantiate(enemyPrefab0) as GameObject;
        }

        enemy.transform.position = new Vector2(Random.Range(-screenBounds.x, screenBounds.x), screenBounds.y + yScreenBoundOffset);
    }

    IEnumerator enemyWave()
    {
        while (!spawningEnemy && spawnEnemies)
        {
            spawningEnemy = true;
            yield return new WaitForSeconds(respawnTime);
            spawnEnemy();
            spawningEnemy = false;

        }
    }
}
