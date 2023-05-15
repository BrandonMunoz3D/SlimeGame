using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : MonoBehaviour
{
    [Header ("Attack Parameters")]
    [SerializeField] private float attackCooldown;
    [SerializeField] private int range;
    [SerializeField] private float colliderDistance;

    [Header("Collider Parameters")]
    [SerializeField] private int damageAmount;
    [SerializeField] private BoxCollider2D boxCollider;

    [Header("Player Layer")]
    [SerializeField] private LayerMask playerLayer;
    private float cooldownTimer = Mathf.Infinity;

    [Header("Frozen Parameters")]
    [SerializeField] public SpriteRenderer rend;
    public bool isFrozen;

    //References
    PlayerHealth healthCurrent;
    private Animator anim;

    public EnemyPatrol enemyPatrol;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        enemyPatrol = GetComponentInParent<EnemyPatrol>();
    }
    private void Update()
    {
        cooldownTimer += Time.deltaTime;

        //Attack only when player in sight
        if (PlayerInSight())
        {
            if (cooldownTimer >= attackCooldown)
            {
                cooldownTimer = 0;
                anim.SetTrigger("meleeAttack");
            }
        }

        if (enemyPatrol != null)
            enemyPatrol.enabled = !PlayerInSight();

        if (isFrozen == true)
        {
            Invoke("Unfrozen", 5.0f);
        }
    }

    private bool PlayerInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
          new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z),  
          0, Vector2.left,0, playerLayer);

        if (hit.collider != null)
            healthCurrent = hit.transform.GetComponent<PlayerHealth>();
        return hit.collider != null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Projectile")
        {
            Frozen();
        }
    }

    private void DamagePlayer()
    {
        //If player still in range damage him
        if (PlayerInSight())
            healthCurrent.TakeDamage(damageAmount);
        
    }
    public void Frozen()
    {
        isFrozen = true;

        Debug.Log("Change color to cyan");
        rend.color = Color.cyan;

        Debug.Log("Dissable damage for that enemy");
        damageAmount = 0;

        Debug.Log("Stop Moving");
        GetComponentInParent<EnemyPatrol>().speed = 0;

    }

    public void Unfrozen()
    {
        isFrozen = false;

        Debug.Log("Unfrozen");
        //Return to normal color
        rend.color = Color.white;

        Debug.Log("Return damage");
        damageAmount = 2;

        Debug.Log("Resume moving");
        GetComponentInParent<EnemyPatrol>().speed = 1;
    }
}