using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot2 : MonoBehaviour
{
    public Itemcs item;
    public int itemCount;
    public Image itemimage;

    [SerializeField] private Text textCount;
    [SerializeField] private GameObject goCountImg;

    // 이미지 투명도 조절
    private void SetColor(float _alpha)
    {
        Color color = itemimage.color;
        color.a = _alpha;
        itemimage.color = color;
    }

    // 아이템 획득
    public void AddItem(Itemcs _item, int _count= 1)
    {
        item = _item;
        itemCount = _count;
        itemimage.sprite = item.itemImage;

        if(item.itemType != Itemcs.ItemType.Equipment)
        {
            goCountImg.SetActive(true);
            textCount.text = itemCount.ToString();
        }
        else
        {
            textCount.text = "0";
            goCountImg.SetActive(false);
        }

        SetColor(1);
    }

    // 아이템 개수 조정
    public void SetSlotCount(int _count)
    {
        itemCount += _count;
        textCount.text = itemCount.ToString();

        if(itemCount <= 0)
        {
            ClearSlot();
        }
    }

    // 슬롯 초기화
    private void ClearSlot()
    {
        item = null;
        itemCount = 0;
        itemimage.sprite = null;
        SetColor(0);

        textCount.text = "0";
        goCountImg.SetActive(false);
    }
}
