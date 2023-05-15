using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stalagmite_Script : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rigidBody;

    [SerializeField] private float speed;
    private float direction;

    [Header("Collider Parameters")]
    [SerializeField] private int damageAmount;
    [SerializeField] private BoxCollider2D boxCollider;

    [Header("Player Layer")]
    [SerializeField] private LayerMask playerLayer;

    public bool hit;

    PlayerHealth healthCurrent;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hit) return;
        float movementspeed = speed * Time.deltaTime * direction;
        transform.Translate(movementspeed, 0, 0);

        InvokeRepeating("DropStalagmite", 5.0f, 5.0f);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        hit = true;
        boxCollider.enabled = false;
        rigidBody.isKinematic = true;
        anim.SetTrigger("explode");
        if (collision.tag == "Player")
        {
            GetComponent<PlayerHealth>().TakeDamage(damageAmount);
        }
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }

}
