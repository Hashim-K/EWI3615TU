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

    public int p1attacks;
    public int p2attacks;

    public int p1hits;
    public int p2hits;

    public int p1jumps; 
    public int p2jumps;

    // public int number_matches;
    public int numberRounds;

    public float roundTime;
    // public float averageRoundTime;


   // public static int numberRounds;

//    public Stats MatchAnalytics = new Stats();

    void Awake()
    {
        numberRounds += 1;

    }

    void Start()
    {
        jumping = false;
        attacking = false;
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

       if(death.round_end)
       {
           roundTime = Time.timeSinceLevelLoad;

       }

   }

    void FixedUpdate()
    {
        if(jumping)
        {
            p1jumps += 1;
            jumping = false;
        }

        if(attacking)
        {
            p1attacks += 1;
            attacking = false;
        }

        if(hit)
        {
            p1hits += 1;
            hit = false;
        }

    }
}
