using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class PlayerStat : CharacterStats
{
    // Start is called before the first frame update
	
	 
    public void Start () {
		EquipmentManager.instance.onEquipmentChanged += OnEquipmentChanged;
	}

    // Update is called once per frame
    void OnEquipmentChanged(Equipment newItem, Equipment oldItem)
	{
		if (newItem != null) {
			armor.AddModifier (newItem.armorModifier);
			damage.AddModifier (newItem.damageModifier);
		}

		if (oldItem != null)
		{
			armor.RemoveModifier(oldItem.armorModifier);
			damage.RemoveModifier(oldItem.armorModifier);
		}

	}

	public void IncreaseHealth(int level){
		maxHealth += Mathf.RoundToInt((currentHealth * 0.01f) * ((100 - level) * 0.1f));
        currentHealth = maxHealth;
		Debug.Log(currentHealth);
	}

	public override void Die(){

		base.Die();
		currentHealth = maxHealth;
		PlayerManager.instance.KillPlayer();
	}

}
