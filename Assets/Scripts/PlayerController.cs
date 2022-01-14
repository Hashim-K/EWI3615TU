using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Animator controllerANIM;
    public GameObject characterOBJ;
    private float maxSpeed;
    private float jumpForce;
    private float horizontalDir;
    private float lookDir = 1f;
    private float airDir;
    private float verticalDir;
    private bool jump;
    private bool isGrounded;
    private int jumpRemaining;
    private int maxJumps;
    private Rigidbody rb;
    private int playerID;
    private float dashDur = 0.2f;
    [SerializeField]
    private float dashMultiplier = 3f;
    private float dashEnd;

    public static string powerup;
    public static string playerwonputag;

    // Start is called before the first frame update
    void Start()
    {
        playerID = int.Parse(tag.Substring(tag.Length - 1));
        controllerANIM = characterOBJ.GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();

        if (playerID == 2)
        {
            RotatePlayer();
        }

        //Set base stats
        Archetype baseStats = new Archetype(-1);
        setPlayerControllerStats(baseStats.getPlayerControllerStats());

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

        if(Time.time < dashEnd)
        {
            rb.transform.Translate(Vector3.forward * dashMultiplier * maxSpeed);
            airDir = horizontalDir;
        }
        else if (isGrounded)
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
            GetComponent<DataClass>().sendData("Jump", playerID);
        }
        else if(jump && jumpRemaining>0)
        {
            controllerANIM.SetTrigger("Jump");
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            jumpRemaining--;
            jump = false;
            Debug.Log("Jump" + (maxJumps-jumpRemaining));
            GetComponent<DataClass>().sendData("Jump", playerID);
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

    public void setPlayerControllerStats((float mSpeed, float jumpF, int mJumps) pcStats)
    {
        maxSpeed = pcStats.mSpeed;
        jumpForce = pcStats.jumpF;
        maxJumps = pcStats.mJumps;
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

    public void WaveDash(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("Wavedash");
            dashDur = Time.time + dashDur;
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

    public void RotatePlayer()
    {
        rb.transform.Rotate(Vector3.up * 180f);
        lookDir = -1;
    }
}