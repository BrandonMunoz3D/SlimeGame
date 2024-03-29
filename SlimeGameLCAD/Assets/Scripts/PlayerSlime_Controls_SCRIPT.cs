using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerSlime_Controls_SCRIPT : MonoBehaviour
{
    public Player_CowboyHat_SCRIPT cowboy;
    public doublejump doublejump;
    public Rigidbody2D myRigidbody;
    public Animator anim;
    public GameObject dialoguePanel;

    public float speed;
    public float jumpForce;
    public float movement;

    //public bool doubleJump;
    public bool jump; 
    public int timesJumped;

    public bool isGrounded;
 
    public LayerMask platformLayerMask;
    private bool RIGHTfacing;
    public float checkRadius;

    public GameObject restartMenu;

    public static Vector2 lastCheckPointPos;


    // Start is called before the first frame update
    void Start()
    { 
        anim = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
        cowboy = GetComponent<Player_CowboyHat_SCRIPT>();
        doublejump = GetComponent<doublejump>();
        Debug.Log("WASD to move");
        Debug.Log("SPACE to jump");
        Debug.Log("E to speak");
        Debug.Log("ESC to restart");
        Debug.Log("M to hide console");
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
        //lock player movement when speaking
        if (dialoguePanel.activeInHierarchy)
        {
            movement = 0;
        }

        //Set grounded
        isGrounded = Physics2D.OverlapCircle(gameObject.transform.position, checkRadius, platformLayerMask);
        anim.SetBool("isGrounded", isGrounded);

        //Set speed
        anim.SetFloat("speed", Mathf.Abs(myRigidbody.velocity.x));

        //restart button
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            restartMenu.SetActive(true);
        }

    }

    void FixedUpdate()
    {
        //Player movement
        myRigidbody.velocity = new Vector2(speed * movement, myRigidbody.velocity.y);

        //jumping animation
        if (!cowboy.hatobtained && !doublejump.wingObtained && Input.GetAxis("Jump") > 0 && isGrounded)
        {
            myRigidbody.velocity = new Vector2(0, jumpForce);
        }
    }

    void FLip()
    {
        RIGHTfacing = !RIGHTfacing;

        //rotates player on y-axis
        transform.Rotate(0f, 180f, 0f);
    }

    //presss Yes/No in restart menu activates these
    public void Restart()
    {
        //how to play restart animation?
        //anim.Play("restart");
        Debug.Log("Restarting");
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        transform.position = lastCheckPointPos;
        restartMenu.SetActive(false);
    }
    public void noRestart()
    {
        Debug.Log("not Restarting");
        restartMenu.SetActive(false);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Death")
        {
            Debug.Log("YOU DIED");
            Restart();
        }
    }

}

