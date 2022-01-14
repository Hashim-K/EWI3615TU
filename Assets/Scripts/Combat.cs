using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;

public class Combat : MonoBehaviour
{
    Animator controllerANIM;
    public GameObject characterOBJ;
    public TextMeshProUGUI HealthText;
    public Collider[] attackHitboxes;
    private Rigidbody rb;
    private int playerID;

    private float defense;
    private float damageTaken = 0;
    private float knockbackScalar = 1f;
    private float knockPercent;

    private string combatState = "IDLE";
    private bool isBlocking;
    private bool isPunching;
    private bool isKicking;


    private bool isHit = false;

    public int punchDamage;
    private int kickDamage;
    private float blockReduction;


    private float attackCD = 0f;
    private float stateCD = 0f;
    private float blockCD = 0f;

    private float blockDuration = 3f;
    private float kickDuration = 1.12f;
    private float punchDuration = 1f;

    private float blockRecovery = 1.5f;
    private float kickRecovery = 0.1f;
    private float punchRecovery = 0.11f;

    

    // Start is called before the first frame update
    void Start()
    {
        playerID = int.Parse(tag.Substring(tag.Length - 1));
        controllerANIM = characterOBJ.GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody>();

        //Set base stats
        Archetype baseStats = new Archetype(-1);
        setCombatStats(baseStats.getCombatStats());
        UpdateHealth();
    }

    private void FixedUpdate()
    {
        if (!isState("IDLE") && Time.time > stateCD)
        {
            if(isState("BLOCK"))
            {
                isBlocking = false;
                controllerANIM.SetBool("Block", false);
            }
            combatState = "IDLE";
        }
        if (isBlocking && isState("IDLE") && Time.time >= blockCD)
        {
            combatState = "BLOCK";
            controllerANIM.SetBool("Block", true);
        }

        if(!isBlocking && isState("BLOCK"))
        { 
            stateCD = 0f;
            controllerANIM.SetBool("Block", false);
            combatState = "IDLE";
            blockCD = Time.time + blockRecovery;
        }


        if (isHit)
        {
            isHit = false;
        }

        if (isKicking)
        {
            isKicking = false;
        }

        if (isPunching)
        {
            isPunching = false;
        }
    }

    public void TakeDamage(float attackDamage, Vector3 attackDir)
    {
        GetComponent<DataClass>().sendData("Hit", playerID);
        if (isState("BLOCK"))
        {
            attackDamage = attackDamage * blockReduction;
        }
        isHit = true;
        damageTaken += attackDamage;
        rb.AddForce(attackDir * 5 * knockbackScalar, ForceMode.Impulse);
        
        UpdateHealth();
    }

    // Update is called once per frame
    void UpdateHealth()
    {
        knockPercent = damageTaken / defense;
        knockbackScalar = 1f + knockPercent / 4;
        HealthText.SetText((knockPercent * 100).ToString("0") + "%");
        Debug.Log((knockPercent * 100).ToString("0") + "%");
    }

    public void Punch(InputAction.CallbackContext context)
    {

        if (context.performed && isState("IDLE") && Time.time >= attackCD)
        {
            Debug.Log("Punch!");
            isPunching = true;
            combatState = "PUNCH";
            controllerANIM.SetTrigger("Punch");
            launchAttack(attackHitboxes[0], punchDamage);
            stateCD = Time.time + punchDuration;
            attackCD = stateCD + punchRecovery;
        }
    }

    public void Kick(InputAction.CallbackContext context)
    {
        if (context.performed && isState("IDLE") && Time.time >= attackCD)
        {
            Debug.Log("Kick!");
            isKicking = true;
            combatState = "KICK";
            controllerANIM.SetTrigger("Kick");
            launchAttack(attackHitboxes[1], kickDamage);
            stateCD = Time.time + kickDuration;
            attackCD = stateCD + kickRecovery;
        }
    }

    public void Block(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("Blocking");
            isBlocking = true;
            stateCD = Time.time + blockDuration;
        }
        else
        { 
            isBlocking = false;
        }
    }

    public bool isState(string state)
    {
        return combatState == state;
    }

    public void setCombatStats((float def, int punchDmg, int kickDmg, float blockRed) cStats)
    {
        defense = cStats.def;
        punchDamage = cStats.punchDmg;
        kickDamage = cStats.kickDmg;
        blockReduction = cStats.blockRed;
    }

    void launchAttack(Collider col, int attackDamage)
    {
        Collider[] cols = Physics.OverlapBox(col.bounds.center, col.bounds.extents, col.transform.rotation, LayerMask.GetMask("Hitbox"));
        foreach (Collider c in cols)
        {
            if (c.transform == transform)
            {
                continue;    
            }
            Vector3 attackDir = new Vector3(0, 0.5f, 2);
            if (c.tag.Contains("Player"))
            {
                GetComponent<DataClass>().sendData("Attack", playerID);
                Debug.Log("test");
                if (c.transform.name.Contains("AI"))
                {
                    c.GetComponentInParent<EnemyFollow>().TakeDamage(attackDamage, attackDir);
                }
                else
                { 
                    c.GetComponentInParent<Combat>().TakeDamage(attackDamage, attackDir);
                }
            }
            
        }
    }
}