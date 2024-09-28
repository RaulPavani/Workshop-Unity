using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float hp; //Vida
    public float attack; //Ataque
    public float speed = 3;

    private Transform posToFollow;// Posição para seguir
    private Rigidbody2D body;

    private void Start()
    {
        posToFollow = GameObject.FindAnyObjectByType<PlayerController>().transform;
        body = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Movement();
    }

    public virtual void Movement()
    {
        Vector2 dir = posToFollow.position - transform.position;
        body.velocity = dir.normalized * speed;
    }

    public virtual void TakeDamage(float damage)
    {
        hp -= damage; //hp = hp - damage

        if(hp <= 0)
        {
            Kill();
        }
    }

    public virtual void Kill()
    {
        Destroy(gameObject);
    }
}
