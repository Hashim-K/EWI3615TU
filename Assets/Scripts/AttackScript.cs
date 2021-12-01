using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour { 

public float damage = 15.0F;
public float attackDuration = 0.3F;
public bool attacking = false;

[HideInInspector]

// Notes:
// - I need to make so you cant attack when you have been hit --> for some x duration 

void Start()
{

}

void Update()
{

// If x attack key is being pressed, attacking state initialized to True
    if (Input.GetKeyDown("h"))
    {
        //attackdirection = some attack vector
        //attackduration = depends on attack
        attacking = true;
    }
}

// If player collides with trigger object then receivedamage method is called on the trigger
void OnTriggerEnter(Collider col)
{
// We need to setup tag
    if (col.tag == "Player")
    {
        if (attacking)
        {
            col.SendMessage("receiveDamage", damage, SendMessageOptions.DontRequireReceiver);
            col.SendMessage("knockback", attackdirection, SendMessageOptions.DontRequireReceiver);
        }
    }
}

//Initializes attack state and links to disable damage function in order to end the attack
void EnableDamage()
{
    if (attacking == true) return;
    attacking = true;
    StartCoroutine("DisableDamage");
}

// Waits for length of attack duration and then sets attack to False (so attack ends)
IEnumerator DisableDamage()
{
    yield return new WaitForSeconds(attackDuration);
    attacking = false;
}
