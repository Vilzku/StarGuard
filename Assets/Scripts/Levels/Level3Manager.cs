using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Level3Manager : LevelManager
{
    [SerializeField] GameObject yellowEnemyPrefab;
    [SerializeField] GameObject greenEnemyPrefab;
    [SerializeField] GameObject blueEnemyPrefab;
    [SerializeField] int yellowEnemiesToSpawn;
    [SerializeField] float yellowEnemySpawnInterval;
    private bool allYellowEnemiesSpawned = false;
    [SerializeField] int greenEnemiesToSpawn;
    [SerializeField] float greenEnemySpawnInterval;
    private bool allGreenEnemiesSpawned = false;
    [SerializeField] int blueEnemiesToSpawn;
    [SerializeField] float blueEnemySpawnInterval;
    private bool allBlueEnemiesSpawned = false;

    new void Update()
    {
        if (allYellowEnemiesSpawned && allGreenEnemiesSpawned && allBlueEnemiesSpawned) SetAllEnemiesSpawned();
        base.Update();
    }

    new public void StartLevel()
    {
        base.StartLevel();
        StartCoroutine(SpawnYellowEnemies());
        StartCoroutine(SpawnGreenEnemies());
        StartCoroutine(SpawnBlueEnemies());
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

    IEnumerator SpawnBlueEnemies()
    {
        for (int i = 0; i < blueEnemiesToSpawn; i++)
        {

            yield return new WaitForSeconds(blueEnemySpawnInterval);
            SpawnEnemy(blueEnemyPrefab);
        }
        allBlueEnemiesSpawned = true;
    }
}
