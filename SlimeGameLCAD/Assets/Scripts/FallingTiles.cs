using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingTiles : MonoBehaviour
{
    private float fallingDelay = 0.8f;
    private float respawnDelay = 1f;
    private Vector2 initialPosition;
    public Animator anim;
    [SerializeField] private Rigidbody2D rb;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Fall());
            anim.Play("Crumble");
        }
    }

    private IEnumerator Fall()
    {
        yield return new WaitForSeconds(fallingDelay);
        rb.bodyType = RigidbodyType2D.Dynamic;
        yield return new WaitForSeconds(respawnDelay);
        rb.velocity = Vector2.zero;
        rb.bodyType = RigidbodyType2D.Kinematic;
        transform.position = initialPosition;
    }

    private void Start()
    {
        initialPosition = transform.position;
        anim = GetComponent<Animator>();
        anim.Play("Idle");
    }

}
