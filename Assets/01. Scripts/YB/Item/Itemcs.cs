using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "NewItem/Item")]
public class Itemcs : ScriptableObject
{
    public string itemName;
    public ItemType itemType;
    public Sprite itemImage;
    public GameObject itemPrefab;

    public string waepontype;
    public enum ItemType
    {
        Equipment,
        Used,
        Ingredient,
        ETC
    }
}
