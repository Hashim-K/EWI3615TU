using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Animator controllerANIM;
    public GameObject characterOBJ;
    public float maxSpeed = 4f;
    public float jumpForce = 8f;
    private float horizontalDir;
    private float lookDir = 1f;
    private float airDir;
    private float verticalDir;
    public bool jump;
    private bool isGrounded;
    private int jumpRemaining;
    public int maxJumps = 3;
    private Rigidbody rb;

    public static string powerup;
    public static string playerwonputag;

    // Start is called before the first frame update
    void Start()
    {
        controllerANIM = characterOBJ.GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        maxSpeed = 4f;
        jumpForce = 8f;
        maxJumps = 3;
        // Change values for powerup values

        if ((powerup == "JumpBoost") && (rb.CompareTag(playerwonputag)))
        {
            jumpForce = 10f;
            maxJumps = 4;
        }

        if ((powerup == "FastSpeed") && (rb.CompareTag(playerwonputag)))
        {
            maxSpeed = 7f;
        }

    }
    public void FixedUpdate()
    {
        if (lookDir == -1 * horizontalDir)
        {
            rb.transform.Rotate(Vector3.up * 180f);
            lookDir = horizontalDir;
        }
        if (isGrounded)
        {
            rb.transform.Translate(Vector3.forward * maxSpeed * Mathf.Abs(horizontalDir) * Time.deltaTime);
            airDir = horizontalDir;
        }
        else
        {
            if (horizontalDir != 0)
            {
                airDir = horizontalDir;
            }
            rb.transform.Translate(Vector3.forward * maxSpeed * 0.4f * Mathf.Abs(airDir + 2*horizontalDir) * Time.deltaTime);
        }
        //Debug.Log(rb.velocity.z);
        if (jump && isGrounded) 
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            controllerANIM.SetTrigger("Jump");
            jumpRemaining = maxJumps-1;
            jump = false;
            Debug.Log("Jump" + (maxJumps-jumpRemaining));
        }
        else if(jump && jumpRemaining>0)
        {
            controllerANIM.SetTrigger("Jump");
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            jumpRemaining--;
            jump = false;
            Debug.Log("Jump" + (maxJumps-jumpRemaining));
        }
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("Platform"))
        {
            isGrounded = true;
            jumpRemaining = maxJumps;
        }
    }

    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name.Contains("Platform"))
        {
            isGrounded = false;
        }
    }

    public void Horizontal(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("Horizontal!");
            horizontalDir = (float)context.ReadValueAsObject();
            controllerANIM.SetBool("Forward", true);
        }
        else
        {
            horizontalDir = 0f;
            controllerANIM.SetBool("Forward", false);
        }

    }

    public void Vertical(InputAction.CallbackContext context)
    {
       if (context.performed)
        {
            Debug.Log("Vertical!");
            verticalDir = (float)context.ReadValueAsObject();
        }
        else
        {
            verticalDir = 0f;
        }
    }

    public void North(InputAction.CallbackContext context)
    {
        Debug.Log("North!");
    }

    public void East(InputAction.CallbackContext context)
    { 
        if (context.performed)
        {
            Debug.Log("East!");
        }
    }

    public void South(InputAction.CallbackContext context)
    {
        Debug.Log("South!");
    }

    public void West(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            //Debug.Log("West!");
            jump = true;
        }
        else
        {
            jump = false;
        }
    }

    public void RightStick(InputAction.CallbackContext context)
    {
        Debug.Log("RightStick!");
    }

    public void R1(InputAction.CallbackContext context)
    {
        Debug.Log("R1!");
    }
    public void R2(InputAction.CallbackContext context)
    {
        Debug.Log("R2!");
    }

    public void R3(InputAction.CallbackContext context)
    {
        Debug.Log("R3!");
    }
    public void L1(InputAction.CallbackContext context)
    {
        Debug.Log("L1!");
    }
    public void L2(InputAction.CallbackContext context)
    {
        Debug.Log("L2!");
    }
    public void L3(InputAction.CallbackContext context)
    {
        Debug.Log("L3!");
    }
    public void Plus(InputAction.CallbackContext context)
    {
        Debug.Log("Plus!");
    }
    public void Minus(InputAction.CallbackContext context)
    {
        Debug.Log("Minus!");
    }

}