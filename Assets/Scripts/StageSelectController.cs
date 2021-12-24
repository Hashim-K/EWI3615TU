using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StageSelectController : MonoBehaviour
{
    private float ignoreInputTime = 0.5f;
    private bool inputEnabled;
    [SerializeField]
    private GameObject readyPanel;
    [SerializeField]
    private Button readyButton;
    [SerializeField]
    private string[] stages;
    private string stageTitle;
    
    // Start is called before the first frame update
    void Start()
    { 
        ignoreInputTime = Time.time + ignoreInputTime;
        stageTitle = stages[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > ignoreInputTime)
        {
            inputEnabled = true;
        }
    }

    public void SelectStage(int stageNumber)
    {
        if (!inputEnabled) { return; }
        if (stageNumber == -1)
        {
            stageNumber = UnityEngine.Random.Range(0, stages.Length);
        }
        stageTitle = stages[stageNumber];
        readyPanel.SetActive(true);
        readyButton.interactable = true;
        readyButton.Select();

    }

    public void ReadyStage()
    {
        if (!inputEnabled) { return; }

        PlayerConfigurationManager.Instance.ReadyStage(stageTitle);
        readyButton.gameObject.SetActive(false);
    }
}
