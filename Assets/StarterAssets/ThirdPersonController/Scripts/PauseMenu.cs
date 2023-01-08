using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class PauseMenu : MonoBehaviour
{
    public static bool Paused = false;
    public GameObject PauseMenuCanvas;
    public UnityEvent GamePaused;
    public UnityEvent GameResumed;

    
    // Start is called before the first frame update
    void Start()
        {
            Time.timeScale = 1f;
            
        }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
            if(Paused)
            {
                Play();
                
            }
            else{
                Stop();
                
            }
            
        }
    }

     public void Stop()
    {
        PauseMenuCanvas.SetActive(true);
        Time.timeScale = 0f;
        GamePaused.Invoke();
        Paused = true;
    }

    public void Play()
    {
        PauseMenuCanvas.SetActive(false);
        Time.timeScale = 1;
        GameResumed.Invoke();
        Cursor.visible = false;
        Paused = false;
        
    }

    public void MainMenuButton()
    {
        //SceneManager.LoadScene("MainMenu");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
