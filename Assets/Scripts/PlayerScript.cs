using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    #region Properties and variabes


    [SerializeField] private float StartingHealth = 0;

    public float DamageMultiplier = 1;  //could vary by class or with powerups

    public Text HealthText;

    private float health;

    #endregion


    


    // Start is called before the first frame update
    void Start()
    {
        ResetHealth();

        //health = StartingHealth;
        HealthText.text = StartingHealth.ToString();
        //HealthText = GetComponent<Text>();
    }

    public void ResetHealth()
    {
        health = StartingHealth;
    }

    private void OnTriggerEnter(Collider other)
    {
        // We use tags to identify collisino with player
        if (other.gameObject.CompareTag("player"))
        {
            // 'Force' here is a variable determined by other players attack, possibly output of a function from melee system
            // We need a direction and a magnitude
            // How do we slow down the player?, maybe some kind of drag

            //health += DamageMultiplier * force;


            // Here we need to add force to act upon player


        }
    }
    

    // Update is called once per frame
    void Update()
    {
        HealthText.text = health.ToString();
    }


    private void TakeDamage(float damageAmount)
    {
        // Add damage to health based on damage multiplier and external attack
        health += damageAmount * DamageMultiplier;

        
    }

