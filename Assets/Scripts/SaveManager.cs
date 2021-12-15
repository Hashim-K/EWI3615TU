using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SaveManager
{
    public static string directory = "/Game_Analytics/"; 
    public static string fileName = "Analytics.txt";


    //This could also be Update/Late update if we turn on monobehaviour on (instead of static)

    public static void Save(Stats da)
    {
        string dir = Application.persistentDataPath + directory;

        if (!System.IO.Directory.Exists(dir)) 
        System.IO.Directory.CreateDirectory(dir);

        string json = JsonUtility.ToJson(da);
        System.IO.File.WriteAllText(dir + fileName, json);
    }

    public static Stats Load()
    {
        string fullpath = Application.persistentDataPath + directory + fileName;
        Stats da = new Stats();

        if (System.IO.File.Exists(fullpath))
        {
            string json = System.IO.File.ReadAllText(fullpath);
            da = JsonUtility.FromJson<Stats>(json);
        }
        else
        {
            Debug.Log("Analytics file does not exist!");
        }
        return da;
    }

}
