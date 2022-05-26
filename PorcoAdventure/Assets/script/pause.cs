using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pause : MonoBehaviour
{
  [SerializeField] private AudioSource click;
  public static bool GameisPaused = false;
   public GameObject PauseMenuUI;

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
        Time.timeScale = 0f;
        GameisPaused = true;
        AudioListener.pause = true;
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
        Application.LoadLevel (target);
        Time.timeScale = 1f;
        AudioListener.pause = false;
    }

     public void soundclick ()
    {
        click.Play();
    }
}
