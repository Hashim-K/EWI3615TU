using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class death_zone : MonoBehaviour
{

    public GameObject Death;
    public float delayTime = 2f;

    void Start()
    {
        Death.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Player1"))
        {
            RoundMenu.p1wonlastgamebool = false;
            RoundMenu.playerscoreint2 = RoundMenu.playerscoreint2 + 1;
            //RoundMenu.playerscoreint = RoundMenu.playerscoreint;
            Debug.Log("Player1 died");
        }
        else if (other.gameObject.CompareTag("Player2"))
        {
            RoundMenu.p1wonlastgamebool = true;
            RoundMenu.playerscoreint = RoundMenu.playerscoreint + 1;
            //RoundMenu.playerscoreint2 = RoundMenu.playerscoreint2;
            Debug.Log("Player2 died");
        }
        Destroy(other.gameObject);
        Death.SetActive(true);
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
