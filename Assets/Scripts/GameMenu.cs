using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameMenu : MonoBehaviour
{
    public static string playernamestr;
    public static string playernamestr2;

    public static string stagestr;
    public static string opponentstr;
    public static string creaturestr;

    public Text playername;
    public Text playername2; 

    void Start()
    {

    }

    public void ExitToMainMenu()
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
            //outputStage.text = "mainmenu stage";
            stagestr = "MainMenu";
        }
        if (valS == 1)
        {
            //outputStage.text = "Stage 1";
            stagestr = "Stage_1";
        }
        if (valS == 2)
        {
            //outputStage.text = "Stage 2";
            stagestr = "Stage_2";
        }
        if (valS == 3)
        {
            //outputStage.text = "Stage 2";
            stagestr = "Stage_3";
        }
    }



}
