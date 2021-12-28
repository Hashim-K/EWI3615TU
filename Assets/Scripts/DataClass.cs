using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.InputSystem;



[Serializable]
public class DataClass : MonoBehaviour
{
    public Death_Zone death;

    public Stats da = new Stats();

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

    public void sendData(string Data, int playerID)
    {
        if(playerID == 1)
        {
            if (Data == "Jump")
            {
                da.p1jumps += 1;
            }

            if (Data == "Attack")
            {
                da.p1attacks += 1;
            }

            if (Data == "Hit")
            {
                da.p1hits += 1;
            }
        }
        else if(playerID == 2)
        {

            if (Data == "Jump")
            {
                da.p2jumps += 1;
            }

            if (Data == "Attack")
            {
                da.p2attacks += 1;
            }

            if (Data == "Hit")
            {
                da.p2hits += 1;
            }
        }
        else if(playerID == -1)
        {

            if (Data == "Jump")
            {
                da.aijumps += 1;
            }

            if (Data == "Attack")
            {
                da.aiattacks += 1;
            }

            if (Data == "Hit")
            {
                da.aihits += 1;
            }
        }
    }
   
}
