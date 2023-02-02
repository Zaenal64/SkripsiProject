using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractionPromptUi : MonoBehaviour
{
    // Start is called before the first frame update
    private Camera _mainCam;
    [SerializeField] private TextMeshProUGUI _promptText;
    [SerializeField] private GameObject _uiPanel;

    private void Start() {
        _mainCam = Camera.main;
        _uiPanel.SetActive(false);
    }

    private void LateUpdate() {
        var rotation = _mainCam.transform.rotation;
        transform.LookAt(transform.position + rotation * Vector3.forward, rotation * Vector3.up);

    }
    public bool isDisplayed = false;
    public void SetUp(string promptText){
        _promptText.text = promptText;
        _uiPanel.SetActive(true);
        isDisplayed = true;
    }

    public void close(){
        _uiPanel.SetActive(false);
        isDisplayed = false;
    }
}
