using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{
    //public TextMeshProUGUI display_player_name;

    public static string playernamestr;

    public Text playername;

    void Start()
    {
        playername.text = playernamestr;
        if (string.IsNullOrEmpty(playernamestr))
            SceneManager.LoadScene("Authenticate");

        //Debug.Log("playernamestr is null or empty");

        else
            Debug.Log("playernamestr is not empty");
    }

    public void ExitButton()
    {
        Application.Quit();
        Debug.Log("Game Closed");
    }

    public void StartGame()
    {
        SceneManager.LoadScene("GameMenu");
    }

    public void LoginPage()
    {
        SceneManager.LoadScene("Authenticate");
    }
}
