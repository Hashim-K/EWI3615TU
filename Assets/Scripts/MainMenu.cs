using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public static string playernamestr;
    public static string playernamestr2;
    public Text playername;
    public Text playername2;

    // Function when scene is opened
    void Start()
    {
        //if (string.IsNullOrEmpty(playernamestr))
            //SceneManager.LoadScene("Authenticate");
        //if (string.IsNullOrEmpty(playernamestr2))
            //SceneManager.LoadScene("Authenticate");
        //Debug.Log("playernamestr is null or empty");

        //else
            //Debug.Log("playernamestr is not empty");
            //playername.text = playernamestr;
            //playername2.text = playernamestr2;
    }

    // Function for Quit Game button
    public void ExitButton()
    {
        Application.Quit();
        Debug.Log("Game Closed");
    }

    // Function for Start game button : go to Game Menu
    public void StartGame()
    {
        SceneManager.LoadScene("PlayerSelect");
    }

    // Function for the Login button: go to Authenticate screen to enter user name
    public void LoginPage()
    {
        Authenticate.playernamestr = playernamestr;
        Authenticate.playernamestr2 = playernamestr2;
        SceneManager.LoadScene("Authenticate");
    }

    public void LoadAnalytics()
    {
        SceneManager.LoadScene("Analytics");
    }
}
