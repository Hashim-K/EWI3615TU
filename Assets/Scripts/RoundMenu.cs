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
        SceneManager.LoadScene("GameMenu");

    }

    // Function to handle the input data of the dropdown of stages. 

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
