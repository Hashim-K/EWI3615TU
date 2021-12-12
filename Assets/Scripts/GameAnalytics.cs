using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAnalytics : MonoBehaviour
{
    public DataClass dataClass;
    string saved_data;
    public static int numberRounds;
  

    void Start()
    {
        DataClass dataClass = new DataClass();
        dataClass.p1attacks = 1;
    }
    //string saved_data = JsonUtility.ToJson(dataClass, true);
    // Update is called once per frame
    void Update()
    {

        //string saved_data = JsonUtility.ToJson(dataClass, true);
        //Debug.Log(saved_data);
    }

    public void AddRound()
    {
        numberRounds += 1;
        Debug.Log(numberRounds);
    }

}
