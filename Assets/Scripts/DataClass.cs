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
    private bool attacking;
    private bool hit;
    private bool end;

    public Stats da = new Stats();

    void Start()
    {
        jumping = false;
        attacking = false;
        end = false;
        hit = false;
        da = SaveManager.Load();
        da.numberRounds += 1;
    }

    void Update()
   {
       if(p1Inputs.jump)
       {
           jumping = true;
       }

       if(p1Combat.isKicking || p1Combat.isPunching)
       {
           attacking = true;
       }

       if(p1Combat.isHit)
       {
           hit = true;
       }



      


   }
    void FixedUpdate()
    {
        if(jumping)
        {
            da.p1jumps += 1;
            jumping = false;
        }

        if(attacking)
        {
            da.p1attacks += 1;
            attacking = false;
        }

        if(hit)
        {
            da.p1hits += 1;
            hit = false;
        }

         
    }
    
    void LateUpdate()
    {
        if(death.round_end)
        {
            da.roundTime = Time.timeSinceLevelLoad;
            da.totalTime += da.roundTime;
            da.averageRoundTime = da.totalTime / da.numberRounds;
            SaveManager.Save(da);
            death.round_end = false;
        }
    }
   
}