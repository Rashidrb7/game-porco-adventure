using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class menu : MonoBehaviour
{
    [SerializeField] private AudioSource click;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void totarget (int target)
    {
        Application.LoadLevel (target);
        //adshower.instance.ShowFullScreen();
    }

    public void soundclick ()
    {
        click.Play();
    }
}