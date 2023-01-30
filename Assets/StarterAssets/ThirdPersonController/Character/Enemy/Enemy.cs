using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    private int HP = 100;
    public Animator animator;
    public Slider healthBar;

    public GameObject portalLevel2;

    // Start is called before the first frame update

    private void Update() {
        healthBar.value = HP;
    }
    public void TakeDamage(int damageAmount)
    {
        HP -= damageAmount;
        if(HP <= 0){
            //play death animation
            AudioManager.instance.Play("Death");
            animator.SetTrigger("die");
            GetComponent<Collider>().enabled = false;
            portalLevel2.SetActive(true);
        }
        else{
            //play get hit anime
            animator.SetTrigger("damage");
            AudioManager.instance.Play("TakeDamage");
        }
    }
}
