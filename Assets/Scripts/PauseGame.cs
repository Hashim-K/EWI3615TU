using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseGame : MonoBehaviour
{
    public bool paused = false;
    public GameObject PauseMenu;

    void Start()
    {
        PauseMenu.SetActive(false);
    }

    public void Pause()
    {
        Debug.Log("pause clicked");
        // If paused, we will play it
        if (paused)
        {
            paused = false;
            Time.timeScale = 1;
            Debug.Log("timescale = 1");
            PauseMenu.SetActive(false);
            
        }
        // If not paused, we will pause it
        else if (!paused)
        {
            paused = true;
            Time.timeScale = 0f;
            Debug.Log("timescale = 0");
            PauseMenu.SetActive(true);
        }
    }

    public void QuitGame()
    {
        paused = false;
        Time.timeScale = 1;
        SceneManager.LoadScene("RoundMenu");
    }
}
