// Alan Zucconi
// www.alanzucconi.com
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Threading;
 
public class Heatmapdraw : MonoBehaviour
{
    public HeatmapStats hd = new HeatmapStats();

    public Vector4[] positions;
    public Vector4[] properties;

    public GameObject text;
 
    public Material material;
 
    public int count = 50;


 
    void Start ()
    {
        hd = HeatmapSaveManager.Load();
        Debug.Log(hd.coords);
        text.SetActive(false);
        count = hd.coords.Count;

            Debug.Log(hd.coords);

            positions = new Vector4[count];
            properties = new Vector4[count];
        
            for (int i = 0; i < positions.Length; i++)
            {
                positions[i] = hd.coords[i];
                properties[i] = new Vector4(.5f, 0.2f, 0, 0);
            }
    
    }
 
    void Update()
    {
        // for (int i = 0; i < positions.Length; i++)
        //     positions[i] += new Vector4(Random.Range(-0.1f,+0.1f), Random.Range(-0.1f, +0.1f), 0, 0) * Time.deltaTime;

            material.SetInt("_Points_Length", count);
            material.SetVectorArray("_Points", positions);
            material.SetVectorArray("_Properties", properties);

    }

    IEnumerator waitCouple()
    {
        yield return new WaitForSeconds(1);

        //RoundMenu.playerscoreint = RoundMenu.playerscoreint + 1;
        SceneManager.LoadScene("MainMenu");    
    }


}