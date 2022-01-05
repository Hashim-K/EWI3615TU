using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelInitializer : MonoBehaviour
{
    [SerializeField]
    private Transform[] PlayerSpawns;

    [SerializeField]
    private TextMeshProUGUI[] HealthTexts;

    [SerializeField]
    private GameObject playerPrefab;
    private GameObject[] players;
    // Start is called before the first frame update
    void Start()
    {
        var playerConfigs = PlayerConfigurationManager.Instance.GetPlayerConfigs().ToArray();
        players = new GameObject[2];
        for (int i = 0; i < playerConfigs.Length; i++)
        {
            players[i] = Instantiate(playerPrefab, PlayerSpawns[i].position, PlayerSpawns[i].rotation, gameObject.transform);
            players[i].tag = "Player" + (i+1).ToString();
            players[i].GetComponent<PlayerInputHandler>().InitializePlayer(playerConfigs[i]);
            players[i].GetComponent<Combat>().HealthText = HealthTexts[i];
            players[i].GetComponent<ArchetypeManager>().playerArchetype = (playerConfigs[i].playerArchetype);
            players[i].GetComponent<PowerUpManager>().puStates = playerConfigs[i].puStates;
            if (playerConfigs.Length == 1)
            {
                transform.GetChild(0).gameObject.SetActive(true);
                transform.GetChild(0).gameObject.GetComponent<EnemyFollow>().HealthText=HealthTexts[1];
                transform.GetChild(0).gameObject.GetComponent<EnemyFollow>().player = players[i].transform;
                players[1] = transform.GetChild(0).gameObject;
            }
        }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void destroyPlayers()
    {
        foreach (var player in players)
        {
            Destroy(player, 2);
        }
    }
}
