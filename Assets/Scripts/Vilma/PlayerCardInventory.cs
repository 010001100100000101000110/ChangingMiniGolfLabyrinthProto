using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCardInventory : MonoBehaviour
{
    Helper helper;
    public List<SOCardProperties> cardInventory = new List<SOCardProperties>();

    void Start()
    {
        helper = FindObjectOfType<Helper>();
    }

    public void AddCardToInventory(SOCardProperties card)
    {
        cardInventory.Add(card);
    }

    public void RemoveCardFromInventory(SOCardProperties card)
    {
        cardInventory.Remove(card);
    }
}
