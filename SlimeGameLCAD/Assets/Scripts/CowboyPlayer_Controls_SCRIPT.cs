using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CowboyPlayer_Controls_SCRIPT : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public Animator anim;
    public GameObject dialoguePanel;

    public float speed;
    public float jumpForce;
    private float movement;

    //public bool doubleJump;
    public bool jump;
    public int timesJumped;

    public bool isGrounded;

    public LayerMask platformLayerMask;
    private bool RIGHTfacing;
    public float checkRadius;

    public GameObject restartMenu;

    public GameObject regularSlime;
    public GameObject hat;
    public float hatLocation;

    PlayerSlime_Abilities_SCRIPT ability;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        ability = GetComponent<PlayerSlime_Abilities_SCRIPT>();
        myRigidbody = GetComponent<Rigidbody2D>();

        //makes hat child of regularSlime
        hat.transform.parent = regularSlime.transform;

        //recenter hat on Slime 
        hat.transform.localPosition = new Vector3(0, hatLocation, 0);
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
        //lock player movement when speakking
        if (dialoguePanel.activeInHierarchy)
        {
            movement = 0;
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

        //restart button
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            restartMenu.SetActive(true);
        }
        
        //double jump
        if (isGrounded)
        {
            timesJumped = 1;
        }

        if (Input.GetButtonDown("Jump") && timesJumped < 2)
        {
            jump = true;
            timesJumped++;
        }
    }

    void FixedUpdate()
    {
        //Player movement
        myRigidbody.velocity = new Vector2(speed * movement, myRigidbody.velocity.y);

        //double jump movement
        if (jump)
        {
            myRigidbody.velocity = new Vector2(0, jumpForce);
            jump = false;
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
        anim.Play("restart");
        Debug.Log("Restarting");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        restartMenu.SetActive(false);
    }
    public void noRestart()
    {
        Debug.Log("not Restarting");
        restartMenu.SetActive(false);
    }
}
