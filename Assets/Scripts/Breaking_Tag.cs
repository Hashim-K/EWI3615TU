using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breaking_Tag : MonoBehaviour
{

    public float delayTime = 2.0f;
    //private bool enabled = true;

    IEnumerator OnTriggerEnter(Collider coll) {
    if(enabled == true){  

        enabled = false;
        Debug.Log("yep");
    
        yield return new WaitForSeconds(delayTime);
        
        foreach(Transform child in gameObject.transform)
        {
            child.gameObject.SetActive(false);
        }
        
        
        yield return new WaitForSeconds(delayTime);
        enabled = true; 
        foreach(Transform child in gameObject.transform)
        {
            child.gameObject.SetActive(true);
        }
     }
    }


     
}
