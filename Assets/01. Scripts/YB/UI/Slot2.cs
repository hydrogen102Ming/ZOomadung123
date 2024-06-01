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

    // �̹��� ���� ����
    private void SetColor(float _alpha)
    {
        Color color = itemimage.color;
        color.a = _alpha;
        itemimage.color = color;
    }

    // ������ ȹ��
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

    // ������ ���� ����
    public void SetSlotCount(int _count)
    {
        itemCount += _count;
        textCount.text = itemCount.ToString();

        if(itemCount <= 0)
        {
            ClearSlot();
        }
    }

    // ���� �ʱ�ȭ
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
