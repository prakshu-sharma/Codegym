using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameover : MonoBehaviour
{
    // Update is called once per frame
    public GameObject gameOverPanel;
    public static gameover instance;
    private void Awake()
    {
        instance = this;
    }
    public void GameOver()
    {
        Debug.Log("GameOVErCAlLed");
        gameOverPanel.SetActive(true);

    }
    public void restart()
    {
        SceneManager.LoadScene("Gameplay window");
    }
}
