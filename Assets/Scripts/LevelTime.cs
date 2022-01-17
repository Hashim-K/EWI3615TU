//Attach this script to a GameObject


using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelTime : MonoBehaviour
{
    public static float stageTime;
    public static Text playTime;

    void Update()
    {
        //Output the time since the level loaded to the screen using this label
        stageTime = stageTime + Time.timeSinceLevelLoad;
        //Debug.Log(stageTime);
    }
}

