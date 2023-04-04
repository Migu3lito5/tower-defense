using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool GameIsOver = false;

    public GameObject gameOverUI;

    public string nextLevel = "Level2";
    public int levelToUnlock = 2;

    private void Start()
    {
        GameIsOver = false;
    }

    private void Update()
    {
        if(GameIsOver)
        {
            return;
        }

        if (PlayerStats.Lives <= 0)
        {
            EndGame();
        }


    }

    void EndGame()
    {
        GameIsOver = true;
        gameOverUI.SetActive(true);
    }

    public void WinLevel()
    {
        PlayerPrefs.SetInt("levelReached", levelToUnlock);
        SceneManager.LoadScene(nextLevel);
         Debug.Log("LevelWon");
    }
}
