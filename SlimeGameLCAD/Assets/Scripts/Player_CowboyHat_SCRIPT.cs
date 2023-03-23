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
    public GameObject restartMenu;

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

            Invoke("winning", 1);

            Invoke("winningRestart", 2.5f);
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

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        hat.transform.parent = regularSlime.transform;
        hat.transform.localPosition = new Vector3(0, hatLocation, 0);
        //something to restart slime with hat
    }

    public void winning()
    {
        anim.Play("win");
    }

    public void winningRestart()
    {
        restartMenu.SetActive(true);
        restartQ.text = "Restart with Hat?";
    }

    public void Restart()
    {
        //how to play restart animation?
        anim.Play("restart");
        Debug.Log("Restarting");

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        restartMenu.SetActive(false);
        //makes hat child of regularSlime
        hat.transform.parent = regularSlime.transform;

        //recenter hat on Slime 
        hat.transform.localPosition = new Vector3(0, hatLocation, 0);
    }
    public void noRestart()
    {
        Debug.Log("not Restarting");
        restartMenu.SetActive(false);
    }
}
