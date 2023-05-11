using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFreeze : MonoBehaviour
{
    [Header("Place Enemy Here and Here")]
    [SerializeField] public SpriteRenderer rend;
    [SerializeField] private Animator anim;

    EnemyDamage enemyDamage;
    GameObject EnemyPatrol;

    public bool isFrozen;

    private void Awake()
    {
        enemyDamage = GetComponent<EnemyDamage>();
        anim = GetComponent<Animator>();
        
        isFrozen = false;
    }
    public void Frozen()
    {
        //Change color to cyan
        rend = GetComponent<SpriteRenderer>();
        rend.color = Color.cyan;

        //Stop moving
        GetComponentInParent<EnemyPatrol>().speed = 0;

        //Dissable damage for that enemy
        GetComponentInParent<EnemyDamage>().damageAmount = 0;

        //Set animation to idle
        GetComponentInParent<EnemyPatrol>().anim.SetBool("moving", false);

        isFrozen = true;
    }

    public void Unfrozen()
    {
        //Return to normal color
        rend = GetComponent<SpriteRenderer>();
        rend.color = Color.white;

        //Continue moving
        GetComponentInParent<EnemyPatrol>().speed = 5;

        //Make damage go back up
        GetComponentInParent<EnemyDamage>().damageAmount = 2;

        //Set animation back to noral
        GetComponentInParent<EnemyPatrol>().anim.SetBool("moving", true);

        isFrozen = false;
    }

    //Instead of using a timer method I am using Invoke on the projectile script :-) vvv
    
    //if (GetComponent<EnemyFreeze>().enabled = true && collision.tag == "Enemy")
        //Invoke("Frozen", 1);

        //if (GetComponent<EnemyFreeze>().isFrozen == true)
            //Invoke("Unfrozen", 5);
}
