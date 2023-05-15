using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class doublejump : MonoBehaviour
{
    public PlayerSlime_Controls_SCRIPT player;
    public Player_CowboyHat_SCRIPT cowboy;
    public ItemHover hover;
    public float jumpForce = 5;
    public float groundDistance = 0.5f;

    Rigidbody2D rigidBody;
    public Animator anim;

    public bool jump = false;
    public int jumpNumber = 0;

    public GameObject regularSlime;
    public bool wingObtained;
    public float wingLocation;

    void Start()
    {
        player = GetComponent<PlayerSlime_Controls_SCRIPT>();
        cowboy = GetComponent<Player_CowboyHat_SCRIPT>();
        hover = GetComponent<ItemHover>();

        anim = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //double jump
        if (player.isGrounded)
        {
            jumpNumber = 0;
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
        if (cowboy.hatobtained && jump || wingObtained && jump)
        {
            Debug.Log("Jump " + jumpNumber);
            player.myRigidbody.velocity = new Vector2(0, jumpForce);
            jump = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wings"))
        {
            wingObtained = true;
            Debug.Log("Wow! You feel yourself getting lighter and lighter as the wind picks up");
            Debug.Log("Press space while in the air to double jump!");
            if (wingObtained == true)
            {
                collision.GetComponent<ItemHover>().enabled = false;
                collision.transform.parent = regularSlime.transform;
                collision.transform.localPosition = new Vector3(0, wingLocation, 0);
            }

        }


    }
    private void OnTriggerExit2D(Collider2D other)

    {
        if (other.gameObject.CompareTag("abilityNull"))
        {
            if(wingObtained == true)
            {
                wingObtained = false;
                Debug.Log("you feel heavier as the wind dies down ");
                Debug.Log("you can no longer double jump :(");

                foreach (Transform child in regularSlime.transform)
                {
                    Destroy(child.gameObject);
                }
                //collision.GetComponent<ItemHover>().enabled = true;
            }

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