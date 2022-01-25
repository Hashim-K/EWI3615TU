using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PowerUpManager
{
    public PowerUps puList;
    public List<PowerUpState> puStates;
    private int playerArchetype;

    public PowerUpManager(int pAT)
    { 
        puList = new PowerUps();
        puStates = new List<PowerUpState>();
        playerArchetype =pAT;
    }
    
    public void setPAT(int pAT)
    {
        playerArchetype = pAT;
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

    public String getPowerUpName(int puIndex)
    {
        return puList.list[puIndex].powerUpName;
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
            Debug.Log(weightedPU.Count);
            int puIndex = weightedPU[UnityEngine.Random.Range(0, weightedPU.Count)];
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
    public PowerUp(int index, string name,int mS = 1, int w = 1)
    {
        powerUpIndex = index;
        powerUpName = name;
        maxStacks = mS;
        weight = w;
        compatibleArchetypes = Archetypes.getArchtypeIndexList();
    }

    public int powerUpIndex { get; set; }
    public string powerUpName { get; set; }
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

        //create PowerUps here
        list.Add(powerupTemplate("JumpBoost", w: 4, mS: 4, blackList:new int[]{2, 3}));
        list.Add(powerupTemplate("SpeedBoost", w: 6, mS: 3));
        list.Add(powerupTemplate("BlockBoost", w: 3, mS: 5));
    }

    public List<PowerUp> list { get; set; }

    public int getWeight(int puIndex)
    {
        return list[puIndex].weight;
    }


    public PowerUp powerupTemplate(string name, int id = -1, int w = 1, int mS = 1, int[] blackList = null)
    {
        if (id == -1)
        {
            id = list.Count;
        }
        PowerUp powerupTemplate = new PowerUp(id, name, mS, w);
        if (blackList != null)
        {
            foreach (var indexAT in blackList)
            {
                powerupTemplate.compatibleArchetypes.Remove(indexAT);
            }
        }
        return powerupTemplate;
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