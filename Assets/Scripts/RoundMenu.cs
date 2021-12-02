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
    public static int playerscoreint;
    public static string wonpowerup;

    void Start()
    {

        // Pick a random powerup
        Pupicker();

        // This boolean is set in the game round before.  
        wonlastgamebool = false;
        
        playerscoreint = 0;
        if (wonlastgamebool == true)
        {
            earnedpowerup.text = "you won... no powerup";
            playerscore.text = (playerscoreint + 1).ToString();
        }
        if (wonlastgamebool == false)
        {
            earnedpowerup.text = wonpowerup;
            playerscore.text = playerscoreint.ToString();
        }
    }

    // Picks a random item from the list and sets wonpowerup to the chosen item
    static void Pupicker()
    {
        var random = new System.Random();
        var list = new List<string> {"JumpBoost", "FastSpeed"}; //{ "BigMass", "Invisibility", "GhostFlyer", "FastSpeed", "JumpBoost", "ExtraLife", "BigSize", "StrongGravity", "JetPack" };
        int index = random.Next(list.Count);
        wonpowerup = list[index];
        PlayerController.powerup = wonpowerup;
    }

    // Function for the exit button
    public void ExitToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    // Function for the startgame button
    public void StartGame()
    {
        SceneManager.LoadScene(stagestr);
    }

    // Function to handle the input data of the dropdown of stages. 
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
