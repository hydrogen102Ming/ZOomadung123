using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Iron,
    Diamond,
    Gold
}

[System.Serializable]
public class Item
{
    public ItemType itemType;   
    public string itemName;
    public Sprite itemSprite;
    
    public List<ItemEffect> itemEffect;

    public bool Use()
    {
        bool isUsed = false;
        foreach (ItemEffect effect in itemEffect)
        {
            isUsed = effect.ExecuteRole();
        }

        return false;
    }
}
