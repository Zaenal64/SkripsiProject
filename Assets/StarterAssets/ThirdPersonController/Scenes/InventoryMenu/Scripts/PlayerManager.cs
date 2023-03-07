using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    // Start is called before the first frame update
    #region Singleton
    public static PlayerManager instance;
    private void Awake() {
        if(instance != null){
            Debug.LogWarning("lebih dari satu playermanager ditemukan. Hancurkan yang terbaru");
            Destroy(this.gameObject);
            return;
        }
        instance = this;
    }

    

    #endregion

    
    public GameObject player;
    public PlayerStat playerStats;

    
    public void KillPlayer(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
