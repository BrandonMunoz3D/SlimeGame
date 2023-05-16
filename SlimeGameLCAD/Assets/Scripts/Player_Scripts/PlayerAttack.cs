using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Rigidbody2D myRigidbody;
    public Animator anim;
    public ItemHover hover;

    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] iceballs;

    private float cooldownTimer = Mathf.Infinity;

    public bool hairObtained = false;
    public GameObject regularSlime;
    public float hairLocation;
    public float horizontal;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
        hover = GetComponent<ItemHover>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && hairObtained && cooldownTimer > attackCooldown)
            Attack();

        cooldownTimer += Time.deltaTime;
    }

    private void Attack()
    {
        anim.SetTrigger("attack");
        cooldownTimer = 0;

        iceballs[0].transform.position = firePoint.position;
        iceballs[0].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));

    }
    private int FindIceball()
    {
        for (int i = 0; i < iceballs.Length; i++)
        {
            if (!iceballs[i].activeInHierarchy)
                return i;
        }
        return 0;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Elsahair"))
        {
            hairObtained = true;
            Debug.Log("BRRR. you feel a chill emanating from your core");
            Debug.Log("Click with your mouse to launch ice from your little slime body!");

            if (hairObtained == true)
            {
                collision.GetComponent<ItemHover>().enabled = false;
                //makes boot child of regularSlime
                collision.transform.parent = regularSlime.transform;
                //recenter on Slime 
                collision.transform.localPosition = new Vector3(horizontal, hairLocation, 0);
            }
        }
        if (collision.gameObject.CompareTag("Ice Crown"))
        {
            Debug.Log("Brrr....");
            Debug.Log("It's chilly.....");
            Debug.Log("but, the cold never bothered you anyway");
        }
    }
    private void OnTriggerExit2D(Collider2D collider2)
    {
        if (collider2.gameObject.CompareTag("abilityNull"))
        {
            if (hairObtained == true)
            {
                hairObtained = false;
                Debug.Log("Your hair catches a gust of wind and flies away~");
                Debug.Log("You let it go");
                Debug.Log("you can not shoot ice :(");

                foreach (Transform child in regularSlime.transform)
                {
                    Destroy(child.gameObject);
                }
                //collision.GetComponent<ItemHover>().enabled = true;
            }

        }
    }
}
