using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyFollow : MonoBehaviour
{
    public NavMeshAgent enemy;
    public Transform player;
    private bool inRange = false;

    public Text HealthText;

    Animator controllerANIM;
    public GameObject characterOBJ;
    //public Text HealthText;
    public Collider[] attackHitboxes;
    private Rigidbody rb;


    public float defense = 100;
    private float damageTaken = 0;
    private float knockbackScalar = 1;
    public float knockPercent;

    private string combatState = "IDLE";
    private bool isBlocking;

    public bool isHit = false;

    private int punchDamage = 15;
    private int kickDamage = 50;
    public float blockReduction = 0.5f;


    private float attackCD = 0f;
    private float stateCD = 0f;
    private float blockCD = 0f;

    public float blockDuration = 3f;
    private float kickDuration = 1f;
    private float punchDuration = 1f;

    public float blockRecovery = 1.5f;
    private float kickRecovery = 0.1f;
    private float punchRecovery = 0.11f;

    // Start is called before the first frame update
    void Start()
    {
        UpdateHealth();
        controllerANIM = characterOBJ.GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy.enabled == true)
        {
            enemy.SetDestination(player.transform.position);
        }
        

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player1"))
        {
            inRange = true;
            Debug.Log("in range = true");

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player1"))
        {
            inRange = false;
            Debug.Log("in range = false");
        }
    }

        public void TakeDamage(float attackDamage, Vector3 attackDir)
    {
        if (isState("BLOCK"))
        {
            attackDamage = attackDamage * blockReduction;
        }
        isHit = true;
        damageTaken += attackDamage;
        GetComponent<NavMeshAgent>().enabled = false;
        Debug.Log("navmeshagent is disabled");
        rb.AddForce(attackDir * 5 * knockbackScalar, ForceMode.Impulse);
        GetComponent<NavMeshAgent>().enabled = true;
        Debug.Log("navmeshagent is enabled");
        UpdateHealth();
    }

    private void FixedUpdate()
    {
        if (!isState("IDLE") && Time.time > stateCD)
        {
            if (isState("BLOCK"))
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

        if (!isBlocking && isState("BLOCK"))
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
    }

    public void Punch()
    {

        if (isState("IDLE") && Time.time >= attackCD)
        {
            Debug.Log("Punch!");
            combatState = "PUNCH";
            controllerANIM.SetTrigger("Punch");
            launchAttack(attackHitboxes[0], punchDamage);
            stateCD = Time.time + punchDuration;
            attackCD = stateCD + punchRecovery;
        }
    }

    public void Kick()
    {
        if (isState("IDLE") && Time.time >= attackCD)
        {
            Debug.Log("Kick!");
            combatState = "KICK";
            controllerANIM.SetTrigger("Kick");
            launchAttack(attackHitboxes[1], kickDamage);
            stateCD = Time.time + kickDuration;
            attackCD = stateCD + kickRecovery;
        }
    }

    public void Block(bool input)
    {
        if (input)
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

    void launchAttack(Collider col, int attackDamage)
    {
        Collider[] cols = Physics.OverlapBox(col.bounds.center, col.bounds.extents, col.transform.rotation, LayerMask.GetMask("Hitbox"));
        foreach (Collider c in cols)
        {
            if (c.transform.root == transform)
            {
                continue;
            }
            c.GetComponentInParent<Combat>().TakeDamage(attackDamage, new Vector3(0, 0.5f, 2));
        }
    }
    void UpdateHealth()
    {
        knockPercent = damageTaken / defense;
        knockbackScalar = 1 + knockPercent / 4;
        //HealthText.text = (knockPercent * 100).ToString("0") + "%";
        Debug.Log((knockPercent * 100).ToString("0") + "%");
    }
}

