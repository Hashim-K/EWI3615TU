using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DisplayAnalitics : MonoBehaviour
{
    public Stats da;

    public Text one;
    public Text two;
    public Text three;
    public Text four;
    public Text five;
    public Text six;
    public Text seven;
    public Text eight;
    private int hours;
    private int minutes;
    private int seconds;
    private string converted_time;
    

    // Start is called before the first frame update
    void Start()
    {
        da = SaveManager.Load();
        TimeConversion(da.roundTime);

        one.text = "Player 1 attacks : " +  da.p1attacks.ToString();

        two.text ="Player 1 hits : " +  da.p1hits.ToString();

        three.text = "Player 1 jumps : " + da.p1jumps.ToString();

        four.text = "Rounds played : " + da.numberRounds.ToString();

        five.text ="Last roundtime : " + TimeConversion(da.roundTime);

        six.text = "Average roundtime : " + TimeConversion(da.averageRoundTime);

        seven.text = "Total time played : " + TimeConversion(da.totalTime);

        eight.text = "Matches played : " + da.numberMatches.ToString();

        

}

    // Update is called once per frame
    public void GoBack()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public string TimeConversion(float input)
    {
        hours = ((int)(input / 3600));
        minutes = ((int)((input / 60) - (hours*60)));
        seconds = ((int)(input - hours * 3600 - minutes * 60));
        converted_time = hours.ToString() + ":" + minutes.ToString("00") + ":" + seconds.ToString("00");
        
        return converted_time;
    }
}
