using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credit : MonoBehaviour
{
   public GameObject CreditUI;
   public GameObject ExitUI;
   public void CreditActive ()
    {  
        CreditUI.SetActive(true);
       
    }

    public void CreditDeactive ()
    {  
        CreditUI.SetActive(false);
       
    }

    public void ExitActive ()
    {  
        ExitUI.SetActive(true);
       
    }

    public void ExitDeactive ()
    {  
        ExitUI.SetActive(false);
       
    }

     public void ExitGame ()
    {  
        Application.Quit();
        Debug.Log ("QUIT");
    }
}
