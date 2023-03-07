using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class PauseMenu : MonoBehaviour
{
    public static bool Paused = false;

    public static bool Inven = false;
    public GameObject PauseMenuCanvas;

    public GameObject InventoryCanvas;
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
            //Cursor.visible = true;
            if(Paused)
            {
                Play();
                
            }
            else{
                Stop();
                
            }
            
        }
        if(Input.GetKeyDown(KeyCode.I)){
            
                if(Inven){
                    InventoryClose();
                }else{
                    InventoryOpen();
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
        //Cursor.visible = false;
        Paused = false;
        
    }

    public void MainMenuButton()
    {
        
            // load the main menu scene
        SceneManager.LoadSceneAsync("MainMenu");
        DataPersistenceManager.instance.SaveGame();
    }

    public void InventoryOpen(){
        InventoryCanvas.SetActive(true);
        GamePaused.Invoke();
        //Time.timeScale = 0;
        Inven = true;
        
    }
    public void InventoryClose(){
        InventoryCanvas.SetActive(false);
        GameResumed.Invoke();
        //Time.timeScale = 1;
        Inven = false;
        
    }

    public void Quit(){
        DataPersistenceManager.instance.SaveGame();
        Application.Quit();
    }
}
