using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : CharacterStats
{
    // Start is called before the first frame update
    public Animator animator;
    public GameObject[] itemDrops;
    public override void Die()
    {
        if(animator != null){
            //play death animation
            AudioManager.instance.Play("Death");
            animator.SetTrigger("die");
        }
        if(itemDrops != null){
            foreach(GameObject items in itemDrops){
                 items.SetActive(true);
             }
        }
        base.Die();
        XPManager.instance.AddXP(100);
        //Add ragdoll
        Destroy(this.gameObject);
    }
}
