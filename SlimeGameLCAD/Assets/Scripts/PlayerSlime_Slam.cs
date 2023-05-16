using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSlime_Slam : MonoBehaviour
{
    public PlayerSlime_Controls_SCRIPT player;
    public Player_CowboyHat_SCRIPT cowboy;
    public ItemHover hover;

    public bool bootObtained = false;
    public GameObject regularSlime;
    public float bootLocation;

    public Transform collisionDetector;
    public KeyCode activateKey = KeyCode.Q;
    public float destroyDelay = 2.0f;

    private GameObject collidedObject;
    private GameObject boot;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<PlayerSlime_Controls_SCRIPT>();
        cowboy = GetComponent<Player_CowboyHat_SCRIPT>();
        hover = GetComponent<ItemHover>();
    }

    //On Key Down, Get animatator
    private void Update()
    {
        if (Input.GetKeyDown(activateKey) && bootObtained)
        {
            Debug.Log("Slam Animation Play");
            GetComponent<Animator>().SetTrigger("Slam");
            //perhaps this line below, but needs to exit afterwards.
            ////GetComponent<Animator>().Play("Slam");
            DestroyCollidedObject();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Slam"))
        {
            Debug.Log("Object collided with Slam collider.");
            collidedObject = other.gameObject;
        }
    }
    //Destroy collided object mentioned earlier
    private void DestroyCollidedObject()
    {
        if (collidedObject != null)
        {

            //collidedObject.GetComponent<Collider>().enabled = false;
            Destroy(collidedObject, destroyDelay);
            collidedObject = null;
            Debug.Log("Destroyed collided object.");
        }
    }
    //makes the triggered ability hat a child of the slime. 
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Boot"))
        {
            bootObtained = true;
            //Destroy(collision.gameObject);
            Debug.Log("Owwww");
            Debug.Log("Suddenly... you feel HEAVY");
            Debug.Log("Press Q to break weak spots in the ground");
            if (bootObtained == true)
            {
                //disable hover animation of ability item
                collision.GetComponent<ItemHover>().enabled = false;
                //makes boot child of regularSlime
                collision.transform.parent = regularSlime.transform;
                //recenter on Slime 
                collision.transform.localPosition = new Vector3(0, bootLocation, 0);
                boot = collision.gameObject;
            }

        }
    }
    //nullifies ability when pass through empty obbject
    private void OnTriggerStay2D(Collider2D collider2)
    {
        if (collider2.gameObject.CompareTag("abilityNull"))
        {
            if (bootObtained == true)
            {
                bootObtained = false;
                Debug.Log("The boot you found earlier suddenly flops down");
                Debug.Log("you can no longer break the ground :(");


                boot = transform.GetChild(2).gameObject;
                {
                    Destroy(boot.gameObject);
                }
                //collision.GetComponent<ItemHover>().enabled = true;
            }

        }
    }
}
