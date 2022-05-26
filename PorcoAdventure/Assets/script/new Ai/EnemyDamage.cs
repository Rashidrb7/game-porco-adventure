using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] protected float damage;

     void Start()
    {
        Physics2D.IgnoreLayerCollision(8,7);
        
    }
    protected void OnTriggerEnter2D( Collider2D collision2)
    {
        if (collision2.tag == "Player")
            collision2.GetComponent<Health>().TakeDamage(damage);
    }
}