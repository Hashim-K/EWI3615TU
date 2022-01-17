using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class SendAnalytics : MonoBehaviour
{
    private Stats data;
    void Start()
    {
        data = SaveManager.Load();
        StartCoroutine(Upload(data));
    }

    IEnumerator Upload(Stats data)
    {
        WWWForm form = new WWWForm();
        form.AddField("P1_Atk", data.p1attacks);
        form.AddField("P2_Atk", data.p2attacks);
        form.AddField("AI_Atk", data.aiattacks);

        form.AddField("P1_Hit", data.p1hits);
        form.AddField("P2_Hit", data.p2hits);
        form.AddField("AI_Hit", data.aihits);

        form.AddField("P1_Jump", data.p1jumps);
        form.AddField("P2_Jump", data.p2jumps);
        form.AddField("AI_jump", data.aijumps);

        form.AddField("No_Round", data.numberRounds);
        form.AddField("No_Matches", data.numberMatches);

        form.AddField("P1_Wins", data.p1wins);
        form.AddField("P2_Wins", data.p2wins);

        form.AddField("Rnd_Time", data.roundTime.ToString());
        form.AddField("AVG_RTime", data.averageRoundTime.ToString());
        form.AddField("Total_time", data.totalTime.ToString());
        form.AddField("Longest_Rnd", data.longestRound.ToString());
        form.AddField("Shortest_Rnd", data.shortestRound.ToString());

        using (UnityWebRequest www = UnityWebRequest.Post("https://www.omegabros.com/SendAnalytics.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("Data Sent!");
            }
        }
    }
}


