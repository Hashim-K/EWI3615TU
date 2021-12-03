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
    public InputField playername2;
    public static string playernamestr;
    public static string playernamestr2;

    public Text playernametxt;
    public Text playername2txt;

    void Start()
    {
        if (string.IsNullOrEmpty(playernamestr))
            playernametxt.text = "Enter username";
        else
            playernametxt.text = playernamestr;

        if (string.IsNullOrEmpty(playernamestr2))
            playername2txt.text = "Enter username";
        else
            playername2txt.text = playernamestr2;
    }

    public void ExitToMenu()
    {
        MainMenu.playernamestr = playername.text;
        MainMenu.playernamestr2 = playername2.text;
        GameMenu.playernamestr = playername.text;
        GameMenu.playernamestr2 = playername2.text;
        RoundMenu.playernamestr = playername.text;
        RoundMenu.playernamestr2 = playername2.text;
        SceneManager.LoadScene("MainMenu");
        Debug.Log("player name is:" + playername.text);
        Debug.Log("player2 name is:" + playername2.text);
    }

    //public void SetPlayerName()
    //{
        //player_name = UsernameInput.text;
        //Debug.Log(player_name);
        
        //input = s;
        //Debug.Log(input);

    //}
}
