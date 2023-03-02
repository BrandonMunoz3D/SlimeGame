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

    private bool isGrounded;
   
    public LayerMask platformLayerMask;
    private bool RIGHTfacing;

    private int extraJumps;
    public int extraJumpsValue;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
        extraJumps = extraJumpsValue;
    }
    // Update is called once per frame
    void Update()
    {
        movement = Input.GetAxis("Horizontal");

        //Player movement
        myRigidbody.velocity = new Vector2(speed * movement, myRigidbody.velocity.y);

        anim.SetFloat("speed", Mathf.Abs(myRigidbody.velocity.x));
        anim.SetFloat("vertical velocity", myRigidbody.velocity.y);

        if (movement == 0)
        {
            anim.Play("idle");
        }
        else
        {
            anim.Play("running");
        }
        //facing directions
        if (RIGHTfacing == false && movement < 0)
        {
            FLip();
        }
        else if (RIGHTfacing == true && movement > 0)
        {
            FLip();
        }

        //jumping animation
        if (Input.GetAxis("Jump") > 0 && isGrounded)
        {
            anim.Play("jumping");
            myRigidbody.velocity = new Vector2(0, jumpForce);
            Debug.Log("jumping");
        }


    }

    private void FixedUpdate()
    {
        GroundCheck();
    }



    private void GroundCheck()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, .1f, platformLayerMask);

        // ray checks for tagged "Ground"
        if (hit.collider != null)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        // Set "IsGrounded" bool in the Animator to match the value of the "isGrounded" bool above
        anim.SetBool("isGrounded", isGrounded);
    }

    void FLip()
    {
        RIGHTfacing = !RIGHTfacing;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

}

