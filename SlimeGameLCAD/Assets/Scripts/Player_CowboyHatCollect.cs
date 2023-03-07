using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_CowboyHatCollect : MonoBehaviour
{
    private Rigidbody2D myRigidbody;
    private BoxCollider2D collider;

    public bool hatobtained = false;

    public GameObject regularSlime;
    public GameObject hat;
    public float hatLocation;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        collider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hatobtained == true)
        {
            //makes hat child of regularSlime
            hat.transform.parent = regularSlime.transform;
            
            //recenter hat on Slime 
            hat.transform.localPosition = new Vector3 (0,hatLocation,0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("CowboyHat"))
        {
            hatobtained = true;
            //Destroy(collision.gameObject);
            Debug.Log("YEEEEHAW");
        }

    }


}
