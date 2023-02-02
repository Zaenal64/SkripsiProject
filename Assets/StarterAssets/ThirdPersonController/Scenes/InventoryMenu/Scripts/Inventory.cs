using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // Start is called before the first frame update
    #region Singleton
    public static Inventory instance;

    private void Awake() {
        if(instance != null){
            Debug.LogWarning("lebih dari satu inventory ditemukan");
            return;
        }
        instance = this;
    }
    #endregion
    
    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;
    public int space = 20;
    public List<Item> items = new List<Item>();

    public bool Add(Item item){
        if(!item.isDefaultItem){
            if(items.Count >= space){
                Debug.Log("Not Enough room");
                return false;
            }
            items.Add(item);
            if(onItemChangedCallback != null)onItemChangedCallback.Invoke();
            
        }
        return true;
        
    }

    public void Remove(Item item){
        items.Remove(item);
        if(onItemChangedCallback != null)onItemChangedCallback.Invoke();
    }
}
