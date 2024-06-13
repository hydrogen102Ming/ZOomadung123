using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Card
{
    public string cardName;
    public Sprite cardImage;
    public string cardSkill;
    public int weight;

    public Card(Card card)
    {
        this.cardName = card.cardName;
        this.cardImage = card.cardImage;
        this.cardSkill = card.cardSkill;
        this.weight = card.weight;
    }
}