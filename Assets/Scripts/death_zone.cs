using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class death_zone : MonoBehaviour
{
    public Text deathmsg;
    public GameObject Death;
    public float delayTime = 2f;
    public static string player1;
    public static string player2;

    void Start()
    {
        Death.SetActive(false);
        deathmsg.text = "";
    }

    void OnTriggerEnter(Collider other)
    {
        Death.SetActive(true);
        if (other.gameObject.CompareTag("Player1"))
        {
            RoundMenu.p1wonlastgamebool = false;
            RoundMenu.playerscoreint2 = RoundMenu.playerscoreint2 + 1;
            //RoundMenu.playerscoreint = RoundMenu.playerscoreint;
            Debug.Log("Player1 died");
            deathmsg.text = player1 + " died\n" + player2 + "won!";
            //Death.GetComponent<UnityEngine.UI.Text>().text = "Player1 died, \n player2 won";
        }
        else if (other.gameObject.CompareTag("Player2"))
        {
            RoundMenu.p1wonlastgamebool = true;
            RoundMenu.playerscoreint = RoundMenu.playerscoreint + 1;
            //RoundMenu.playerscoreint2 = RoundMenu.playerscoreint2;
            Debug.Log("Player2 died");
            deathmsg.text = player2 + " died\n" + player1 + " won!";
            //Death.GetComponent<UnityEngine.UI.Text>().text = "Player2 died, \n player1 won";
        }
        Destroy(other.gameObject);
        
        reset();



        
    }
        
     public void reset()
    {
        StartCoroutine(waitCouple());
    }

    IEnumerator waitCouple()
    {
        yield return new WaitForSeconds(delayTime);

        //RoundMenu.playerscoreint = RoundMenu.playerscoreint + 1;
        
        SceneManager.LoadScene("RoundMenu");
    }
    
}
