using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameAnalytics : MonoBehaviour
{
    public DataClass DataClass;
    string saved_data;
    public static int numberRounds;
  

    void Start()
    {
        // DataClass DataClass = new DataClass();
        // dataClass.p1attacks = 1;
        // string saved_data = JsonUtility.ToJson(dataClass, true);
        // Debug.Log(saved_data);

    }
    //string saved_data = JsonUtility.ToJson(dataClass, true);
    // Update is called once per frame
    void Update()
    {
        // DataClass.p1attacks += 1;
        // Debug.Log(DataClass.p1jumps);
        string saved_data = JsonUtility.ToJson(DataClass, true);
        // Debug.Log(saved_data);
        System.IO.File.WriteAllText(Application.persistentDataPath + "/MatchStats.json", saved_data);
    }

    // public void AddRound()
    // {
    //     numberRounds += 1;
    //     Debug.Log(numberRounds);
    // }

}
