using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character : MonoBehaviour
{
//var character movement
    public int speed, jumpForce;
    Rigidbody2D jump;

//var flipface
    public bool flip;
    public int move;
// var ground detector
    public bool ground;
    public LayerMask targetlayer;
    public Transform groundetected;
    public float range;
// var abimation
    Animator anim;
// var doublejump
    private int extrajump;
    public int extrajumpValue;
// button
   public bool LeftButton;
   public bool RightButton;
   //Vector2 move;
 //  public bool JumpButton;
   [SerializeField] private AudioSource jumpeffect;
   

  Vector2 Respawnpoint;

   public GameObject DeadMenuUI;

  // revive components
  [SerializeField] private Behaviour[] components2;
  [SerializeField] private float healthValue2;

  //checkpoint
  public int checkpointcount;
  [SerializeField] private AudioSource checkpoint;

  //finish
  public GameObject finishmenu;
  [SerializeField] private AudioSource finishmusic;
  [SerializeField] private AudioSource bgmusic2;
  [SerializeField] private AudioSource applause;

    // Start is called before the first frame update
    void Start()
    {
        jump =GetComponent<Rigidbody2D> ();
        anim = GetComponent<Animator> ();
        extrajump = extrajumpValue;
        Respawnpoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    { 
// ground detection
      if (ground==true)
      {
         anim.SetBool("jump",false);
         anim.SetBool("doubleJump",false);
          extrajump =extrajumpValue ;
      }
      else
      {
         anim.SetBool("jump",true);
      }
        ground = Physics2D.OverlapCircle (groundetected.position, range, targetlayer);
// condition character movement
       if (Input.GetKey (KeyCode.D) || (RightButton==true))
        { 
          move=1;
          //transform.Translate (Vector2.right * speed*move * Time.deltaTime);
          jump.velocity = new Vector2 (move*speed, jump.velocity.y);
          //jump.AddForce(move*speed*Time.deltaTime);
          //jump.AddForce(new Vector2(speed*move,0));
          
          anim.SetBool("walk",true);
        }
         else if (Input.GetKey (KeyCode.A) || (LeftButton==true))
        {
          move=-1;
          //transform.Translate (Vector2.left *speed*move * Time.deltaTime);
          jump.velocity = new Vector2 (move*speed, jump.velocity.y);
          //jump.AddForce(move*speed*Time.deltaTime);
          //jump.AddForce(new Vector2(speed*move,0));
          
          anim.SetBool("walk",true);
        }
        else 
        {
          anim.SetBool("walk",false);
        }

      //else 
      //{
      //    anim.SetBool("walk",false);
      //}

      //if (ground==true && (Input.GetKey (KeyCode.Mouse1)))
     // {
      //    jump.AddForce(new Vector2(0,jumpForce));
      //    extrajump =1;
     // }
// condition jump & extra jump
      //if ((Input.GetKeyDown (KeyCode.Mouse1) || (JumpButton==true)) && extrajump > 0)
     // {
     //     jump.velocity = Vector2.up * jumpForce;
     //     anim.SetBool("doubleJump",true);
     //     extrajump--;
          
      //}

      //else if ((Input.GetKeyDown (KeyCode.Mouse1)|| (JumpButton==true)) && extrajump == 0 && ground==true)
      //{
      //    jump.velocity = Vector2.up * jumpForce;
      //     anim.SetBool("doubleJump",false);
          
     // }

       
 
// condition flipface

    if (move < 0 && flip) 
    {
      FlipFace();
    }
     else if (move >0 && !flip)
    {
      FlipFace ();
    }
}

//method flipface

    void FlipFace ()
    {
        flip = !flip;
       // Vector3 character =transform.localScale;
        //character.x *=-1;
      //  transform.localScale=character;
       transform.Rotate(0f,180f,0f);
       //transform.localScale=character;
       

    }

    public void pressleft()
    {
        LeftButton = true;
    }

    public void unpressleft()
    {
        LeftButton = false;
    }

    public void pressright()
    {
        RightButton = true;
    }

    public void unpressright()
    {
        RightButton = false;
    }

    public void pressjump()
    {
        if (extrajump > 0)
      {
          jumpeffect.Play();
          jump.velocity = Vector2.up * jumpForce;
          anim.SetBool("doubleJump",true);
          extrajump--;
          
      }

      else if (extrajump == 0 && ground==true)
      {
          jumpeffect.Play();
          jump.velocity = Vector2.up * jumpForce;
           anim.SetBool("doubleJump",false);
          
          
      }
    }

    public void Respawn()
    {
      transform.position = Respawnpoint;
      DeadMenuUI.SetActive(false);
      AudioListener.pause = false;
      gameObject.SetActive(true);
      anim.SetTrigger("revived");
      foreach (Behaviour component in components2)
      component.enabled = true;
      GetComponent<Health>().AddHealth(healthValue2);
      GetComponent<Health>().revive();
    }

    private void OnTriggerEnter2D(Collider2D Collision3)
    {
       if (Collision3.tag == "checkpoint")
       {
         
         if (checkpointcount ==1)
         {
          Respawnpoint= transform.position;
          checkpoint.Play();
          checkpointcount--;
         }
       }

       else if (Collision3.tag == "finish")
       {
         Invoke("finishpoint",2.0f);
         finishmusic.Play();
         bgmusic2.Pause();
       }
    }

    private void finishpoint()
    {
       finishmenu.SetActive(true);
       foreach (Behaviour component in components2)
       component.enabled = false;
       applause.Play();
    }
   
}
