using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector2 input;
    private Vector2 mousePos;

    public float speed = 5;
    public GameObject projectile;
    public Rigidbody2D body;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        GetInput();
    }

    void GetInput()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");

        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject newProjectile = Instantiate(projectile, transform.position, Quaternion.identity);
        Vector2 mouseDir = (mousePos - (Vector2)transform.position).normalized;
        newProjectile.GetComponent<Rigidbody2D>().velocity = mouseDir * 10;

    }

    void FixedUpdate()
    {
        body.velocity = input.normalized * speed;
    }
}
