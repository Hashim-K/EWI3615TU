using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public IEnumerator Movement(float length, float magnitude)
    {
        //Camera cam = gameObject.GetComponent<Camera>();
        Vector3 startposition = transform.localPosition;
        float runtime = 0.0f;
        while (runtime < length)
        {
            // Pick random x and y
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;
            float z = Random.Range(-1f, 1f) * magnitude;

            // Set new location of camera to random x and y
            transform.localPosition = new Vector3(x, y, z);
            runtime += Time.deltaTime;
            yield return null;
        }
        // Place camera back to original position
        transform.localPosition = startposition;
    }
}
