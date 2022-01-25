using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSetupMenuController : MonoBehaviour
{
    private int playerIndex;

    [SerializeField]
    private TextMeshProUGUI titleText;
    [SerializeField]

    private GameObject atSelector; 
    [SerializeField]
    private GameObject cSelector;

    [SerializeField]
    private Button readyButton;
    [SerializeField]
    private GameObject readyText;

    [SerializeField]
    private Material[] matList;

    private float ignoreInputTime = 0.5f;
    private bool inputEnabled;
    public void setPlayerIndex(int pi)
    {
        playerIndex = pi;
        titleText.SetText("Player " + (pi + 1).ToString());
        ignoreInputTime = Time.time + ignoreInputTime;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > ignoreInputTime)
        {
            inputEnabled = true;
        }
    }
    public void SelectArchetype(int index)
    {
        if(!inputEnabled) { return; }

        PlayerConfigurationManager.Instance.SetPlayerArchetype(playerIndex, index);
        
    }

    public void SelectColor(int index)
    {
        if(!inputEnabled) { return; }

        PlayerConfigurationManager.Instance.SetPlayerColor(playerIndex, matList[index]);
        
    }

    public void ReadyPlayer()
    {
        if (!inputEnabled) { return; }
        SelectArchetype(atSelector.GetComponent<SettingController>().getIndex());
        SelectColor(cSelector.GetComponent<SettingController>().getIndex());
        PlayerConfigurationManager.Instance.ReadyPlayer(playerIndex);
        readyButton.gameObject.SetActive(false);
        readyText.SetActive(true);
        atSelector.GetComponentInChildren<Button>().interactable = false;
        cSelector.GetComponentInChildren<Button>().interactable = false;
    }
}
