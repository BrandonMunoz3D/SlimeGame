using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class DoubleJump : MonoBehaviour
{
    public float jumpForce = 5;
    public float groundDistance = 0.5f;

    Rigidbody2D rigidBody;
    bool canDoubleJump;

    void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, groundDistance);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (IsGrounded())
            {
                rigidBody.velocity = Vector3.up * jumpForce;
                canDoubleJump = true;
            }
            else if (canDoubleJump)
            {
                rigidBody.velocity = Vector3.up * jumpForce;
                canDoubleJump = false;
            }
        }
    }
}