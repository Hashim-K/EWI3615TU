using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Authenticate : MonoBehaviour
{
    public void ExitToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
