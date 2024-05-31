using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public GameObject inventoryPanel;
    bool activeInventory = false;

    public Slot[] slots;
    public Transform slotHader;

    private Inventory inventory;

    private void Start()
    {

        inventory = Inventory.instance;
        slots = slotHader.GetComponentsInChildren<Slot>();
        inventory.onslotCountChange += SlotChange;

        inventory.onChangeItem += RedrawSlotUI;

        inventoryPanel.SetActive(activeInventory);
    }

    private void SlotChange(int val)
    {
        for(int i = 0; i < slots.Length; i++)
        {
            slots[i].slotnum = i;
            if (i < inventory.SlotCnt)
                slots[i].GetComponent<Button>().interactable = true;
            else
                slots[i].GetComponent<Button>().interactable = false;
        }
    }

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.I))
        {
            activeInventory = !activeInventory;
            inventoryPanel.SetActive(activeInventory);
        }
    }

    public void AddSlot()
    {
        inventory.SlotCnt++;
    }


    private void RedrawSlotUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].RemoveSlot();
        }

        for (int i = 0; i < inventory.items.Count; i++)
        {
            slots[i].item = inventory.items[i];
            slots[i].UpdateSlotUI();
        }
    }
}
