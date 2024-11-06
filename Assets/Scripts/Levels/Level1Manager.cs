using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Manager : LevelManager
{
    [SerializeField] GameObject yellowEnemyPrefab;
    [SerializeField] int enemiesToSpawn;
    [SerializeField] float enemySpawnInterval;

    new public void StartLevel()
    {
        base.StartLevel();
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {

            yield return new WaitForSeconds(enemySpawnInterval);
            SpawnEnemy(yellowEnemyPrefab);
        }
        SetAllEnemiesSpawned();
    }

}
