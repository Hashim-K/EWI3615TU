using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public float topLimit = 2.5f;
    public float bottomLimit = 1.0f;
    public float speed = 2.0f;
    private int direction = 1;
 
    void Update () {
        if (transform.position.y > topLimit) {
         direction = -1;
        }

        else if (transform.position.y < bottomLimit) {
         direction = 1;
        }

        
        
        transform.Translate(Vector3.up * direction * speed * Time.deltaTime); 
     }
    
}
