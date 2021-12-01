using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class RoundMenu : MonoBehaviour
{
    public static string playernamestr;
    public static string stagestr;
    public static bool wonlastgamebool;
    public Text earnedpowerup;
    public Text playerscore;
    public static string wonpowerup;

    void Start()
    {

        //wonpowerup = "you won powerup1";
        Pupicker();
        wonlastgamebool = true;
        if (wonlastgamebool == true)
        {
            earnedpowerup.text = wonpowerup;

        }
        if (wonlastgamebool == false)
        {
            earnedpowerup.text = "you lost...";
        }
    }

    static void Pupicker()
    {
        var random = new System.Random();
        var list = new List<string> { "BigMass", "Invisibility", "GhostFlyer", "FastSpeed", "JumpBoost" };
        int index = random.Next(list.Count);
        wonpowerup = list[index];
    }

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
