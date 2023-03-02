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

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        movement = Input.GetAxis("Horizontal");

        //animations
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
    }

    void FixedUpdate()
    {
        

        //Player movement
        myRigidbody.velocity = new Vector2(speed * movement, myRigidbody.velocity.y);

        //anim.SetFloat("speed", Mathf.Abs(myRigidbody.velocity.x));
        //anim.SetFloat("vertical velocity", myRigidbody.velocity.y);

        isGrounded = Physics2D.OverlapCircle(gameObject.transform.position, checkRadius, platformLayerMask);

        //jumping animation
        if (Input.GetAxis("Jump") > 0 && isGrounded)
        {

            anim.Play("jumping");
            myRigidbody.velocity = new Vector2(0, jumpForce);
            Debug.Log("jumping");
            isGrounded = false;
        }

        //second jump- if(input.getaxis("jump") && isGrounded)
        //anim.Play("jumping");
        //myRigidbody.velocity = new Vector2(0, jumpForce);
        //Debug.Log("jumping");
        //isGrounded = false;
        //{ if ( doubleJump == true)
        //{ myRigidbody.velocity = new Vector2(0,jumpForce);
        //double jump = false;
        //}
        //check physics overlap to resset double jump to true

        //TOSCRIPT: once you collect cowboy hat, movement is disabled and slime disappears
        //cowboy hat disappears on contact
    }



    //private void GroundCheck()
    
    //{
    //    RaycastHit2D hit = Physics2D.Raycast(gameObject.transform.position, Vector2.down, .5f, platformLayerMask);

    //    // ray checks for tagged "Ground"
    //    if (hit.collider != null)
    //    {
    //        Debug.Log("collider hit");
    //        if (hit.transform.CompareTag("Ground"))
    //        {
    //            Debug.Log("hit ground");
    //            isGrounded = true;
    //        }
    //    }
    //    else if (hit.collider == null)
    //    {
    //        Debug.Log("not grounded");
    //        isGrounded = false;
    //    }


    //    // Set "IsGrounded" bool in the Animator to match the value of the "isGrounded" bool above
    //    //anim.SetBool("isGrounded", isGrounded);
    //}

    void FLip()
    {
        RIGHTfacing = !RIGHTfacing;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

}

