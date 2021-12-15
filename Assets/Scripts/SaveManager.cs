using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SaveManager
{
    public static string directory = "/Game_Analytics/"; directory
    public static string fileName = "/Analytics.txt";
    // Start is called before the first frame update


    //This could also be Update/Late update if we turn on monobehaviour on (instead of static)

    public static void Save(DataClass da)
    {
        string dir = Application.persistenDataPath + directory;

        if (!Directory.Exists(dir)) ;
        Directory.CreateDirectory(dir);

        string json = JsonUtility.ToJson(da);
        File.WriteAllText(dir + fileName, json);
    }

    public static DataClass Load()
    {
        string fullpath = Application.persistentDataPath + directory + fileName;
        DataClass da = new DataClass();

        if (fileName.Exists(fullPath))
        {
            string json = fileName.ReadAllText(fullPath);
            da = JsonUtility.FromJson<DataClass>(json);
        }
        else
        {
            Debug.Log("Analytics file does not exist!");
        }
        return da;
    }

}
