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
        playername.text = playernamestr;
        playername2.text = playernamestr2;
    }

    public void ExitToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void StartGame()
    {
        
        
        SceneManager.LoadScene(stagestr);
    }

    //public void HandleInputDataCreature(int valC)
    //{
    //    if (valC == 0){
    //        //outputCreature.text = "Creature1!";
    //        creaturestr = "creature1";
    //    }
    //    if (valC == 1)
    //    {
    //        //outputCreature.text = "Creature2!";
    //        creaturestr = "creature2";
    //    }
    //    if (valC == 2)
    //    {
    //        //outputCreature.text = "Creature3!";
    //        creaturestr = "creature3";
    //    }
    //}

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
    }

    //public void HandleInputDataOpponent(int valO)
    //{
    //    if (valO == 0)
    //    {
    //        //outputOpponent.text = "wasd!";
    //        opponentstr = "wasd";
    //    }
    //    if (valO == 1)
    //    {
    //        //outputOpponent.text = "controller!";
    //        opponentstr = "controller";
    //    }
    //    if (valO == 2)
    //    {
    //        //outputOpponent.text = "oppo3!";
    //        opponentstr = "oppo3";
    //    }
    //}

}
