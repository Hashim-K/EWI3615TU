using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpControllerAI : MonoBehaviour
{
    // Start is called before the first frame update
    private int playerID;

    void Start()
    {
        playerID = int.Parse(tag.Substring(tag.Length - 1))-1;
        List<PowerUpState> puStates = PlayerConfigurationManager.Instance.getPUStates(playerID);
        foreach (var pu in puStates)
        {
            applyPowerUpStates(pu);
        }
    }

    private void applyPowerUpStates(PowerUpState pu)
    {
        for (int i = 0; i < pu.currentStacks; i++)
        {
            applyPowerUp(pu.powerUpIndex);
        }
    }    

    private void applyPowerUp(int puindex)
    {
        switch (puindex)
        {
            case 0:
                GetComponent<EnemyFollow>().blockBoost();
                break;

            case 1:
                GetComponent<EnemyFollow>().speedBoost();
                break;
            
            case 2:
                GetComponent<EnemyFollow>().blockBoost();
                break;

        }    

    }
}
