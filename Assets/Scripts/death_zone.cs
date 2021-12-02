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

        RoundMenu.playerscoreint = RoundMenu.playerscoreint + 1;
        
        SceneManager.LoadScene("RoundMenu");
    }
    
}
