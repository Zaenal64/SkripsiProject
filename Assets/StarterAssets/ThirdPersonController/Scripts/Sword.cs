using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public int damageAmount = 20;
    static Collider currentCollider;

    //public bool isAttack = false;
    // Start is called before the first frame update
    void Start()
    {
        currentCollider = gameObject.GetComponent<Collider>();
        currentCollider.enabled = false;
        Debug.Log("WeaponCollider false");
        //Destroy(gameObject, 10);
    }


    // Update is called once per frame
    private void OnTriggerEnter(Collider other) {
             if(other.tag == "Enemy"){
             Debug.Log("hit enemy");
             other.GetComponent<Enemy>().TakeDamage(damageAmount);
             }
    }
}
