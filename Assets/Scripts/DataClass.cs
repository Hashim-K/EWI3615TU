using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.InputSystem;



[Serializable]
public class DataClass : MonoBehaviour
{
    public PlayerController p1Inputs;
    public Death_Zone death;
    public Combat p1Combat;

    private bool jumping;

    public Stats da = new Stats();

    void Start()
    {
        jumping = false;
        da = SaveManager.Load();
        da.numberRounds += 1;
    }

    void Update()
    {
       if(p1Inputs.jump)
       {
           jumping = true;
       }
    }

    void FixedUpdate()
    {
        if(jumping)
        {
            da.p1jumps += 1;
            jumping = false;
        }
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
   
    public void passData(string data)
    {
        if(data == "ATTACKING") // kicking or punching
        {
            da.p1attacks += 1;
        }

        if(data == "HIT") // taking damage
        {
            da.p1hits += 1;
        }
    }
}