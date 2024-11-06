using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InfiniteModeManager : LevelManager
{
    [SerializeField] GameObject yellowEnemyPrefab;
    [SerializeField] GameObject greenEnemyPrefab;
    [SerializeField] GameObject blueEnemyPrefab;
    [SerializeField] float yellowEnemySpawnInterval;
    [SerializeField] float greenEnemySpawnInterval;
    [SerializeField] float blueEnemySpawnInterval;

    new void Update()
    {
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
        while (true)
        {

            yield return new WaitForSeconds(yellowEnemySpawnInterval);
            SpawnEnemy(yellowEnemyPrefab);
        }
    }

    IEnumerator SpawnGreenEnemies()
    {
        while (true)
        {

            yield return new WaitForSeconds(greenEnemySpawnInterval);
            SpawnEnemy(greenEnemyPrefab);
        }
    }

    IEnumerator SpawnBlueEnemies()
    {
        while (true)
        {

            yield return new WaitForSeconds(blueEnemySpawnInterval);
            SpawnEnemy(blueEnemyPrefab);
        }
    }
}
