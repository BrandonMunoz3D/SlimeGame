using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] public int damageAmount;

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        //if enemy hits player then get the player health script and do the damage
        if (collision.tag == "Player")
            collision.GetComponent<PlayerHealth>().TakeDamage(damageAmount);
    }
}
