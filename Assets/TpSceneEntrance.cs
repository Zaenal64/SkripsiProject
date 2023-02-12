using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TpSceneEntrance : MonoBehaviour
{
    // Start is called before the first frame update
    public string LastExitName;
    void Start()
    {
        if(PlayerPrefs.GetString("LastExitName")== LastExitName){
            PlayerScript.instance.transform.position = transform.position;
            PlayerScript.instance.transform.eulerAngles = transform.eulerAngles;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
