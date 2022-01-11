using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Underwater : MonoBehaviour
{
    public GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        PlayerController.maxSpeed = 2.0f;
        enemy.GetComponent<NavMeshAgent>().speed = 2.0f;
    }

    void Update()
    {
        PlayerController.maxSpeed = 2.0f;
        enemy.GetComponent<NavMeshAgent>().speed = 2.0f;
    }
    
}
