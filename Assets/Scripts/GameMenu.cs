using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameMenu : MonoBehaviour
{
    public static string playernamestr;

    public Text outputCreature;
    public Text outputStage;
    public Text outputOpponent;

    public static string stagestr;
    public static string opponentstr;
    public static string creaturestr;

    public Text playername;

    void Start()
    {
        playername.text = playernamestr;
    }

    public void ExitToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void StartGame()
    {
        
        
        SceneManager.LoadScene(stagestr);
    }

    public void HandleInputDataCreature(int valC)
    {
        if (valC == 0){
            outputCreature.text = "Creature1!";
            creaturestr = "creature1";
        }
        if (valC == 1)
        {
            outputCreature.text = "Creature2!";
            creaturestr = "creature2";
        }
        if (valC == 2)
        {
            outputCreature.text = "Creature3!";
            creaturestr = "creature3";
        }
    }

    public void HandleInputDataStage(int valS)
    {
        if (valS == 0)
        {
            outputStage.text = "Stage1!";
            stagestr = "MainMenu";
        }
        if (valS == 1)
        {
            outputStage.text = "prototype stage!";
            stagestr = "Prototype_v1.0";
        }
        if (valS == 2)
        {
            outputStage.text = "Stage3!";
            stagestr = "MainMenu";
        }
    }

    public void HandleInputDataOpponent(int valO)
    {
        if (valO == 0)
        {
            outputOpponent.text = "oppo1!";
            opponentstr = "oppo1";
        }
        if (valO == 1)
        {
            outputOpponent.text = "oppo2!";
            opponentstr = "oppo2";
        }
        if (valO == 2)
        {
            outputOpponent.text = "oppo3!";
            opponentstr = "oppo3";
        }
    }

}
