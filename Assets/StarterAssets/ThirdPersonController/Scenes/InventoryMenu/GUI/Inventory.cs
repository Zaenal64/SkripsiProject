using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // Start is called before the first frame update

    void Start()
        {
            Time.timeScale = 1f;
            
        }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            //Cursor.visible = true;
                OpenInventory();
                if(Input.GetKeyDown(KeyCode.Escape)){
                    CloseInventory();
                }
        }
    }

    private void OpenInventory()
    {
        this.gameObject.SetActive(true);
    }

    private void CloseInventory(){
        this.gameObject.SetActive(false);
    }
}
