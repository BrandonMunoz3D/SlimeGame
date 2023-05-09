using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class doublejump : MonoBehaviour
{
    public PlayerSlime_Controls_SCRIPT player;
    public Player_CowboyHat_SCRIPT cowboy;
    public float jumpForce = 5;
    public float groundDistance = 0.5f;
    
    Rigidbody2D rigidBody; 
    public bool jump = false;
    public int jumpNumber = 0;

    void Start()
    { 
        player = GetComponent<PlayerSlime_Controls_SCRIPT>();
        cowboy = GetComponent<Player_CowboyHat_SCRIPT>();
        rigidBody = GetComponent<Rigidbody2D>(); 
    }

    void Update()
    {
        //double jump
        if (player.isGrounded)
        {
            jumpNumber = 1;
        }

        if (Input.GetButtonDown("Jump") && jumpNumber < 2)
        {
            jump = true;
            jumpNumber++;
        }
    }

    void FixedUpdate()
    {

        //Player movement
        player.myRigidbody.velocity = new Vector2(player.speed * player.movement, player.myRigidbody.velocity.y);

        //jumping animation
        if (cowboy.hatobtained && jump)
        {
            Debug.Log("Jump " + jumpNumber);
            player.myRigidbody.velocity = new Vector2(0, jumpForce);
            jump = false;
        }
    }

    /*
    void FixedUpdate()
    {
        if (cowboy.hatobtained && Input.GetAxis("Jump") > 0)
        {
            canDoubleJump = (player.isGrounded) ? true : false; 

            if (!canDoubleJump)
            {
                Debug.Log("Jump1");
                rigidBody.velocity = Vector3.up * jumpForce;
                
            }
            else    
            {
                Debug.Log("Jump2");
                rigidBody.velocity = Vector3.up * jumpForce; 
            }
        }
    }
    */
}
