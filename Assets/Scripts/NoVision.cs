using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoVision : MonoBehaviour
{
    // Defining variables
    public GameObject Darkness;
    public float MinTime = 0f;
    public float MaxTime = 3.0f;

    void Start()
    {
        // Start with the coroutine
        StartCoroutine(Visibility(Darkness));
    }

    IEnumerator Visibility(GameObject noVision)
    {
        // If there is no gameobject, do nothing
        if (noVision == null) yield break;

        // If there is, set it active (or off) for a random period of time
        while (true)
        {
            noVision.SetActive(!noVision.active);
            yield return new WaitForSeconds(Random.Range(MinTime, MaxTime));
        }

    }
}
