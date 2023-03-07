using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour, IInteractable
{
    //private int HP = 100;
    public Animator animator;
    //public Slider healthBar;

    //public GameObject portalLevel2;

    // public GameObject[] itemDrops;
    // public GameObject canvas;


    [SerializeField] private string _prompt = null;
    public string InteractionPrompt => _prompt;
    PlayerManager playerManager;
    CharacterStats myStats;
    // Start is called before the first frame update

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
        //animator.SetTrigger("damage");
        //AudioManager.instance.Play("TakeDamage");

    }
    }

    // public void TakeDamage(int damageAmount)
    // {
    //     HP -= damageAmount;
    //     if(HP <= 0){
    //         //play death animation
    //         AudioManager.instance.Play("Death");
    //         animator.SetTrigger("die");
            
    //         canvas.SetActive(false);
    //         portalLevel2.SetActive(true);
    //         foreach(GameObject items in itemDrops){
    //             items.SetActive(true);
    //         }
    //         GetComponent<Collider>().enabled = false;
    //     }
    //     else{
    //         //play get hit anime
    //         animator.SetTrigger("damage");
    //         AudioManager.instance.Play("TakeDamage");
    //     }
    // }

}
