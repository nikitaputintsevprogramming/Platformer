using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    private int sceneIndex;

    private void Start()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void SceneAgain()
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void ContinueGame()
    {
        Time.timeScale = 1;
    }
}
