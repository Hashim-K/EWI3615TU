using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 0f;
    public float jumpForce = 8f;
    public float horizontalDir;
    public float verticalDir;
    public bool jump;
    public bool isGrounded;
    public bool hasDoubleJump;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void FixedUpdate()
    {
        rb.AddForce(Vector3.forward * horizontalDir * speed, ForceMode.Impulse);
        if (jump && isGrounded) 
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            hasDoubleJump = true;
            jump = false;
            Debug.Log("First Jump");
        }
        else if(jump && hasDoubleJump)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            hasDoubleJump= false;
            jump = false;
            Debug.Log("Second Jump");
        }
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("Platform"))
        {
            isGrounded = true;
            hasDoubleJump = true;
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
        }
        else
        {
            horizontalDir = 0f;
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

    public void North()
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

    public void South()
    {
        Debug.Log("South!");
    }

    public void West(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("West!");
            jump = true;
        }
        else
        {
            jump = false;
        }
    }

    public void RightStick()
    {
        Debug.Log("RightStick!");
    }

    public void R1()
    {
        Debug.Log("R1!");
    }
    public void R2()
    {
        Debug.Log("R2!");
    }

    public void R3()
    {
        Debug.Log("R3!");
    }
    public void L1()
    {
        Debug.Log("L1!");
    }
    public void L2()
    {
        Debug.Log("L2!");
    }
    public void L3()
    {
        Debug.Log("L3!");
    }
    public void Plus()
    {
        Debug.Log("Plus!");
    }
    public void Minus()
    {
        Debug.Log("Minus!");
    }

}