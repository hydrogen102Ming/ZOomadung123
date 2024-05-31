using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;

    private int slotCnt;

    public delegate void OnSlotCountChange(int val);
    public OnSlotCountChange onslotCountChange;

    public delegate void OnChangeItem();
    public OnChangeItem onChangeItem;

    public List<Item> items = new List<Item>(); 

    public int SlotCnt
    {
        get => slotCnt; 
        set
        {
            slotCnt = value;
            onslotCountChange(slotCnt);
        }

    }

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }

    private void Start()
    {
        SlotCnt = 4;
    }

    public bool AddItem(Item _item)
    {
        if(items.Count < SlotCnt)
        {
            items.Add(_item);
            if(onChangeItem != null)
                onChangeItem.Invoke();
            return true;
        }
        return false;
    }

    public void ReMoveItem(int _index)
    {
        items.RemoveAt(_index);
        onChangeItem.Invoke();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("FieldItem"))
        {
            FieldItem fieldItem = other.GetComponent<FieldItem>();

            if(AddItem(fieldItem.GetItem()))
                fieldItem.DestroyItem();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("FieldItem"))
        {
            FieldItem fieldItem = collision.GetComponent<FieldItem>();

            if (AddItem(fieldItem.GetItem()))
                fieldItem.DestroyItem();
        }
    }
}
