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
    public Text nine;
    public Text ten;
    public Text eleven;
    public Text twelve;
    public Text thirteen;
    public Text fourteen;
    public Text fifteen;
    public Text sixteen;
    public Text seventeen;
    public Text eighteen;

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

        two.text ="Player 2 attacks : " +  da.p2attacks.ToString();

        three.text = "AI attacks : " + da.aiattacks.ToString();

        four.text = "Player 1 hits : " + da.p1hits.ToString();

        five.text ="Player 2 hits : " + da.p2hits.ToString();

        six.text = "AI hits : " + da.aihits.ToString();

        seven.text = "Player 1 jumps :" + da.p1jumps.ToString();

        eight.text = "Player 2 jumps :" + da.p2jumps.ToString();

        nine.text = "AI jumps :" + da.aijumps.ToString();

        ten.text = "Number of rounds :" + da.numberRounds.ToString();

        eleven.text = "Number of matches :" + da.numberMatches.ToString();

        twelve.text = "Player 1 wins :" + da.p1wins.ToString();

        thirteen.text = "Player 2 wins : " + da.p2wins.ToString();

        fourteen.text = "Roundtime " + TimeConversion(da.roundTime);

        fifteen.text = "Average roundtime " + TimeConversion(da.averageRoundTime);

        sixteen.text = "Total time played : " + TimeConversion(da.totalTime);

        seventeen.text = "Longest round :  " + TimeConversion(da.longestRound);

        eighteen.text = "Shortest round : " + TimeConversion(da.shortestRound);








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
