using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class thrown : MonoBehaviour
{
   public Transform firePoint;
   public GameObject BulletPrefab;
   public int grenadecount;
   Text grenadeinfo;
   [SerializeField] private AudioSource throwneffect;
   [SerializeField] private AudioSource grenadecollecteffect;


   void Start()
    {  grenadeinfo = GameObject.Find ("UIgrenadetext1").GetComponent<Text>();
      
        
    }

    void Update()
    {
      grenadeinfo.text = grenadecount.ToString();
      
    }

    public void pressthrow()
    {
       if (grenadecount>0)
       {
        shoot ();
        grenadecount--;
       }
        
    }

    void shoot ()
    {
        Instantiate(BulletPrefab, firePoint.position, firePoint.rotation);
        throwneffect.Play();

    }

    public void sound()
    {
      grenadecollecteffect.Play();
    }
}
