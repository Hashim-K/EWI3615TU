using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JSONReader : MonoBehaviour
{
    public class DataClass da;
    public Death_Zone death;
    public bool see_analytics;

    // Start is called before the first frame update
    void Start()
    {
        see_analytics = false;

    }

    // Update is called once per frame
    void LateUpdate()
    {
        SaveManager.Save(da);

        if (see_analytics) //This can be triggered by a button or a key! 
        {
            SaveManager.Load(da)
        }
    }

    public static GameAnalytics Load()
    { 

    }
}
