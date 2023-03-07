using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CharacterStats))]
public class EnemyNew : MonoBehaviour, IInteractable
{
    // Start is called before the first frame update
    [SerializeField] private string _prompt = null;
    public string InteractionPrompt => _prompt;
    PlayerManager playerManager;
    CharacterStats myStats;
    void Start() {
        playerManager = PlayerManager.instance;
        myStats = GetComponent<CharacterStats>();
    }
    public void Interact(Interactor interactor)
    {
        //Debug.Log("Interact with enemy");
        CharacterCombat playerCombat = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterCombat>();
        //playerManager.player.GetComponent<CharacterCombat>();
       //attack enemy
       if(playerCombat != null){
        playerCombat.Attack(myStats);

    }
    }
    
    

    
}
