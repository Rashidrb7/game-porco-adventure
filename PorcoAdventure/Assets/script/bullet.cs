using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public float damage;
    public GameObject impactEffect;
    // Start is called before the first frame update
    void Start()
    {
        Physics2D.IgnoreLayerCollision(7,8);
        rb.velocity= transform.right*speed;
        Destroy(gameObject, 1);
        
    }

    void OnTriggerEnter2D (Collider2D collision)
    {
        //enemy1 enemy = hitInfo.GetComponent<enemy1>();
        if (collision.tag == "Enemy")
        {
            collision.GetComponent<HealthEnemy>().TakeDamage(damage);
            //enemy.TakeDamage(damage);
        }

        else if  (collision.tag == "Enemy2")
        {
            collision.GetComponent<HealthItem>().TakeDamage(damage);
            //enemy.TakeDamage(damage);
        }
        Instantiate(impactEffect,transform.position, transform.rotation);
        Destroy (gameObject);
        
    }

}
