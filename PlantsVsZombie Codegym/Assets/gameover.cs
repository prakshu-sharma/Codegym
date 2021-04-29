using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameover : MonoBehaviour
{
    // Update is called once per frame
    public GameObject gameOverPanel;
    public static gameover instance;
    public GameObject old;
    private void Awake()
    {
        instance = this;
    }
    public void GameOver()
    {
        Debug.Log("GameOVErCAlLed");
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
        old.SetActive(false);
        

    }
    public void restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Gameplay window");
    }
    public void quit()
    {
        // save any game data here
#if UNITY_EDITOR
        // Application.Quit() does not work in the editor so
        // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
    }
}
