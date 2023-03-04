using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class CharacterCombat : MonoBehaviour
{
    // Start is called before the first frame update
    public float attackSpeed = 1f;
    private float Cooldown = 0f;

    public event System.Action onAttack;
    CharacterStats myStats;
    CharacterStats opponentStats;
    void Start()
    {
        myStats = GetComponent<CharacterStats>();
    }

    private void Update() {
        Cooldown -= Time.deltaTime;
    }

    // Update is called once per frame
    public void Attack(CharacterStats opponentStats){
        if(Cooldown <= 0f){
            this.opponentStats = opponentStats;
            Cooldown = 1f/attackSpeed;
            StartCoroutine(DoDamage(opponentStats,0.05f));
            if(onAttack != null){
                
            onAttack();
            }
        }
        
    }

    IEnumerator DoDamage(CharacterStats stats, float delay){
        yield return new WaitForSeconds(delay);
        stats.TakeDamage(myStats.damage.GetValue());
        yield return new WaitForSeconds(delay);
    }
}
