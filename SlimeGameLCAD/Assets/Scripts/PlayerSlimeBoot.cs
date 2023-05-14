using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSlimeBoot : MonoBehaviour
{
    private Rigidbody2D myRigidbody;
    public Animator anim;

    public bool bootobtained = false;

    public GameObject regularSlime;
    public GameObject boot;
    public float bootLocation;

    public GameObject restartQ;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (bootobtained == true)
        {
            //bootRestart();

            //makes boot child of regularSlime
            boot.transform.parent = regularSlime.transform;

            //recenter boot on Slime 
            boot.transform.localPosition = new Vector3(0, bootLocation, 0);

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Boot"))
        {
            bootobtained = true;
            //Destroy(collision.gameObject);
            Debug.Log("Owwww");
        }

    }
    public void bootRestart()
    {
        //how to play restart animation? for a bit, then restart game?
        anim.Play("restart");
        Debug.Log("Restarting");
        //something to restart slime with boot
    }


}

