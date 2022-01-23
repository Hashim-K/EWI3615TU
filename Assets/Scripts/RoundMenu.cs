using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using GetSocialSdk.Capture.Scripts;



public class RoundMenu : MonoBehaviour
{
    // define some variables
    public Text winningplayer;
    public Text winningpoints;
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
    
    public Stats da = new Stats();




    public GameObject WinMsg;

    void Awake()
    {
        da = SaveManager.Load();
    }
    
    void Start()
    {
        WinMsg.SetActive(false);
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
            PlayerController.playerwonputag = "Player2";
            
        }
        else if (p1wonlastgamebool == false) // so player 2 won the round
        {
            earnedpowerup2.text = "1 point!";
            earnedpowerup.text = wonpowerup;
            playerscore2.text = playerscoreint2.ToString();
            playerscore.text = playerscoreint.ToString();
            PlayerController.playerwonputag = "Player1";
        }
        
        // End of a game if someone gets more than 5 points
        if (playerscoreint == 5)
        {
            winningpoints.text = "Your score: " + playerscoreint.ToString();
            winningplayer.text = playernamestr;
            WinMsg.SetActive(true);
            da.numberMatches += 1;
            da.p1wins += 1;
            SaveManager.Save(da);
            reset();
        }
        else if (playerscoreint2 == 5)
        {
            winningpoints.text = "Your score: " + playerscoreint2.ToString();
            winningplayer.text = playernamestr2;
            WinMsg.SetActive(true);
            da.numberMatches += 1;
            da.p2wins += 1;
            SaveManager.Save(da);
            reset();
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
        playerscoreint = 0;
        playerscoreint2 = 0;
        wonpowerup = "";
        SceneManager.LoadScene("GameMenu");
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
            stagestr = "Stage_1";
        }
        if (valS == 2)
        {
            //outputStage.text = "Stage3!";
            stagestr = "Stage_2";
        }
        if (valS == 3)
        {
            stagestr = "Stage_3";
        }
        if (valS == 4)
        {
            stagestr = "Stage_4";
        }
        if (valS == 5)
        {
            stagestr = "Stage_5";
        }
        if (valS == 6)
        {
            stagestr = "Stage_6";
        }
        if (valS == 7)
        {
            stagestr = "Stage_7";
        }
    }

    public void reset()
    {
        playerscoreint = 0;
        playerscoreint2 = 0;
        wonpowerup = "";
        StartCoroutine(waitCouple());
    }

    IEnumerator waitCouple()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("GameMenu");
    }
}
