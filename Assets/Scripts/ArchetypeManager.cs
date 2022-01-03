using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArchetypeManager : MonoBehaviour
{

    private Archetype[] ArchetypeList = new Archetypes().list;
    public int playerArchetype = -1;

    void Start()
    {
        ArchetypeList = new Archetypes().list;
    }

    void update()
    {
        if (playerArchetype != -1)
        { 
            setArchetype(playerArchetype);
        }
    }

    public void setArchetype(int id)
    {
        playerArchetype = id;
        Debug.Log("length: "+ ArchetypeList.Length);
        gameObject.GetComponent<Combat>().setCombatStats(ArchetypeList[id].getCombatStats());
        gameObject.GetComponent<PlayerController>().setPlayerControllerStats(ArchetypeList[id].getPlayerControllerStats());
    }

}

public class Archetype
{
    public Archetype(int id)
    {
        archetypeID = id;

        defense = 100;
        punchDamage = 30;
        kickDamage = 20;
        blockReduction = 0.5f;

        maxSpeed = 4f;
        jumpForce = 8f;
        maxJumps = 3;
    }
    
    public (float, int, int, float) getCombatStats()
    {
        return (defense, punchDamage, kickDamage, blockReduction);
    }

    public (float, float, int) getPlayerControllerStats()
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
    {
        list = new Archetype[5];
        list[0] = Brawler(0);
        list[1] = GlassCannon(1);

    }

    public Archetype[] list { get; set; }

    public static int getArchetypes()
    {
        Archetypes atList = new Archetypes();
        return atList.list.Length;
    }

    public static List<int> getArchtypeIndexList()
    {
        List<int> indexList = new List<int>();
        for (int i = 0; i < Archetypes.getArchetypes(); i++)
        {
            indexList.Add(i);
        }
        return indexList;
    }

    public Archetype Brawler(int id)
    {
        Archetype Brawler = new Archetype(id);
        Brawler.punchDamage = 40;
        Brawler.kickDamage = 30;
        Brawler.jumpForce = 6f;
        Brawler.maxJumps = 2;

        return Brawler;
    }

    public Archetype GlassCannon(int id)
    {
        Archetype GlassCannon = new Archetype(id);
        GlassCannon.punchDamage = 80;
        GlassCannon.kickDamage = 60;
        GlassCannon.defense = 35;

        return GlassCannon;
    }
}