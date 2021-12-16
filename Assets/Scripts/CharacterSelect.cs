using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterSelect : MonoBehaviour
{
    public InputField playername1;
    public InputField playername2;
    public static string playernamestr1;
    public static string playernamestr2;
    public int numberbuttonspressed = 0;

    // Start is called before the first frame update
    void Start()
    {
        numberbuttonspressed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReadyPressed()
    {
        numberbuttonspressed = numberbuttonspressed + 1;
        if (numberbuttonspressed == 2)
        {
            ToGameMenu();
        }

    }

    void ToGameMenu()
    {
        // Setting the values of the playername in different scenes
        GameMenu.playernamestr = playername1.text;
        GameMenu.playernamestr2 = playername2.text;
        RoundMenu.playernamestr = playername1.text;
        RoundMenu.playernamestr2 = playername2.text;
        Death_Zone.player1 = playername1.text;
        Death_Zone.player2 = playername2.text;
        SceneManager.LoadScene("GameMenu");
        Debug.Log("player1 is:" + playername1.text);
        Debug.Log("player2 is:" + playername2.text);
    }
}
