// Alan Zucconi
// www.alanzucconi.com
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Threading;
 
public class Heatmapdraw : MonoBehaviour
{
    public static string directory = "/Game_Analytics/";
    public static string fileName = "Heatmap.txt";

    public HeatmapStats hd = new HeatmapStats();

    public Vector4[] positions;
    public Vector4[] properties;

 
    public Material material;
 
    public int count = 50;


 
    void Start ()
    {
        string fullpath = Application.persistentDataPath + directory + fileName;
        if (System.IO.File.Exists(fullpath))
        {
            hd = HeatmapSaveManager.Load();
            count = hd.coords.Count;

            positions = new Vector4[count];
            properties = new Vector4[count];
            
            for (int i = 0; i < positions.Length; i++)
            {
                positions[i] = hd.coords[i];
                properties[i] = new Vector4(.3f, .35f, 0, 0);
            }
        }

        else
        {
            SceneManager.LoadScene("MainMenu");  
        }
        
    }
 
    void Update()
    {
        // for (int i = 0; i < positions.Length; i++)
        //     positions[i] += new Vector4(Random.Range(-0.1f,+0.1f), Random.Range(-0.1f, +0.1f), 0, 0) * Time.deltaTime;
        string fullpath = Application.persistentDataPath + directory + fileName;
        if (System.IO.File.Exists(fullpath))
        {
            material.SetInt("_Points_Length", count);
            material.SetVectorArray("_Points", positions);
            material.SetVectorArray("_Properties", properties);
        }

    }



}