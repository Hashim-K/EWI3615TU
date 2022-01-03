using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public PowerUps puList;
    public List<PowerUpState> puStates;
    private int playerArchetype;

    void Start()
    { 
        puList = new PowerUps();
        if (puStates == null)
        {
            puStates = new List<PowerUpState>();
        }
        playerArchetype = GetComponent<ArchetypeManager>().playerArchetype;
    }
    
    public void addPowerUp(int puIndex)
    {
        int stateIndex = powerUpIndex(puIndex);
        if (stateIndex == -1)
        {
            PowerUpState puState = new PowerUpState(puIndex);
            puStates.Add(puState);
        }
        else
        {
            puStates[stateIndex].currentStacks++;
        }

    }

    public int powerUpIndex(int puIndex)
    //returns the index of the powerUp in the puStates List, if not in the list return -1
    {
        for (int i = 0; i < puStates.Count; i++)
        {
            if (puIndex == puStates[i].powerUpIndex)
                return i;
        }
        return -1;
    }


    public List<int> getPossiblePowerUps()
    //returns a list containing an array of integers of all the possible powerUps a player can obtain
    {
        List<int> possiblePU = new List<int>();
        foreach (var pu in puList.list)
        {
            int puIndex = powerUpIndex(pu.powerUpIndex);
            if (puIndex == -1)
            {
                possiblePU.Add(pu.powerUpIndex);
            }
            else if (pu.canPowerUp(puStates[puIndex].currentStacks, playerArchetype))
            {
                possiblePU.Add(pu.powerUpIndex);
            }
        }
        return possiblePU;
    }


    public List<int> getWeightedList(List<int> possiblePU)
    {
        List<int> weightedList = new List<int>();
        foreach (var puIndex in possiblePU)
        {
            for (int i = 0; i < puList.getWeight(puIndex); i++)
            {
                weightedList.Add(puIndex);
            }
        }
        return weightedList;

    }


    public List<int> getRandomPowerUps(int count)
    //returns a random unqiue selection () of powerups from the possiblePUs
    {
        List<int> possiblePU = getPossiblePowerUps();
        List<int> randomPUs = new List<int>();
        if (count > possiblePU.Count)
        {
            return possiblePU;
        }

        List<int> weightedPU = getWeightedList(possiblePU);
        while (count > 0)
        {
            int puIndex = possiblePU[UnityEngine.Random.Range(0, weightedPU.Count)];
            if (!randomPUs.Contains(puIndex))
            {
                count--;
                randomPUs.Add(puIndex);
            }
        }
        return randomPUs;
    }
}

public class PowerUp
    //class containing basic powerUp information
{
    public PowerUp(int index)
    {
        powerUpIndex = index;
        maxStacks = 3;
        weight = 1;
        compatibleArchetypes = Archetypes.getArchtypeIndexList();
    }

    public int powerUpIndex { get; set; }

    public int maxStacks { get; set; }

    public int weight {get; set; }

    public List<int> compatibleArchetypes { get; set; }

    public bool canPowerUp(int currentStacks, int playerArchetype)
    {
        return (maxStacks > currentStacks && compatibleArchetypes.Contains(playerArchetype));
    }
}

public class PowerUps
//class to hold list of PowerUpDataEntries
{
    public PowerUps()
    {
        list = new List<PowerUp>();
        list.Add(JumpBoost(0));
    }

    public List<PowerUp> list { get; set; }

    public int getWeight(int puIndex)
    {
        return list[puIndex].weight;
    }


    public PowerUp JumpBoost(int id)
    {
        PowerUp jumpBoost = new PowerUp(0);
        return jumpBoost;
    }


}

public class PowerUpState
    //class containing the current amount of powerup stacks for the respective powerUp of index powerUpIndex
{
    public PowerUpState(int pIndex)
    {
        powerUpIndex = pIndex;
        currentStacks = 1;
    }

    public int powerUpIndex { get; set; }
    public int currentStacks { get; set; }

}