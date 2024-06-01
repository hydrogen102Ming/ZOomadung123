using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionContoller : MonoBehaviour
{
    [SerializeField] private float range; // Ω¿µÊ ∞°¥…«— √÷¥Î ∞≈∏Æ

    private bool pickupActivated = false;

    private RaycastHit hitInfo; // √Êµπ√º ¡§∫∏ ¿˙¿Â
    [SerializeField] private LayerMask layerMask;

    [SerializeField] private Text actionText;

    [SerializeField] private Inventory2 theInventory;

    private void Update()
    {
        CheckItem();
        TryAction();
    }

    private void TryAction()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            CheckItem();
            CanPickUp();
        }
    }

    private void CanPickUp()
    {
        if(pickupActivated)
        {
            if(hitInfo.transform != null)
            {
                Debug.Log(hitInfo.transform.GetComponent<ItemPickUp>().item.itemName + "»πµÊ«ﬂΩ¿¥œ¥Ÿ");
                theInventory.AcquireItem(hitInfo.transform.GetComponent<ItemPickUp>().item);
                Destroy(hitInfo.transform.gameObject);
                InfoDisAppear();
            }
        }
    }

    private void CheckItem()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hitInfo, range, layerMask))
        {
            if (hitInfo.transform.tag == "Item")
            {
                ItemInfoAppear();
            }
        }
        else
            InfoDisAppear();
    }


    private void ItemInfoAppear()
    {
        pickupActivated = true;
        actionText.gameObject.SetActive(true);
        actionText.text = hitInfo.transform.GetComponent<ItemPickUp>().item.itemName + "»πµÊ" + "<color=yellow>" + "(E)" + "</color>";
    }

    private void InfoDisAppear()
    {
        pickupActivated = false;
        actionText.gameObject.SetActive(false);
    }
}
