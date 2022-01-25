using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class LevelInitializer : MonoBehaviour
{
    [SerializeField]
    private Transform[] PlayerSpawns;

    [SerializeField]
    private TextMeshProUGUI[] HealthTexts;

    [SerializeField]
    private GameObject playerPrefab;
    private GameObject[] players;

    private bool underwater = false;
    private float timeUpdate;
    private int playersC;
    // Start is called before the first frame update
    void Start()
    {
        var playerConfigs = PlayerConfigurationManager.Instance.GetPlayerConfigs().ToArray();
        playersC = playerConfigs.Length;
        players = new GameObject[2];
        for (int i = 0; i < playerConfigs.Length; i++)
        {
            players[i] = Instantiate(playerPrefab, PlayerSpawns[i].position, PlayerSpawns[i].rotation, gameObject.transform);
            players[i].tag = "Player" + (i+1).ToString();
            players[i].GetComponent<PlayerInputHandler>().InitializePlayer(playerConfigs[i]);
            players[i].GetComponent<Combat>().HealthText = HealthTexts[i];
            players[i].GetComponent<ArchetypeManager>().playerArchetype = (playerConfigs[i].playerArchetype);
            if(SceneManager.GetActiveScene().name == "Stage_5")
            {
                underwater = true;
                timeUpdate = Time.time + 1f;
            }
            if (playersC == 1)
            {
                transform.GetChild(0).gameObject.SetActive(true);
                transform.GetChild(0).gameObject.GetComponent<EnemyFollow>().HealthText=HealthTexts[1];
                transform.GetChild(0).gameObject.GetComponent<EnemyFollow>().player = players[i].transform;
                transform.GetChild(0).gameObject.GetComponent<NavMeshAgent>().speed=4f;
                transform.GetChild(0).gameObject.GetComponent<NavMeshAgent>().acceleration=8f;
                players[1] = transform.GetChild(0).gameObject; 
                if(underwater)
                {
                    transform.GetChild(0).gameObject.GetComponent<NavMeshAgent>().speed=2f;
                    transform.GetChild(0).gameObject.GetComponent<NavMeshAgent>().acceleration=4f;
                }
            }
        }
        
        
    }


    // Update is called once per frame
    void Update()
    {
        if (Time.time > timeUpdate && underwater)
        {
            for (int i = 0; i < playersC; i++)
            {
                players[i].gameObject.GetComponent<PlayerController>().setSpeed(0.5f);
            }
            underwater = false;
        }
        
    }

    public void destroyPlayers()
    {
        foreach (var player in players)
        {
            Destroy(player, 2);
        }
    }
}
