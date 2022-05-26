using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy1 : MonoBehaviour
{ public int health;
  
   public void TakeDamage (int damage)
   {
       health -= damage;

       if (health <= 0)
       {
           Die ();
       }
   }

   void Die ()
   {
       Destroy(gameObject);
   }
}
