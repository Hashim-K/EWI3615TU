using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMode : MonoBehaviour
{
    // Start is called before the first frame update
    public void setMaxPlayer(int value)
    {
        PlayerConfigurationManager.mPlayer = value;
        SceneManager.LoadScene("CharacterSelect");
    }
}
