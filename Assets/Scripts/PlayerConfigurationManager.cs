using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerConfigurationManager : MonoBehaviour
{
    private List<PlayerConfiguration> playerConfigs;
    private AIConfiguration aiConfig;
    public static int mPlayer = 2;
    [SerializeField]
    private int MaxPlayers = 2;

    public static PlayerConfigurationManager Instance { get; private set; }

    private void Awake()
    {
        if(Instance != null)
        {
            Debug.Log("[Singleton] Trying to instantiate a second instance of a singleton class.");
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
            playerConfigs = new List<PlayerConfiguration>();
            aiConfig = new AIConfiguration();
            MaxPlayers = mPlayer;
            Debug.Log("Player max:" + MaxPlayers);
        }
        
    }

    public void HandlePlayerJoin(PlayerInput pi)
    {
        Debug.Log("Player "+ pi.playerIndex + " Joined!" );
        pi.transform.SetParent(transform);

        if(!playerConfigs.Any(p => p.PlayerIndex == pi.playerIndex))
        {
            playerConfigs.Add(new PlayerConfiguration(pi));
        }

        if (playerConfigs.Count == MaxPlayers)
        {
            transform.GetComponent<PlayerInputManager>().DisableJoining();
        }
    }

    public List<PlayerConfiguration> GetPlayerConfigs()
    {
        return playerConfigs;
    }

    public AIConfiguration GetAIConfig()
    {
        return aiConfig;
    }

    public void SetPlayerArchetype(int index, int playerAT)
    {
        playerConfigs[index].playerArchetype = playerAT;
        playerConfigs[index].PowerUpManager.setPAT(playerAT);
    }

    public string addPowerUp(int index)
    {
        if (index < playerConfigs.Count)
        { 
            int puIndex = playerConfigs[index].PowerUpManager.getRandomPowerUps(1)[0];
            playerConfigs[index].PowerUpManager.addPowerUp(puIndex);
            return playerConfigs[index].PowerUpManager.getPowerUpName(puIndex);
        }
        else
        {
            int puIndex = aiConfig.PowerUpManager.getRandomPowerUps(1)[0];
            aiConfig.PowerUpManager.addPowerUp(puIndex);
            return aiConfig.PowerUpManager.getPowerUpName(puIndex);
        }
    }
    public List<PowerUpState> getPUStates(int index)
    {
        if (index < playerConfigs.Count)
        {
            return playerConfigs[index].PowerUpManager.puStates;
        }
        else
        {
            return aiConfig.PowerUpManager.puStates;
        }
    }

    public void SetPlayerColor(int index, Material color)
    {
        playerConfigs[index].playerMaterial = color;
    }

    public void ReadyPlayer(int index)
    {
        Debug.Log("Player " + index + " is ready!");
        playerConfigs[index].isReady = true;
        if (playerConfigs.Count == MaxPlayers && playerConfigs.All(p => p.isReady == true))
        {
            // Playername is now set to Player 1 and Player 2
            GameMenu.playernamestr = "Player 1";
            GameMenu.playernamestr2 = "Player 2";
            RoundMenu.playernamestr = "Player 1";
            RoundMenu.playernamestr2 = "Player 2";
            Death_Zone.player1 = "Player 1";
            Death_Zone.player2 = "Player 2";
            SceneManager.LoadScene("GameMenu");
        }
    }

    public void ReadyStage(string stageTitle)
    {
        Debug.Log(stageTitle + " is selected!");
            // Playername is now set to Player 1 and Player 2
            GameMenu.playernamestr = "Player 1";
            GameMenu.playernamestr2 = "Player 2";
            RoundMenu.playernamestr = "Player 1";
            RoundMenu.playernamestr2 = "Player 2";
            Death_Zone.player1 = "Player 1";
            Death_Zone.player2 = "Player 2";
            SceneManager.LoadScene(stageTitle);
    }
}

public class PlayerConfiguration
{
    public PlayerConfiguration(PlayerInput pi)
    {
        PlayerIndex = pi.playerIndex;
        Input = pi;
        PowerUpManager = new PowerUpManager(0);
    }

    public PlayerInput Input { get; private set; }
    public int PlayerIndex { get; private set; }
    public bool isReady { get; set; }
    public int playerArchetype { get; set; }
    public PowerUpManager PowerUpManager { get; set; }
    public Material playerMaterial { get; set; }
}

public class AIConfiguration
{
    public AIConfiguration()
    {
        PlayerIndex = 1;
        PowerUpManager = new PowerUpManager(0);
    }

    public int PlayerIndex { get; private set; }
    public int playerArchetype { get; set; }
    public PowerUpManager PowerUpManager { get; set; }
    public Material playerMaterial { get; set; }
}