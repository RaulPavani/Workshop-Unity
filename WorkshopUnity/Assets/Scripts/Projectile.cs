using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float timeToDestroy = 5f;

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
                Destroy(gameObject);
            }
        }

        else if (collision.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
}
