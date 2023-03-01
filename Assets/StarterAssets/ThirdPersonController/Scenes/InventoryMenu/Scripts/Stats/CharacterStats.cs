
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterStats : MonoBehaviour
{
    // Start is called before the first frame update
    public int maxHealth = 100;
    public int currentHealth{get; private set;}
    public Stat damage;
    public Stat armor;
    public Slider healthBar;
    

    private void Awake() {
        currentHealth = maxHealth;
    }
    private void Update() {
        healthBar.value = currentHealth;
        if(Input.GetKeyDown(KeyCode.T)){
            TakeDamage(10);
            Debug.Log(currentHealth.ToString());
        }
    }

    public void TakeDamage(int damage)
    {
        damage -= armor.GetValue();
		damage = Mathf.Clamp(damage, 0, int.MaxValue);

		// Subtract damage from health
		currentHealth -= damage;
        Debug.Log(transform.name + " takes " + damage + " damage ");
        if(currentHealth <= 0){
            Die();
        }
    }

    public virtual void Die(){
        //DIE
        //Bisa di overwrite
        Debug.Log(transform.name + " Died. ");
    }
}
