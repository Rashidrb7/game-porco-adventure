using UnityEngine;

public class healthcollectible2 : MonoBehaviour
{
    [SerializeField] private float healthValue;
    Health collecthealth;

    void Start()
    {
        collecthealth = GameObject.Find("player").GetComponent<Health>();
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "collider")
        {
            collecthealth.AddHealth(healthValue);
            gameObject.SetActive(false);
        }
    }
}
