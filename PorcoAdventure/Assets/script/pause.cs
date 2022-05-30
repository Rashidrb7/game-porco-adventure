using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pause : MonoBehaviour
{
  [SerializeField] private AudioSource click;
  public static bool GameisPaused = false;
   public GameObject PauseMenuUI;
   [SerializeField] private AudioSource PausedClick;

   void Update()
    {
        if (Input.GetKeyDown (KeyCode.Escape))
        {
            if (GameisPaused)
            {
                Resume();
            }

            else 
            {
                Pause();
            }
        }
    }

    public void Resume ()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameisPaused = false;
        AudioListener.pause = false;
        
        //AudioSource [] audios = FindObjectsOfType<AudioSource>();

        //(AudioSource a in audios)
        //{
        //    a.Play();
        //}

    }

    public void Pause ()
    {  
        PauseMenuUI.SetActive(true);
        
        Invoke("DelayPause",0.15f);
        
        
        //AudioSource [] audios = FindObjectsOfType<AudioSource>();

        //foreach (AudioSource a in audios)
        //{
        //    a.Pause();
        //}


    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
        AudioListener.pause = false;
    }

     public void Restart (int target)
    {
         SceneManager.LoadScene (target);
        Time.timeScale = 1f;
        AudioListener.pause = false;
    }

     public void soundclick ()
    {
        click.Play();
    }

    private void DelayPause ()
    {
        AudioListener.pause = true;
        GameisPaused = true;
        Time.timeScale = 0f;
    }

    public void pausedsoundclick ()
    {
        PausedClick.Play();
    }
    

}
