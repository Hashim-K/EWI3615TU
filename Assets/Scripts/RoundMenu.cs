using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoundMenu : MonoBehaviour
{
    public static string playernamestr;
    public static string stagestr;

    public void ExitToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void StartGame()
    {
        SceneManager.LoadScene(stagestr);
    }

    public void HandleInputDataStage(int valS)
    {
        if (valS == 0)
        {
            //outputStage.text = "Stage1!";
            stagestr = "MainMenu";
        }
        if (valS == 1)
        {
            //outputStage.text = "prototype stage!";
            stagestr = "Prototype_v1.0";
        }
        if (valS == 2)
        {
            //outputStage.text = "Stage3!";
            stagestr = "MainMenu";
        }
    }
}
