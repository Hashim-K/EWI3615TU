using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roundtimer : MonoBehaviour
{
    private bool timing;

    public Death_Zone death;

    public Stats da;
    
    // Start is called before the first frame update
    void Start()
    {
        timing = true;
    }
    
    void LateUpdate()
    {
        if(death.round_end && timing)
        {
            da = SaveManager.Load();
            timing = false;
            da.numberRounds += 1;
            da.roundTime = Time.timeSinceLevelLoad;
            if(da.roundTime > da.longestRound)
                {
                    da.longestRound = da.roundTime;
                }
            if(da.roundTime < da.shortestRound && da.shortestRound != 0)
                {
                    da.shortestRound = da.roundTime;
                }
            else if(da.shortestRound == 0)
            {
                da.shortestRound = da.roundTime;
            }

            SaveManager.Save(da);
            death.round_end = false;
        }
    }
}
