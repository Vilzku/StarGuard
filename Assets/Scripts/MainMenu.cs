using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button[] levelButtons;
    [SerializeField] private GameObject highScoreText;

    private void Awake()
    {
        int unlockedLevel = PlayerPrefs.GetInt("unlockedLevel", 1);
        for (int i = 0; i < levelButtons.Length; i++)
        {
            levelButtons[i].interactable = unlockedLevel > i;
        }
        highScoreText.GetComponent<TMP_Text>().text = "Highscore: " + PlayerPrefs.GetInt("highScore", 0);

    }
    public void OpenLevel(int id)
    {
        SceneManager.LoadScene(id);
    }

    public void CloseGame()
    {
        Application.Quit();
    }
}
