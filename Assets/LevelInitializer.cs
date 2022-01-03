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
    // Start is called before the first frame update
    void Start()
    {
        var playerConfigs = PlayerConfigurationManager.Instance.GetPlayerConfigs().ToArray();
        for (int i = 0; i < playerConfigs.Length; i++)
        {
            var player = Instantiate(playerPrefab, PlayerSpawns[i].position, PlayerSpawns[i].rotation, gameObject.transform);
            player.tag = "Player" + (i+1).ToString();
            player.GetComponent<PlayerInputHandler>().InitializePlayer(playerConfigs[i]);
            player.GetComponent<Combat>().HealthText = HealthTexts[i];
            player.GetComponent<ArchetypeManager>().playerArchetype = (playerConfigs[i].playerArchetype);
            if (playerConfigs.Length == 1)
            {
                transform.GetChild(0).gameObject.SetActive(true);
                transform.GetChild(0).gameObject.GetComponent<EnemyFollow>().HealthText=HealthTexts[1];
                transform.GetChild(0).gameObject.GetComponent<EnemyFollow>().player = player.transform;
            }
        }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
