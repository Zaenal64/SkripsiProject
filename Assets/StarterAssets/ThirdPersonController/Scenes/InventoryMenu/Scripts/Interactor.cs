using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class Interactor : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private TextMeshPro UseText;
    [SerializeField] private Transform _interactionPoint;
    [SerializeField] private float _interactionPointRadius = 0.5f;
    [SerializeField] private LayerMask _interactableMask;

    [SerializeField] private InteractionPromptUi _interactionPromptUi;

    private readonly Collider[] _colliders = new Collider[3];
    [SerializeField] private int _numFound;
    private IInteractable _interactable;

    // Update is called once per frame
    void Update()
    {
        _numFound = Physics.OverlapSphereNonAlloc(_interactionPoint.position, _interactionPointRadius,_colliders,_interactableMask);

        if(_numFound>0){
            
            _interactable = _colliders[0].GetComponent<IInteractable>();
            if(_interactable != null ){
                if(!_interactionPromptUi.isDisplayed) _interactionPromptUi.SetUp(_interactable.InteractionPrompt);
                if(Keyboard.current.fKey.wasPressedThisFrame){
                    _interactable.Interact(this);
                    
                }
                if(gameObject.CompareTag("Enemy")){
                    _interactionPromptUi.close();
                    if(Input.GetMouseButton(0) && GameObject.FindGameObjectWithTag("Enemy")){
                    
                    StartCoroutine(InteractEnemy(_interactable, 1f));
                }
                }

                
            }
        }
        else{
            if(_interactable != null)_interactable = null;
            if(_interactionPromptUi.isDisplayed)_interactionPromptUi.close();
        }
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_interactionPoint.position, _interactionPointRadius);
    }

    IEnumerator InteractEnemy(IInteractable _interactable, float delay){
        yield return new WaitForSeconds(delay);
        _interactable.Interact(this);
        yield return new WaitForSeconds(delay);
    }
}
