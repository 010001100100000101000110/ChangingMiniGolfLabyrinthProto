using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class CardRandomizer : MonoBehaviour
{
    public List<SOCardProperties> cards = new List<SOCardProperties>();
    [SerializeField] List<UICardProperties> cardUI = new List<UICardProperties>();

    PlayerCardInventory cardInventory;
    void Start()
    {
        cardInventory = GetComponent<PlayerCardInventory>();
    }

    public List<SOCardProperties> GetRandomizedCards()
    {
        List<int> randomNumbers = new List<int>() { 0, 1, 2, 3, 4 };       

        List<SOCardProperties> cards = new List<SOCardProperties>();

        for (int i = 0; i < 3; i++)
        {
            int number = randomNumbers[Random.Range(0, randomNumbers.Count)];
            cards.Add(this.cards[number]);
            randomNumbers.Remove(number);
        }
        return cards;
    }

    public void RemoveButtonListeners()
    {
        for (int i = 0; i < cardUI.Count; i++)
        {
            cardUI[i].CardButton.onClick.RemoveAllListeners();
        }
    }
}