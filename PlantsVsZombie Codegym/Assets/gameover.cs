using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameover : MonoBehaviour
{
    // Update is called once per frame
    public GameObject gameOverPanel;
    public void GameOver() 
    {
        gameOverPanel.SetActive(true);

    }
    public void restart()
    {
        SceneManager.LoadScene("Gameplay window");
    }
}
