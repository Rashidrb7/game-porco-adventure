using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour
{
    [Header ("Health")]
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    private Animator anim;
    private bool dead; 
    [SerializeField] private AudioSource hiteffect;
    [SerializeField] private AudioSource dieeffect;
    [SerializeField] private AudioSource diemusic;
    [SerializeField] private AudioSource bgmusic;

    [Header("iFrames")]
    [SerializeField] private float iFramesDuration;
    [SerializeField] private int numberOfFlashes;
    private SpriteRenderer spriteRend;

   [Header("Components")]
   [SerializeField] private Behaviour[] components;
    private bool invulnerable;

    [SerializeField] private AudioSource healtheffect;
    public GameObject DeadMenuUI;


    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }
    public void TakeDamage(float _damage)
    {
        if (invulnerable) return;
        currentHealth = Mathf.Clamp(currentHealth -_damage, 0, startingHealth);

        if (currentHealth > 0)
        {
            hiteffect.Play();
            anim.SetTrigger("hurt");
            StartCoroutine(Invunerability());
        }
        else
        {
            if (!dead)
            {
                dieeffect.Play();
                diemusic.Play();
                bgmusic.Pause();
                anim.SetTrigger("die");
                Invoke("DeadMenu",2.0f);

                //Deactivate all attached component classes
               foreach (Behaviour component in components)
               component.enabled = false;
                //if (GetComponent<EnemyPatrol>() !=null)
                //{
               // GetComponent<EnemyPatrol>().enabled = false;
                //}
               // GetComponent<MeleeEnemy>().enabled = false;

               dead = true;
            }
        }
    }
    public void AddHealth(float _value)
    {
        healtheffect.Play();
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }
    private IEnumerator Invunerability()
    {
        invulnerable = true;
        Physics2D.IgnoreLayerCollision(10, 11, true);
        for (int i = 0; i < numberOfFlashes; i++)
        {
            spriteRend.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
        }
        Physics2D.IgnoreLayerCollision(10, 11, false);
        invulnerable = false;
    }
    private void Deactivate()
    {
        gameObject.SetActive(false);
        

    }
    private void DeadMenu()
    {
        DeadMenuUI.SetActive(true);
        //AudioListener.pause = true;
       
    }

    public void revive ()
    {
        dead = false;
        bgmusic.Play();
    }
}
