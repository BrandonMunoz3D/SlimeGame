using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFreeze : MonoBehaviour
{
    public Color newColor;
    public SpriteRenderer rend;
    [Header ("Place Enemy Here, Here, and Here")]
    [SerializeField] public Rigidbody2D enemy;
    [SerializeField] private Animator anim;
    [SerializeField] private BoxCollider2D attackRange;

    [Header ("How Long The Enemy Will Be Frozen For")]
    [SerializeField] private float freezeTimer;
    private bool frozen;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        attackRange = GetComponent<BoxCollider2D>();
    }
    public void Frozen()
    {
        //Change color to cyan
        rend = GetComponent<SpriteRenderer>();
        rend.color = Color.cyan;

        //Stop enemy patrol
        enemy.velocity = Vector3.zero;
        freezeTimer = 5;

        //Dissable attack box so it cant attack.
        attackRange.enabled = false;

        //Set animation to idle
        anim.SetBool("moving", false);
    }

    private void ResetTimer()
    {
      
    }
}
