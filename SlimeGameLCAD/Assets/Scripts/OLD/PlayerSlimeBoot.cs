using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSlimeBoot : MonoBehaviour
{
    private Rigidbody2D myRigidbody;
    public Animator anim;
    public ItemHover hover;

    public bool bootobtained = false;


    public GameObject regularSlime;
    public float bootLocation;

    //public GameObject boot;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
        hover = GetComponent<ItemHover>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if (bootobtained == true)
        {
            //bootRestart();

            //makes boot child of regularSlime
            boot.transform.parent = regularSlime.transform;

            //recenter boot on Slime 
            boot.transform.localPosition = new Vector3(0, bootLocation, 0);

        }*/
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        /*if (collision.gameObject.CompareTag("Boot"))
        {
            bootobtained = true;
            //Destroy(collision.gameObject);
            Debug.Log("Owwww");
            Debug.Log("Suddenly... you feel HEAVY");
            Debug.Log("Press Q to break weak spots in the ground");
            collision.GetComponent<ItemHover>().enabled = false;
           
            //makes boot child of regularSlime
            collision.transform.parent = regularSlime.transform;
            //recenter on Slime 
            collision.transform.localPosition = new Vector3(0, bootLocation, 0);
        }
        
        if (collision.gameObject.CompareTag("Elsahair"))
        {
            freezeobtained = true;
            Debug.Log("BRRR. you feel a chill emanating from your core");
            Debug.Log("Click with your mouse to launch ice from your little slime body!");
        }
        if (collision.gameObject.CompareTag("Ice Crown"))
        {
            Debug.Log("Brrr....");
            Debug.Log("It's chilly.....");
            Debug.Log("but, the cold never bothered you anyway");
        }*/
    }


}

