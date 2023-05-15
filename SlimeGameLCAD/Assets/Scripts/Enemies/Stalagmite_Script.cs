using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stalagmite_Script : MonoBehaviour
{
    [SerializeField] private GameObject stalagmite;
    [SerializeField] private Transform stalagmiteSpawnPosition;

    private Animator anim;
    private Rigidbody2D rigidBody;

    [SerializeField] private int range;
    [SerializeField] private float colliderDistance;

    [Header("Collider Parameters")]
    [SerializeField] private int damageAmount;
    [SerializeField] private BoxCollider2D boxCollider;

    [Header("Player Layer")]
    [SerializeField] private LayerMask playerLayer;

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
        InvokeRepeating("Shoot", 5.0f, 5.0f);
    }
    private bool PlayerInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
          new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
          0, Vector2.left, 0, playerLayer);

        if (hit.collider != null)
            healthCurrent = hit.transform.GetComponent<PlayerHealth>();
        return hit.collider != null;
    }
    void Shoot()
    {
        Instantiate(stalagmite, stalagmiteSpawnPosition.transform);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.y * colliderDistance,
            new Vector3(boxCollider.bounds.size.y * range, boxCollider.bounds.size.x));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        boxCollider.enabled = false;
        rigidBody.isKinematic = true;
        anim.SetTrigger("explode");
        Destroy(stalagmite, 2);
    }

}
