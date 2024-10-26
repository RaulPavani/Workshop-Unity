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
    [SerializeField]private Animator anim;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        GetInput();
    }

    void GetInput()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");

        anim.SetFloat("x", input.x);
        anim.SetFloat("y", input.y);
        //anim.SetBool("walking", input.x != 0 || input.y != 0)
        if (input.x != 0 || input.y != 0)
        {
            anim.SetBool("walking", true);
        }
        else
        {
            anim.SetBool("walking", false);
        }

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

    public float life = 5;
    //private void OnTriggerEnter2D(Collider2D collision)
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            life--; //life = life - 1

            if(life <= 0)
            {
                //TODO: Animação morrendo
                Destroy(gameObject);
                GameManager.instance.GameOver();
            }
        }
    }
}
