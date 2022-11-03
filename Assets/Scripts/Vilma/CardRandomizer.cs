using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardRandomizer : MonoBehaviour
{
    [SerializeField] SOCardProperties[] cards;
    [SerializeField] UICardProperties[] cardUI;
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
        cardUI[uiCard].cardImage.sprite = cards[cardInt].cardImage;
        cardUI[uiCard].cardName.text = cards[cardInt].cardName;
        cardUI[uiCard].cardDescription.text = cards[cardInt].cardDescription;
    }
}