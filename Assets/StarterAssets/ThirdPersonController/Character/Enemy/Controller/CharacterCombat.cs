using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class CharacterCombat : MonoBehaviour
{
    // Start is called before the first frame update
    public float attackSpeed = 1f;
    private float Cooldown = 0f;
    public float attackDelay = 1f;

    public event System.Action onAttack;
    CharacterStats myStats;
    void Start()
    {
        myStats = GetComponent<CharacterStats>();
    }

    private void Update() {
        Cooldown -= Time.deltaTime;
    }

    // Update is called once per frame
    public void Attack(CharacterStats targetStats){
        if(Cooldown <= 0f){
            StartCoroutine(DoDamage(targetStats,attackDelay));
            if(onAttack != null)
            onAttack();
            Cooldown = 1f/attackSpeed;
        }
        
    }

    IEnumerator DoDamage(CharacterStats stats, float delay){
        yield return new WaitForSeconds(delay);
        stats.TakeDamage(myStats.damage.GetValue());
    }
}
