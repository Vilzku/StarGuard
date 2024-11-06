using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Level2Manager : LevelManager
{
    [SerializeField] GameObject yellowEnemyPrefab;
    [SerializeField] GameObject greenEnemyPrefab;
    [SerializeField] int yellowEnemiesToSpawn;
    [SerializeField] float yellowEnemySpawnInterval;
    private bool allYellowEnemiesSpawned = false;
    [SerializeField] int greenEnemiesToSpawn;
    [SerializeField] float greenEnemySpawnInterval;
    private bool allGreenEnemiesSpawned = false;

    new void Update()
    {
        if (allYellowEnemiesSpawned && allGreenEnemiesSpawned) SetAllEnemiesSpawned();
        base.Update();
    }

    new public void StartLevel()
    {
        base.StartLevel();
        StartCoroutine(SpawnYellowEnemies());
        StartCoroutine(SpawnGreenEnemies());
    }

    IEnumerator SpawnYellowEnemies()
    {
        for (int i = 0; i < yellowEnemiesToSpawn; i++)
        {

            yield return new WaitForSeconds(yellowEnemySpawnInterval);
            SpawnEnemy(yellowEnemyPrefab);
        }
        allYellowEnemiesSpawned = true;
    }
    IEnumerator SpawnGreenEnemies()
    {
        for (int i = 0; i < greenEnemiesToSpawn; i++)
        {

            yield return new WaitForSeconds(greenEnemySpawnInterval);
            SpawnEnemy(greenEnemyPrefab);
        }
        allGreenEnemiesSpawned = true;
    }
}
