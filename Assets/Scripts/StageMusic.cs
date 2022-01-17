using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageMusic : MonoBehaviour
{
    public GameObject AudioObject;

    void Start()
    {
        AudioObject = GameObject.Find("MenuMusic");
    }
    void Awake()
    {

    }
    void Update()
    {
        if (AudioObject != null)
            Destroy(AudioObject);

    }
}
