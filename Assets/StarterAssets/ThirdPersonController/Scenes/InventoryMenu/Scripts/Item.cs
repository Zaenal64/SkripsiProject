using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    // Start is called before the first frame update
    new public string name = "New Item";
    public Sprite icon = null;
    public bool isDefaultItem = false;

    public virtual void Use(){

        //use itemnya
        //sesuatu terjadi

        Debug.Log("Using " + name);
    }

    public void RemoveFromInventory(){
        Inventory.instance.Remove(this);
    }

}
