using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArchetypeManager : MonoBehaviour
{

    private Archetype[] ArchetypeList = new Archetypes().list;
    public int playerArchetype = -1;
    private bool setAT = false;

    void Start()
    {
        ArchetypeList = new Archetypes().list;
    }

    void Update()
    {
        //if Archetype hasn't been set yet and an Archetype has been assigned then set stats
        if (ArchetypeList != null && !setAT && playerArchetype != -1)
        { 
            setArchetype(playerArchetype);
            setAT = true;
        }
    }

    public void setArchetype(int id)
    //set combat and movement stats
    {
            gameObject.GetComponent<Combat>().setCombatStats(ArchetypeList[id].getCombatStats());
            gameObject.GetComponent<PlayerController>().setPlayerControllerStats(ArchetypeList[id].getPlayerControllerStats());
    }

}

public class Archetype
{
    public Archetype(int id)
    //class to contain the Archetype specific stats
    {
        archetypeID = id;

        //base combat stat values
        defense = 100;
        punchDamage = 30;
        kickDamage = 20;
        blockReduction = 0.5f;

        //base movement stat values
        maxSpeed = 4f;
        jumpForce = 8f;
        maxJumps = 3;
    }
    
    public (float, int, int, float) getCombatStats()
    //return the combat stats as a tuple
    {
        return (defense, punchDamage, kickDamage, blockReduction);
    }

    public (float, float, int) getPlayerControllerStats()
    //return the movement stats as a tuple
    {
        return (maxSpeed, jumpForce, maxJumps);
    }

    public int archetypeID { get; set; }
    public float defense { get; set; }
    public int punchDamage { get; set; }
    public int kickDamage { get; set; }
    public float blockReduction { get; set; }
    public float maxSpeed { get; set; }
    public float jumpForce  { get; set; }
    public int maxJumps { get; set; }

}

public class Archetypes
{
    public Archetypes()
    //initialize a list of all the Archetypes
    {
        list = new Archetype[5];

        //assign Archetypes to an index
        list[0] = Brawler(0);
        list[1] = GlassCannon(1);

    }

    public Archetype[] list { get; set; }

    public static int getArchetypes()
    //Returns the amount of Archetypes that exist
    {
        Archetypes atList = new Archetypes();
        return atList.list.Length;
    }

    public static List<int> getArchtypeIndexList()
    //return a list containing the indeces of all Archetypes
    //(useful when making blacklisting powerups from archetype
    //as the full list can be initialized and then the black listed archetypes can be removed)
    {
        List<int> indexList = new List<int>();
        for (int i = 0; i < Archetypes.getArchetypes(); i++)
        {
            indexList.Add(i);
        }
        return indexList;
    }

    public Archetype Brawler(int id)
    //Stats for brawler Archetype
    {
        Archetype Brawler = new Archetype(id);
        Brawler.punchDamage = 40;
        Brawler.kickDamage = 30;
        Brawler.jumpForce = 6f;
        Brawler.maxJumps = 2;

        return Brawler;
    }

    public Archetype GlassCannon(int id)
    //Stats for Glasscannon Archetype
    {
        Archetype GlassCannon = new Archetype(id);
        GlassCannon.punchDamage = 80;
        GlassCannon.kickDamage = 60;
        GlassCannon.defense = 35;

        return GlassCannon;
    }
}