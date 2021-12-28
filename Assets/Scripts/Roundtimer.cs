using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roundtimer : MonoBehaviour
{
    public Death_Zone death;

    public Stats da = new Stats();
    
    // Start is called before the first frame update
    void Start()
    {
        da = SaveManager.Load();
        da.numberRounds += 1;
    }
    
    void LateUpdate()
    {
        if(death.round_end)
        {
            da.roundTime = Time.timeSinceLevelLoad;
            SaveManager.Save(da);
            death.round_end = false;
        }
    }
}
