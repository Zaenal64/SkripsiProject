using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public static PlayerScript instance;
    void Start()
    {
        
        if(instance != null){
            Destroy(gameObject);
        }
        else{
            instance = this;
        }
        
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        int scene = SceneManager.GetActiveScene().buildIndex;
        if(scene == 0){
            Debug.Log("scene"+ scene);
            Destroy(this.gameObject);
        }
    }
}
