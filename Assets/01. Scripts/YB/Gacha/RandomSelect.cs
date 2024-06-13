using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSelect : MonoBehaviour
{
    public List<Card> deck = new List<Card>();
    public int total = 0;

    void Start()
    {
        for (int i = 0; i < deck.Count; i++)
        {
            total += deck[i].weight;
        }
        ResultSelect();
    }

    public List<Card> result = new List<Card>();

    public Transform parent;
    public GameObject cardprefab;

    public void ResultSelect()
    {
        List<Card> deckCopy = new List<Card>(deck);
        int totalCopy = total;

        for (int i = 0; i < 3; i++) // 카드 개수 선택 
        {
            if (deckCopy.Count == 0) break; // 복사본 덱이 비어있다면 중단

            Card selectedCard = RandomCard(deckCopy, ref totalCopy);
            if (selectedCard != null)
            {
                result.Add(selectedCard);
                // 비어 있는 카드를 생성하고
                CardUI cardUI = Instantiate(cardprefab, parent).GetComponent<CardUI>();
                // 생성 된 카드에 결과 리스트의 정보를 넣어줍니다.
                cardUI.CardUISet(selectedCard);
            }
        }
    }

    public Card RandomCard(List<Card> deckCopy, ref int totalCopy)
    {
        int weight = 0;
        int selectNum = Random.Range(0, totalCopy) + 1;

        for (int i = 0; i < deckCopy.Count; i++)
        {
            weight += deckCopy[i].weight;
            if (selectNum <= weight)
            {
                Card temp = new Card(deckCopy[i]);
                totalCopy -= deckCopy[i].weight; // 전체 가중치에서 선택된 카드의 가중치를 뺍니다.
                deckCopy.RemoveAt(i); // 선택된 카드를 덱 복사본에서 제거합니다.
                return temp;
            }
        }
        return null;
    }
}