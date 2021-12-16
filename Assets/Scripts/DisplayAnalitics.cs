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
    

    // Start is called before the first frame update
    void Start()
    {
        da = SaveManager.Load();


        one.text = "Player 1 attacks :" +  da.p1attacks.ToString();

        two.text ="Player 1 hits :" +  da.p1hits.ToString();

        three.text = "Player 1 jumps :" + da.p1jumps.ToString();

        four.text = "Player 1 hits :" + da.numberRounds.ToString();

        five.text ="Current roundtime:" + da.roundTime.ToString() + "seconds";

        six.text = "Average roundtime : " + da.averageRoundTime.ToString() + "seconds";

        seven.text = "Total time played : " + da.totalTime.ToString() + "seconds";

}

    // Update is called once per frame
    public void GoBack()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
