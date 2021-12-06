using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    #region Properties and variabes;


    [SerializeField] public float StartingHealth = 0;

    public float DamageMultiplier = 1;  //could vary by class or with powerups

    public float knockbackMultiplier = 1; //Could vary by class 
    private float x;
    public Text HealthText;

    public float health;

    private Rigidbody rb;

    

    #endregion





    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        health = StartingHealth;

        //health = StartingHealth;
        HealthText.text = StartingHealth.ToString();
        //HealthText = GetComponent<Text>();
    }




    // Update is called once per frame
    void Update()
    {
        HealthText.text = health.ToString();
    }



    public void ReceiveDamage(float damage)
    {

        health += damage * DamageMultiplier;
        Debug.Log("Damage Applied");
    }

    //
    public void Knockback(Vector3 attackDirection )
    {
        //converting from double to float (necessary for vector operations)

        x = (float)Math.Pow(health, 0.5);

        //Scale vector magnitude by damage percent taken by character
        attackDirection.z *= x;
        attackDirection.y *= x;

        //attackDirection.z *=  (float)Math.Pow(health,0.5) ;
        //attackDirection.y *= (float)Math.Pow(health, 0.5);
        attackDirection.x *= 0;

        //Applying force to rigidbody
        rb.AddForce(attackDirection, ForceMode.Impulse);
    }


}