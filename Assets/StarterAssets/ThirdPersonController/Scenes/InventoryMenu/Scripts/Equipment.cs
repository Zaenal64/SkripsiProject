using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName ="Inventory/Equipment")]
public class Equipment : Item
{
    // Start is called before the first frame update
    public EquipmentSlot equipSlot;

    public int armorModifier;
    public int damageModifier;

    public override void Use(){

        base.Use();
        //Equip itemnya
        EquipmentManager.instance.Equip(this);
        //remove from inven

        RemoveFromInventory();
    }
   
}

public enum EquipmentSlot{Head, Chest, Legs, Feet}
