using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;

    private Rigidbody rb;

    private float movementY;
    private float movementZ;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementY = movementVector.x;
        movementZ = movementVector.y;
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(0.0f, movementZ, movementY);

        rb.AddForce(movement * speed);
    }
}