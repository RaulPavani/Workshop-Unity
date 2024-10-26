using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float timeToDestroy = 5f;
    public GameObject hitVfx;

    void Start()
    {
        //Invoke("Kill", timeToDestroy);
        //StartCoroutine(KillAfterTime());
        Destroy(gameObject, timeToDestroy);
    }

    IEnumerator KillAfterTime()
    {
        yield return new WaitForSeconds(timeToDestroy);
        Destroy(gameObject);
    }

    void Kill()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    { 
        if (collision.CompareTag("Enemy"))
        {
            Enemy enemy = collision.GetComponent<Enemy>();  

            if (enemy != null)
            {
                enemy.TakeDamage(1);
                Instantiate(hitVfx, collision.ClosestPoint(transform.position), Quaternion.identity);
                Destroy(gameObject);
            }
        }

        else if (collision.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
}
