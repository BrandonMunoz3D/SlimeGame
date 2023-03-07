using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_CowboyHatCollect : MonoBehaviour
{
    private Rigidbody2D myRigidbody;
    private BoxCollider2D collider;

    public int hat;
    public bool hatobtained;

    public GameObject regularSlime;
    public GameObject cowboySlime;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        collider = GetComponent<BoxCollider2D>();


        //disabling the cowboy from the start.
        regularSlime.GetComponent<PlayerSlime_Controls_SCRIPT>().enabled = true;
        cowboySlime.GetComponent<PlayerSlime_Controls_SCRIPT>().enabled = false;
        cowboySlime.GetComponent<BoxCollider2D>().enabled = false;
        cowboySlime.gameObject.SetActive(false);
        //disable rigidbody somehow
    }

    // Update is called once per frame
    void Update()
    {
        //if regslime collects hat, slime disappears, hat disappears...
        // reg slime movement disabled, collision disabled
        //cowboy slime movement enabled, cowboy slime appears
        if (hatobtained == true)
        {
            regularSlime.GetComponent<PlayerSlime_Controls_SCRIPT>().enabled = false;
            regularSlime.GetComponent<BoxCollider2D>().enabled = false;
            cowboySlime.GetComponent<PlayerSlime_Controls_SCRIPT>().enabled = true;
            cowboySlime.GetComponent<BoxCollider2D>().enabled = true;

            //enable cowboy slime rigidbody
            regularSlime.gameObject.SetActive(false);
            cowboySlime.SetActive(true);
            regularSlime.gameObject.SetActive(false);
            cowboySlime.gameObject.SetActive(true);
        }
        //item disappears on contact
        //void has hat(has hat screen yay, scene change, player has hat)

    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("CowboyHat"))
        { 
            hatobtained = true;
            Destroy(collision.gameObject);
            Debug.Log("YEEEEHAW");
            
        }
        
    }
    void DisappearSlime()
    {
        regularSlime.SetActive(false);
    }


}
