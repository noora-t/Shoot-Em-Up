using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject _gameOverPanel;
    public GameObject _victoryPanel;

    bool _gameIsPaused;

    public bool GameIsPaused => _gameIsPaused;

    void Start()
    {
        _gameIsPaused = false;
    }

    public void DisplayGameOver()
    {
        _gameIsPaused = true;
        _gameOverPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void DisplayWin()
    {
        _gameIsPaused = true;
        _victoryPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
