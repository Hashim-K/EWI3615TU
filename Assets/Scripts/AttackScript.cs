using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{

    public float damage = 15.0F;
    public float attackDuration = 1F;
    public bool attacking = false;
    public float attackStrength = 1F;




    // Notes:
    // - I need to make so you cant attack when you have been hit --> for some x duration 

    void Start()
    {

    }

    void Update()
    {
        #region attacks
        // If x attack key is being pressed, attacking state initialized to True
        // We need to map attack variables to any attack
        if (Input.GetKeyDown("x"))
        {
            // z is horizontal direction
            // y is vertical direction
            //public Vector3 attackimpulse = new Vector3(5.0f, 3.0f, 5.0f);
            GetComponent<Animation>().Play("ANIMATON_NAME");
            //Animation.animatePhysics //Necessary to be true for animation to be run alongside physics (so collisions)
            damage = 5;
            attackDuration = 1;
            attacking = true;
        }
#endregion  



    }

    // If player collides with trigger object then receive damage method is called on the trigger
    void OnTriggerEnter(Collider other)
    {
        // We need to setup tag
        if (other.tag == "Player")
        {
            if (attacking)
            {
                //Calculate collision vector
                var attackDirection = transform.position - other.transform.position;


                // normalize force vector to only get direction + get rid of x component 
                attackDirection.Normalize();
                attackDirection.x = 0;

                //Send funcitons calls
                other.SendMessage("ReceiveDamage", damage, SendMessageOptions.DontRequireReceiver);
                other.SendMessage("Knockback", attackDirection, SendMessageOptions.DontRequireReceiver);
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
}
