using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_CowboyHatCollect : MonoBehaviour
{
    private Rigidbody2D myRigidbody;


    public int hat;
    private bool hatobtained;

    public GameObject regularSlime;
    public GameObject cowboySlime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if other slime collects hat, disappears, 
        //cowboy slime movement enabled, cowboy slime appears

        //item disappears on contact
        //void has hat(has hat screen yay, scene change, player has hat)

    }

    void hasHat()
    {
        if(hatobtained == true)
        {
            regularSlime.GetComponent<PlayerSlime_Controls_SCRIPT>().enabled = false;
            cowboySlime.GetComponent<PlayerSlime_Controls_SCRIPT>().enabled = true;
            Destroy(regularSlime.gameObject);
        }
        
        //slime disappear, movement disabled
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("CowboyHat"))
        { 
            hatobtained = true;
            Destroy(collision.gameObject);
            Debug.Log("HAT OBTAINED!!!");

            
        }
        
    }
   
}
