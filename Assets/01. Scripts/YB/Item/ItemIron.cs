using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ItemEffect/Consumable/ingredient")]
public class ItemIron : ItemEffect
{
    // 원하는 효과 
    public int healingPoint = 0;
    public override bool ExecuteRole()
    {
        Debug.Log("Player HP Add : " +  healingPoint);
        return true;
    }
}
