using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{
   public Transform firePoint;
   public GameObject BulletPrefab;
   [SerializeField] private AudioSource shooteffect;

    public void pressshoot()
    {
        
        shoot ();
        
        
    }

    void shoot ()
    {
        Instantiate(BulletPrefab, firePoint.position, firePoint.rotation);
        shooteffect.Play();
        

    }

 

}
