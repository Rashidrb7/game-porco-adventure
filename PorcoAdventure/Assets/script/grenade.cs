using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grenade : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public Rigidbody2D rb;
    public float damage;
    public GameObject impactEffect;
    // Start is called before the first frame update
    void Start()
    {
        Physics2D.IgnoreLayerCollision(7,8);
        //rb.velocity= transform.right*speed;
        //rb.AddForce(new Vector2(speed,jumpForce));
        
       
        Destroy(gameObject, 2);
        
    }

     private void Update()
    {
       float movementSpeed = speed * Time.deltaTime;
        float jump= jumpForce*Time.deltaTime;
        transform.Translate(movementSpeed, jump, 0);
    }

    void OnTriggerEnter2D (Collider2D collision3)
    {
        //enemy1 enemy = hitInfo.GetComponent<enemy1>();
        if (collision3.tag == "Enemy")
        {
        collision3.GetComponent<HealthEnemy>().TakeDamage(damage);
            //enemy.TakeDamage(damage);
        }

        else if (collision3.tag == "Enemy2")
        {
        collision3.GetComponent<HealthItem>().TakeDamage(damage);
            //enemy.TakeDamage(damage);
        }
        Instantiate(impactEffect,transform.position, transform.rotation);
        Destroy (gameObject);
        
    }

}
