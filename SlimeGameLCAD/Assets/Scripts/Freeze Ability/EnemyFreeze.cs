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
        rend = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        isFrozen = true;
        //Frozen();
        //Debug.Log("freezing");
    }
    public void Frozen()
    {
        Debug.Log("blue");
        //Change color to cyan
        rend.color = Color.cyan;

        //Set animation to idle
        GetComponentInParent<EnemyPatrol>().anim.SetBool("moving", false);

        //Stop moving
        GetComponentInParent<MeleeEnemy>().enemyPatrol.enabled = false;

        //Dissable damage for that enemy
        GetComponentInParent<EnemyDamage>().damageAmount = 0;


        isFrozen = true;

        Invoke("Unfrozen", 5);
    }

    public void Unfrozen()
    {
        //Return to normal color
        rend.color = Color.white;

        //Continue moving
        GetComponentInParent<EnemyPatrol>().speed = 5;

        //Make damage go back up
        GetComponentInParent<EnemyDamage>().damageAmount = 2;

        //Set animation back to noral
        GetComponentInParent<EnemyPatrol>().anim.SetBool("moving", true);

        isFrozen = false;
    }


}
