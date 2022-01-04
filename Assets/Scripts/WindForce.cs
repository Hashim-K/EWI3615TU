using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindForce : MonoBehaviour
{
    //public Rigidbody players;
    public GameObject player1;
    public GameObject player2;
    private int direction;
    public Text windDirection;

    void Start()
    {
        // finding the players with their tag's
        player1 = GameObject.FindWithTag("Player1");
        player2 = GameObject.FindWithTag("Player2");

        // choosing a random wind direction
        direction = Random.Range(0, 2) * 2 - 1;
        Debug.Log(direction);
        if (direction == 1)
        {
            windDirection.text = "-->";
        }
        if (direction == -1)
        {
            windDirection.text = "<--";
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Making a vector3 for the wind
        Vector3 windDir = new Vector3(0, 0.04f, direction * 0.04f);

        // Adding windforce to the rigidbodies of the players
        player1.GetComponent<Rigidbody>().AddForce(windDir, ForceMode.Impulse);
        player2.GetComponent<Rigidbody>().AddForce(windDir, ForceMode.Impulse);
    }
}
