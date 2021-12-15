using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Combat : MonoBehaviour
{
    Animator controllerANIM;
    public GameObject characterOBJ;
    public Text HealthText;
    public Collider[] attackHitboxes;
    private Rigidbody rb;


    public float defense = 100;
    private float damageTaken = 0;
    private float knockbackScalar = 1;
    public float knockPercent;

    private string combatState = "IDLE";
    private bool isBlocking;

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
            //controllerANIM.SetBool("Block", true);
        }

        if(!isBlocking && isState("BLOCK"))
        { 
            stateCD = 0f;
            controllerANIM.SetBool("Block", false);
            combatState = "IDLE";
            blockCD = Time.time + blockRecovery;
        }
    }

    public void TakeDamage(float attackDamage, Vector3 attackDir)
    {
        if (isState("BLOCK"))
        {
            attackDamage = attackDamage * blockReduction;
        }
        damageTaken += attackDamage;
        rb.AddForce(attackDir * attackDamage * knockbackScalar, ForceMode.Impulse);
        UpdateHealth();
    }

    // Update is called once per frame
    void UpdateHealth()
    {
        knockPercent = damageTaken / defense;
        knockbackScalar = 1 + knockPercent / 4;
        HealthText.text = (knockPercent * 100).ToString("0") + "%";
        Debug.Log((knockPercent * 100).ToString("0") + "%");
    }

    public void Punch(InputAction.CallbackContext context)
    {

        if (context.performed && isState("IDLE") && Time.time >= attackCD)
        {
            Debug.Log("Punch!");
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
}