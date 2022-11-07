using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class CardRandomizer : MonoBehaviour
{
    [SerializeField] SOCardProperties[] cards;
    [SerializeField] UICardProperties[] cardUI;

    PlayerCardInventory cardInventory;
    void Start()
    {
        cardInventory = GetComponent<PlayerCardInventory>();
    }
    public void RandomizeCards()
    {
        List<int> randomNumbers = new List<int>() { 0, 1, 2, 3 };

        for (int i = 0; i < 3; i++)        
        {
            int number = randomNumbers[Random.Range(0, randomNumbers.Count)];    
            DrawCards(i, number);
            
            randomNumbers.Remove(number);
        }
    }

    void DrawCards(int uiCard, int cardInt)
    {
        cardUI[uiCard].CardImage.sprite = cards[cardInt].CardImage;
        cardUI[uiCard].CardName.text = cards[cardInt].CardName;
        cardUI[uiCard].CardDescription.text = cards[cardInt].CardDescription;
        cardUI[uiCard].CardButton.onClick.AddListener(delegate { cardInventory.AddCardToInventory(cards[cardInt]); });
    }

    public void RemoveButtonListeners()
    {
        for (int i = 0; i < cardUI.Length; i++)
        {
            cardUI[i].CardButton.onClick.RemoveAllListeners();
        }
    }
}