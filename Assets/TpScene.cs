using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
using UnityEngine.InputSystem;
#endif

public class TpScene : MonoBehaviour
{
    CharacterController characterController;
    //public Transform player;
    public Transform spawner;
    public GameObject chara;
    public int indexLevel;

    public string exitName;

    // private void Start() {
    //     characterController = gameObject.GetComponent<CharacterController>();
    // }

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other) {

        // StartCoroutine("Teleport");
        
        PlayerPrefs.SetString("LastExitName",exitName);
        //chara.SetActive(false);
        SceneManager.LoadSceneAsync(indexLevel);
        DataPersistenceManager.instance.SaveGame();
        //player.position = spawner.position;
        //chara.SetActive(true);
        //StartCoroutine("Teleport");
        

    }

    // IEnumerator Teleport(){
    //     yield return new WaitForSeconds(1f);
    //     player.transform.position = spawner.transform.position;
    //     yield return new WaitForSeconds(1f);

    // }
}
