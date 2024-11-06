using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject completedText;
    [SerializeField] private GameObject failedText;
    [SerializeField] private GameObject healthBar;
    [SerializeField] private GameObject scoreText;
    private bool allEnemiesSpawned = false;
    private bool levelEnded = false;
    private Health playerHealth;


    void Start()
    {
        playerHealth = GameObject.FindWithTag("Player").GetComponent<Health>();
        PlayerPrefs.SetInt("currentScore", 0);
    }
    protected void Update()
    {
        if (levelEnded) return;

        if (allEnemiesSpawned && GameObject.FindWithTag("Enemy") == null)
        {
            levelEnded = true;
            StartCoroutine(OnLevelCompleted());
        }

        if (playerHealth.IsObjectDead())
        {
            levelEnded = true;
            StartCoroutine(OnLevelFailed());
        }

        if (scoreText) scoreText.GetComponent<TMP_Text>().text = "Score: " + PlayerPrefs.GetInt("currentScore", 0);
    }
    public void StartLevel()
    {
        GameObject mainCamera = Camera.main.gameObject;
        CameraController cameraController = mainCamera.GetComponent<CameraController>();
        cameraController.SetPlayerHasCameraControl(true);

        GameObject player = GameObject.FindWithTag("Player");
        PlayerShooting playerShooting = player.GetComponent<PlayerShooting>();
        playerShooting.SetAllowShooting(true);
        PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();
        playerMovement.SetAllowMovement(true);

        healthBar.SetActive(true);
    }

    protected void SpawnEnemy(GameObject enemy)
    {
        Vector2 location = RandomizeSpawnPoint();
        Instantiate(enemy, location, Quaternion.identity);
    }

    private Vector2 RandomizeSpawnPoint()
    {
        float fixedValue = Random.value > 0.5f ? 70 : -70;
        float randomValue = Random.Range(-70, 70);
        return Random.value > 0.5f ? new Vector2(fixedValue, randomValue) : new Vector2(randomValue, fixedValue);
    }

    protected void SetAllEnemiesSpawned()
    {
        allEnemiesSpawned = true;
    }

    IEnumerator OnLevelCompleted()
    {
        PlayerPrefs.SetInt("unlockedLevel", SceneManager.GetActiveScene().buildIndex + 1);
        completedText.SetActive(true);
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("MainMenu");
    }

    IEnumerator OnLevelFailed()
    {
        if (scoreText)
        {
            int currentScore = PlayerPrefs.GetInt("currentScore", 0);
            int highscore = PlayerPrefs.GetInt("highScore", 0);
            failedText.GetComponent<TMP_Text>().text = currentScore > highscore ? "You died!\nNew Highscore!" : "You died!";
            PlayerPrefs.SetInt("highScore", currentScore);
        }
        failedText.SetActive(true);
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("MainMenu");
    }
}
