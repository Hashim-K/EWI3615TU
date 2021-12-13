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

    public GameObject characterOBJ;
    public Text HealthText;
    public float defense = 100;
    private float damageTaken = 0;
    private float knockbackScalar = 1;
    public float knockPercent;

    private bool isBlocking = false;
    private bool isPunching = false;
    private bool isKicking = false;

    private int punchDamage = 15;
    private int kickDamage = 50;

    public Collider[] attackHitboxes;
    Animator controllerANIM;
    private Rigidbody rb;

    float timer;

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
        enemy.SetDestination(player.transform.position);

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player1"))
        {
            inRange = true;
            Debug.Log("in range = true");
            isPunching = true;
            Debug.Log("AI punch!");
            StartCoroutine("Cooldown");

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

    void TakeDamage(int attackDamage)
    {
        damageTaken += attackDamage;
        rb.AddForce(new Vector3(0, 0.5f, 2) * 5 * knockbackScalar, ForceMode.Impulse);
        UpdateHealth();
    }

    private void FixedUpdate()
    {
        if (isPunching)
        {
            isBlocking = false;
            isKicking = false;
            isPunching = false;
            controllerANIM.SetTrigger("Punch");
            controllerANIM.SetBool("Block", isBlocking);
            launchAttack(attackHitboxes[0], punchDamage);

        }
        else if (isKicking)
        {
            isBlocking = false;
            isKicking = false;
            isPunching = false;
            controllerANIM.SetTrigger("Kick");
            controllerANIM.SetBool("Block", isBlocking);
            launchAttack(attackHitboxes[1], kickDamage);
        }
    }

    void UpdateHealth()
    {
        knockPercent = damageTaken / defense;
        knockbackScalar = 1 + knockPercent / 4;
        HealthText.text = (knockPercent * 100).ToString("0") + "%";
        Debug.Log((knockPercent * 100).ToString("0") + "%");
    }

    //public void Punch(InputAction.CallbackContext context)
    //{
    //    Debug.Log("Punch!");
    //    if (context.performed)
    //    {
    //        isPunching = true;
    //    }
    //    else
    //    {
    //        isPunching = false;
    //    }
    //}

    //public void Kick(InputAction.CallbackContext context)
    //{
    //    Debug.Log("Punch!");
    //    if (context.performed)
    //    {
    //        isKicking = true;
    //    }
    //    else
    //    {
    //        isKicking = false;
    //    }
    //}

    //public void Block(InputAction.CallbackContext context)
    //{
    //}

    void launchAttack(Collider col, int attackDamage)
    {
        Collider[] cols = Physics.OverlapBox(col.bounds.center, col.bounds.extents, col.transform.rotation, LayerMask.GetMask("Hitbox"));
        foreach (Collider c in cols)
        {
            if (c.transform.root == transform)
            {
                continue;
            }

            c.SendMessageUpwards("TakeDamage", attackDamage);
        }
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(2);
    }
}
