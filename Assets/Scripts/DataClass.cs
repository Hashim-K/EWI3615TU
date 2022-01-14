using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.InputSystem;



[Serializable]
public class DataClass : MonoBehaviour
{
    public Stats da = new Stats();


    public void sendData(string Data, int playerID)
    {
        if(playerID == 1)
        {
            if (Data == "Jump")
            {
                da = SaveManager.Load();
                da.p1jumps += 1;
                SaveManager.Save(da);
            }

            if (Data == "Attack")
            {
                da = SaveManager.Load();
                da.p1attacks += 1;
                Debug.Log("attack DA");
                SaveManager.Save(da);
            }

            if (Data == "Hit")
            {
                da = SaveManager.Load();
                da.p1hits += 1;
                SaveManager.Save(da);
            }
        }
        else if(playerID == 2)
        {

            if (Data == "Jump")
            {
                da = SaveManager.Load();
                da.p2jumps += 1;
                SaveManager.Save(da);
            }

            if (Data == "Attack")
            {
                da = SaveManager.Load();
                da.p2attacks += 1;
                SaveManager.Save(da);
            }

            if (Data == "Hit")
            {
                da = SaveManager.Load();
                da.p2hits += 1;
                SaveManager.Save(da);
            }
        }
        else if(playerID == -1)
        {

            if (Data == "Jump")
            {
                da = SaveManager.Load();
                da.aijumps += 1;
                SaveManager.Save(da);
            }

            if (Data == "Attack")
            {
                da = SaveManager.Load();
                da.aiattacks += 1;
                SaveManager.Save(da);
            }

            if (Data == "Hit")
            {
                da = SaveManager.Load();
                da.aihits += 1;
                SaveManager.Save(da);
            }
        }
    }
   
}
