using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;
public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Menu Buttons")]
    [SerializeField] private Button newGameButton;
    [SerializeField] private Button continueGameButton;
    GameData data;
    public AudioSource soundSource;

    private void Start() 
    {
        DisableButtonsDependingOnData();
        if(soundSource != null)
        soundSource.Play();
        
    }

    private void DisableButtonsDependingOnData() 
    {
        if (!DataPersistenceManager.instance.HasGameData()) 
        {
            continueGameButton.interactable = false;
        }
    }
    public void Play(){
        DisableMenuButtons();
        // create a new game - which will initialize our game data
        DataPersistenceManager.instance.NewGame();
        // load the gameplay scene - which will in turn save the game because of
        // OnSceneUnloaded() in the DataPersistenceManager
        DataPersistenceManager.instance.SaveGame();
        SceneManager.LoadSceneAsync("Playground");
        
    }

    public void Quit(){
        Application.Quit();
        Debug.Log("Player Quit Game");
    }

    public void Continue(){
        DisableMenuButtons();
        // load the next scene - which will in turn load the game because of 
        // OnSceneLoaded() in the DataPersistenceManager
        //DataPersistenceManager.instance.SaveGame();
        Debug.Log(DataPersistenceManager.instance.lastSceneGameData());
        SceneManager.LoadSceneAsync(DataPersistenceManager.instance.lastSceneGameData());

        
    }

    private void DisableMenuButtons()
    {
        newGameButton.interactable = false;
        continueGameButton.interactable = false;
    }
}
