using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Authenticate : MonoBehaviour
{
    //private string input;
    public InputField playername;

    public static string playernamestr;

    public Text playernametxt;

    void Start()
    {
        if (string.IsNullOrEmpty(playernamestr))
            playernametxt.text = "Enter username";
        else
            playernametxt.text = playernamestr;
    }

    public void ExitToMenu()
    {
        MainMenu.playernamestr = playername.text;
        GameMenu.playernamestr = playername.text;
        RoundMenu.playernamestr = playername.text;
        SceneManager.LoadScene("MainMenu");
        Debug.Log("player name is:" + playername.text);
    }

    //public void SetPlayerName()
    //{
        //player_name = UsernameInput.text;
        //Debug.Log(player_name);
        
        //input = s;
        //Debug.Log(input);

    //}
}
