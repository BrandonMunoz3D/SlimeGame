using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player_CowboyHat_SCRIPT : MonoBehaviour
{
    private Rigidbody2D myRigidbody;
    public Animator anim;

    public bool hatobtained = false;

    public GameObject regularSlime;
    public GameObject hat;
    public float hatLocation;

    public TextMeshProUGUI restartQ;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hatobtained == true)
        {
            //hatRestart();

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

            //winning animation
            anim.SetTrigger("won");
            //create a enw question.. restart with hat?
        }

    }
    public void hatRestart()
    {
        //how to play restart animation? for a bit, then restart game?
        anim.Play("restart");
        Debug.Log("Restarting");
        //something to restart slime with hat
    }


}
