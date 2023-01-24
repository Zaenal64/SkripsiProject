using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    // Start is called before the first frame update
    public string SceneName;

    private void OnTriggerEnter(Collider other) {
        SceneManager.LoadScene(SceneName);
    }
}
