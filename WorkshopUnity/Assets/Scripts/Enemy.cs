using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float hp; //Vida
    public float attack; //Ataque
    public float speed = 3;

    private bool isDead = false;

    private Transform posToFollow;// Posi��o para seguir
    private Rigidbody2D body;
    [SerializeField]private Collider2D col;

    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        posToFollow = GameObject.FindAnyObjectByType<PlayerController>().transform;
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        col = GetComponent<Collider2D>();

        animator.SetBool("dead", false);
        isDead = false;
    }

    private void Update()
    {
        if (!isDead)
        {
            Movement();
        }
    }

    public virtual void Movement()
    {
        Vector2 dir = posToFollow.position - transform.position;
        body.velocity = dir.normalized * speed;

        spriteRenderer.flipX = dir.x  > 0; //Mesma coisa que if(dir.x > 0) spriteRenderer.flipX = true;
    }

    public virtual void TakeDamage(float damage)
    {
        if (!isDead)
        {
            hp -= damage; //hp = hp - damage
            animator.SetTrigger("hit");

            if (hp <= 0)
            {
                animator.SetBool("dead", true);
                col.enabled = false;
                Kill();
            }
        }
    }

    public virtual void Kill()
    {
        isDead = false;
        Destroy(gameObject, .4f);
    }
}
