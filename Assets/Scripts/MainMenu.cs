using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void ExitButton()
    {
        Application.Quit();
        Debug.Log("Game Closed");
    }

    public void StartGame()
    {
        SceneManager.LoadScene (sceneName:"Prototype_v1.0");
    }

    public void LoginPage()
    {
        SceneManager.LoadScene("Authenticate");
    }
}
