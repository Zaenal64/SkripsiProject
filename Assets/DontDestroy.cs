using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DontDestroy : MonoBehaviour
{
    public static DontDestroy instance { get; private set; }

    // private void Awake(){
    //     if (instance != null) 
    //     {
    //         Debug.Log("This instance null");
    //         Destroy(this.gameObject);
    //         return;
    //     }
    //     instance = this;
    //     DontDestroyOnLoad(this.gameObject);
    // }

    private void Start() {
        if (instance != null) 
        {
            Debug.Log("This instance null : ");
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
    


}
