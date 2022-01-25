using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Death_Zone : MonoBehaviour
{
    public Text deathmsg;
    // public DataClass dataClass;
    public GameObject Death;
    public float delayTime = 2f;
    public static string player1;
    public static string player2;
    public bool round_end;
    public CameraMovement cameraMovement;

    void Start()
    {
        Death.SetActive(false);
        deathmsg.text = "";
        round_end = false;
    }

    void Update()
    {
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("death:", other);
        Death.SetActive(true);
        StartCoroutine(cameraMovement.Movement(1.0f, 0.3f));
        if (other.gameObject.CompareTag("Player1") && !round_end)
        {
            RoundMenu.p1wonlastgamebool = false;
            RoundMenu.playerscoreint2 = RoundMenu.playerscoreint2 + 1;
            //RoundMenu.playerscoreint = RoundMenu.playerscoreint;
            Debug.Log("Player1 died");
            deathmsg.text = player1 + " died\n" + player2 + " won!";
            //Death.GetComponent<UnityEngine.UI.Text>().text = "Player1 died, \n player2 won";
        }
        else if (other.gameObject.CompareTag("Player2") && !round_end)
        {
            RoundMenu.p1wonlastgamebool = true;
            RoundMenu.playerscoreint = RoundMenu.playerscoreint + 1;
            //RoundMenu.playerscoreint2 = RoundMenu.playerscoreint2;
            Debug.Log("Player2 died");
            deathmsg.text = player2 + " died\n" + player1 + " won!";
            //Death.GetComponent<UnityEngine.UI.Text>().text = "Player2 died, \n player1 won";
        }
        other.gameObject.SetActive(false);
        //Destroy(other.gameObject);

        reset();
    }
        
     public void reset()
    {
        FindObjectOfType<LevelInitializer>().destroyPlayers();
        //Get methods from GameAnalytics object (And use them)
        //GameAnalytics = GameObject.FindGameObjectWithTag("Analytics").GetComponent<GameAnalytics>();

        //This could be a function which does more than only updating this variable
        //GameAnalytics.AddRound();
        //Debug.Log(temp.AddRound())

        // dataClass.numberRounds += 1;
        round_end = true;
        StartCoroutine(waitCouple());
        
     

        // Debug.Log(dataClass.numberRounds);

    }

    IEnumerator waitCouple()
    {
        yield return new WaitForSeconds(delayTime);

        //RoundMenu.playerscoreint = RoundMenu.playerscoreint + 1;
        SceneManager.LoadScene("RoundMenu");
    }
    
}
