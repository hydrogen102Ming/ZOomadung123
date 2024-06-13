using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CardUI : MonoBehaviour, IPointerDownHandler
{
    public Image chr;
    public Text cardName;
    public Text cardSkill;
    Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void CardUISet(Card card)
    {
        chr.sprite = card.cardImage;
        cardName.text = card.cardName;
        cardSkill.text = card.cardSkill;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        animator.SetTrigger("Flip");
    }
}