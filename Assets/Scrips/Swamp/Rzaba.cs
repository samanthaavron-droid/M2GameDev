using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using System;

public class Rzaba : MonoBehaviour
{
    private Rigidbody2D rb;
    private Nogi[] nogi;

    public float jumpForce = 10f;
    public float rotationSpeed = 10f;

    public bool isGrounded;

    [SerializeField] private string[] JumpItems = new string[10]; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        nogi = GetComponentsInChildren<Nogi>();
    }

    void Update()
    { 
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (NogiCheck() == true)
            {
                rb.AddRelativeForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                PrintItems();
            } else
            {
                PrintAllItens();
            }
        }

        if (Input.GetKey(KeyCode.D) || (Input.GetKey(KeyCode.A)))
        {
            transform.Rotate(0, 0, Input.GetAxis("Horizontal") * -rotationSpeed * Time.deltaTime);
        }

        if (NogiCheck() == true)
        {
            isGrounded = true;
        } 
        else
        {
            isGrounded = false;
        }
    }

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

    private void PrintItems()
    {
        int listLength = JumpItems.Length;
        int randomIndex = UnityEngine.Random.Range(0, listLength);

        Debug.Log(JumpItems[randomIndex]);
    }
    private void PrintAllItens()
    {
        foreach (string item in JumpItems)
        {
            Debug.Log(item);
        }
    }
}
