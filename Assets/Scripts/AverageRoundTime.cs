using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AverageRoundTime : MonoBehaviour
{

    public Stats da = new Stats();

    
    void Awake()
    {
        da = SaveManager.Load();
    }
    
    void Start()
    {
        da.totalTime += da.roundTime;
        da.averageRoundTime = da.totalTime / da.numberRounds;

        SaveManager.Save(da);
    }



}
