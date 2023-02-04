using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void Play(){
        //Cursor.visible = false;
        SceneManager.LoadScene("Playground", LoadSceneMode.Single);
    }

    public void Quit(){
        Application.Quit();
        Debug.Log("Player Quit Game");
    }
}
