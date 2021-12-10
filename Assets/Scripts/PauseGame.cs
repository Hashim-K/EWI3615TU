using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public bool paused = false;

    public void Pause()
    {
        Debug.Log("pause clicked");
        // If paused, we will play it
        if (paused)
        {
            paused = false;
            Time.timeScale = 1;
            Debug.Log("timescale = 1");
            
        }
        // If not paused, we will pause it
        else if (!paused)
        {
            paused = true;
            Time.timeScale = 0f;
            Debug.Log("timescale = 0");
        }
    }
}
