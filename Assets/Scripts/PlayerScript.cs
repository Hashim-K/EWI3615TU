using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    #region Properties and variabes


    [SerializeField] public float StartingHealth = 0;

    public float DamageMultiplier = 1;  //could vary by class or with powerups

    public float knockbackMultiplier = 1; //Could vary by class 

    public Text HealthText;

    public float health;

    #endregion





    // Start is called before the first frame update
    void Start()
    {
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



    public void receiveDamage(float damage)
    {

        health += damage * DamageMultiplier;
        Debug.Log("Damage Applied");
    }

    public void knockback(Vector3 attackdirection)
    {

    }


}