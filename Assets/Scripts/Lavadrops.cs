using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lavadrops : MonoBehaviour
{
    public float topLimit = 12f;
    public float bottomLimit = -10f;
    public float speed = 6.0f;
    private int direction = 1;
    private bool dropbool = true;

    void Start()
    {
        
    }


    void Update()
    {
        if (transform.position.y > topLimit)
        {
            direction = -1;
        }

        else if (transform.position.y < bottomLimit && dropbool)
        {
            Vector3 newPos = new Vector3(0f, 12f, -4.5f); 
            transform.position = newPos;
            dropbool = false;
            //transform.Translate(Vector3.up * 1 * speed * 10000 * Time.deltaTime);
        }
        else if (transform.position.y < bottomLimit && dropbool == false)
        {
            Vector3 newPos = new Vector3(0f, 12f, 4.5f);
            transform.position = newPos;
            dropbool = true;
            //transform.Translate(Vector3.up * 1 * speed * 10000 * Time.deltaTime);
        }



        transform.Translate(Vector3.up * direction * speed * Time.deltaTime);
    }

}
