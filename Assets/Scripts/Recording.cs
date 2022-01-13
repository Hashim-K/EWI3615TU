using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GetSocialSdk.Capture.Scripts;


public class Recording : MonoBehaviour
{

    private bool capturing;

    public GetSocialCapture capture;
    public Death_Zone death;
    

    // Start is called before the first frame update
    void Start()
    {
        capture.StartCapture();
        capturing = true;
    }

    void Update()
    {
        capture.CaptureFrame();
    }

    void LateUpdate()
    {
        if(death.round_end && capturing)
        {
            capturing = false;
            capture.StopCapture();
            capture.GenerateCapture(result =>
            {
                // use gif, like send it to your friends by using GetSocial Sdk
            });
        }
    }

}

