using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heatmap : MonoBehaviour
{
    public static string directory = "/Game_Analytics/";
    public static string fileName = "Heatmap.txt";

    private Vector2 yzcoords;

    private float ycoord;
    private float zcoord;

    private float rounded_y;
    private float rounded_z;

    public HeatmapStats hd = new HeatmapStats();

    void Start()
    {
        // string fullpath = Application.persistentDataPath + directory + fileName;
        // if (System.IO.File.Exists(fullpath))
        // {
        //     hd = HeatmapSaveManager.Load();
        // }
    }

    void FixedUpdate()
    {
        // hd = HeatmapSaveManager.Load();
        // hd = HeatmapSaveManager.Load();
        ycoord = GetComponent<Rigidbody>().position.y;
        zcoord = GetComponent<Rigidbody>().position.z;
        rounded_y = Mathf.Round(ycoord * 1000f) / 1000f;
        rounded_z = Mathf.Round(zcoord * 1000f) / 1000f;

        yzcoords = new Vector2(rounded_y, rounded_z);
        hd.coords.Add(yzcoords);
        HeatmapSaveManager.Save(hd);
    }

}
