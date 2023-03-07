using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerSlime_Controls_SCRIPT : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public Animator anim;

    public float speed;
    public float jumpForce;
    private float movement;

    public bool isGrounded;
 
    public LayerMask platformLayerMask;
    private bool RIGHTfacing;
    public float checkRadius;

    PlayerSlime_Abilities_SCRIPT ability;

    // Start is called before the first frame update
    void Start()
    { 
        anim = GetComponent<Animator>();
        ability = GetComponent<PlayerSlime_Abilities_SCRIPT>();
        myRigidbody = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        movement = Input.GetAxis("Horizontal");

        //Facing directions
        if (RIGHTfacing == false && movement < 0)
        {
            FLip();
        }
        else if (RIGHTfacing == true && movement > 0)
        {
            FLip();
        }

        //Set grounded
        isGrounded = Physics2D.OverlapCircle(gameObject.transform.position, checkRadius, platformLayerMask);
        anim.SetBool("isGrounded", isGrounded);

        //Set speed
        anim.SetFloat("speed", Mathf.Abs(myRigidbody.velocity.x));

        //Double Jump Ability
        /*
         if (ability.CurrentAbility == PlayerSlime_Abilities_SCRIPT.SlimeAbility.DoubleJump) {
            // TODO DOUBLE JUMP LOGIC
        }

        //Freeze Ability
        if (ability.CurrentAbility == PlayerSlime_Abilities_SCRIPT.SlimeAbility.Freeze) {
            // TODO FREEZE LOGIC
        }

        //Stomp Ability
        if (ability.CurrentAbility == PlayerSlime_Abilities_SCRIPT.SlimeAbility.Stomp) {
            // TODO STOMP LOGIC
        } */
    }

    void FixedUpdate()
    {
        //Player movement
        myRigidbody.velocity = new Vector2(speed * movement, myRigidbody.velocity.y);

        //jumping animation
        if (Input.GetAxis("Jump") > 0 && isGrounded) {
            myRigidbody.velocity = new Vector2(0, jumpForce);
        }
    }

    void FLip()
    {
        RIGHTfacing = !RIGHTfacing;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

}

