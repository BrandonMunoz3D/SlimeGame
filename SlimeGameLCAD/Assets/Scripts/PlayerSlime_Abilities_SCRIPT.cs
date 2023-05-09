using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSlime_Abilities_SCRIPT : MonoBehaviour
{
    public bool DoubleJump;

    // Use this for initialization
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        
            if (DoubleJump)
            {
                GameObject.FindWithTag("Player").GetComponent<DoubleJump>().enabled = true;
                Destroy(gameObject);

            }
        }
    }