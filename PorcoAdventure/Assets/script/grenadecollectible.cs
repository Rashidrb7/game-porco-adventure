using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grenadecollectible: MonoBehaviour
{
    thrown grenadethrow;
    // Start is called before the first frame update
    void Start()
    {
        grenadethrow = GameObject.Find("player").GetComponent<thrown>();
        
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    
    void OnTriggerEnter2D (Collider2D other) 
    {
        if (other.transform.tag == "collider") 
        {
            grenadethrow.grenadecount+=3;
            grenadethrow.sound();
            Destroy(gameObject);
        }
    }
}