using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using System;
using Unity.VisualScripting;
using UnityEngine.InputSystem;
using System.Net.Sockets;

public class Rzaba : MonoBehaviour
{
    private Rigidbody2D rb;
    public Nogi[] nogi;

    public float jumpForce = 10f;
    public float rotationSpeed = 100f;

    public float moveInput;
    public bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        nogi = GetComponentsInChildren<Nogi>();
    }

    void Update()
    {    
        //Jumping
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            Jumping();
        }

        //Checking the ground
        if (NogiCheck() == true)
            isGrounded = true;
        else
            isGrounded = false;
    }

    //Checking if any leg is touching the ground
    bool NogiCheck()
    {
        if (nogi[0].isTouchGround == true || nogi[1].isTouchGround == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void FixedUpdate()
    {
        //Getting input
        moveInput = Input.GetAxisRaw("Horizontal");
        float targetTorque = moveInput * -rotationSpeed;

        //checking the change and stopping the rotation
        if (targetTorque * rb.angularVelocity < 0)
        {
            rb.angularVelocity = 0;
            //checking the ground
            if (isGrounded == true)
            {
                rb.linearVelocity = Vector2.zero;
            }
        }

        //applying rotations
        rb.AddTorque(targetTorque * Time.fixedDeltaTime);
    }

    private void Jumping()
    {
        rb.AddRelativeForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
}