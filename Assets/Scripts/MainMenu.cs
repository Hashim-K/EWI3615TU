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
    }

    public void ExitButton()
    {
        Application.Quit();
        Debug.Log("Game Closed");
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Prototype_v1.0");
    }

    public void LoginPage()
    {
        SceneManager.LoadScene("Authenticate");
    }
}
