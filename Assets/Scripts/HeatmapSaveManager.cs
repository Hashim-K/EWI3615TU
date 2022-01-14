using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class HeatmapSaveManager
{
    public static string directory = "/Game_Analytics/";
    public static string fileName = "Heatmap.txt";


    //This could also be Update/Late update if we turn on monobehaviour on (instead of static)

    public static void Save(HeatmapStats hd)
    {
        string dir = Application.persistentDataPath + directory;

        if (!System.IO.Directory.Exists(dir)) 
        System.IO.Directory.CreateDirectory(dir);

        string json = JsonUtility.ToJson(hd);
        System.IO.File.WriteAllText(dir + fileName, json);
    }

    public static HeatmapStats Load()
    {
        string fullpath = Application.persistentDataPath + directory + fileName;
        HeatmapStats hd = new HeatmapStats();
        

        if (System.IO.File.Exists(fullpath))
        {
            string json = System.IO.File.ReadAllText(fullpath);
            hd = JsonUtility.FromJson<HeatmapStats>(json);
        }
        else
        {
            Debug.Log("Heatmap file does not exist!");
        }
        return hd;
    }

}
