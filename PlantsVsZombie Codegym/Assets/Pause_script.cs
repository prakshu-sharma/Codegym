using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause_script : MonoBehaviour
{
    public static bool isGamePaused = false;
    public GameObject PauseMenuUI;
    // Update is called once per frame
   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isGamePaused)
            {
                resume();
            }
            else
            {
                pause();
            }
            
        }
    }
    public void resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;
        
    }
    void pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        Debug.Log(Time.timeScale);
        isGamePaused = true;
    }
    public void settings()
    {

    }
    public void quit()
    {
        Application.Quit();
    }
}
