using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Breaking_Tag : MonoBehaviour
{

    public float delayTime = 2.0f;
    private bool enabled = true;
    public CameraMovement cameraMovement;
    //public NavMeshAgent enemy;

    IEnumerator OnTriggerEnter(Collider coll) {
    if(enabled == true){  

        enabled = false;
        Debug.Log("OnBreakingPlatform");
    
        yield return new WaitForSeconds(delayTime);

        //GetComponent<NavMeshAgent>().enabled = false;
        //Debug.Log("navmeshagent is disabled breaking");
        
        foreach (Transform child in gameObject.transform)
        {
            child.gameObject.SetActive(false);
        }
        // Start with the cameramovement program for the breaking platforms
        StartCoroutine(cameraMovement.Movement(.2f, .3f));
        
        yield return new WaitForSeconds(delayTime);
        enabled = true;
        
        //GetComponent<NavMeshAgent>().enabled = true;
        //Debug.Log("navmeshagent is enabled breaking");
        foreach (Transform child in gameObject.transform)
        {
            child.gameObject.SetActive(true);
        }
     }
    }


     
}
