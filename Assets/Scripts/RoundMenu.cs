using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class RoundMenu : MonoBehaviour
{
    // define some variables
    public Text playername1;
    public Text playername2;
    public static string playernamestr;
    public static string playernamestr2;

    public static string stagestr;
    public static bool p1wonlastgamebool;

    public Text earnedpowerup;
    public Text earnedpowerup2;
    public static string wonpowerup;

    public Text playerscore;
    public Text playerscore2;
    public static int playerscoreint = 0;
    public static int playerscoreint2 = 0;
    
    void Start()
    {

        // Pick a random powerup for the losing player
        Pupicker();

        playername1.text = playernamestr + " earned:";
        playername2.text = playernamestr2 + " earned:";
        
        if (p1wonlastgamebool == true) // so player 1 won the round
        {
            earnedpowerup.text = "1 point!";
            earnedpowerup2.text = wonpowerup;
            playerscore.text = playerscoreint.ToString();
            playerscore2.text = playerscoreint2.ToString();
            
        }
        else if (p1wonlastgamebool == false) // so player 2 won the round
        {
            earnedpowerup2.text = "1 point!";
            earnedpowerup.text = wonpowerup;
            playerscore2.text = playerscoreint2.ToString();
            playerscore.text = playerscoreint.ToString();
        }
        
        // End of a game if someone gets more than 5 points
        if (playerscoreint == 5)
        {
            //to add: a display of who has won with how many points
            SceneManager.LoadScene("GameMenu");
        }
        else if (playerscoreint2 == 5)
        {
            //to add: a display of who has won with how many points
            SceneManager.LoadScene("GameMenu");
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
        // To do: set powerup name in stagestr!
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
            stagestr = "Stage_02";
        }
    }
}
