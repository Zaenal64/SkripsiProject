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

	public override void Die(){

		base.Die();
		PlayerManager.instance.KillPlayer();
	}

}
