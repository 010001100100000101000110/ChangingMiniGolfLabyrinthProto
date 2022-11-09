using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int KeysCollected { get; private set; }
    public int ResourcesCollected { get; private set; }
    [SerializeField] int amountToGetCard;
    [SerializeField] int amountToActivateFinish;
    Helper helper;
    private void Start()
    {
        helper = FindObjectOfType<Helper>();
    }
    public void AddToKeysCollected()
    {
        KeysCollected++;        
    }
    public void AddToResourcesCollected()
    {
        ResourcesCollected++;
        if (ResourcesCollected >= amountToGetCard)
        {
            helper.eventMethods.ChooseCard();
        }
    }

    public void ResetInventory()
    {
        KeysCollected = 0;
        ResourcesCollected = 0;
    }

    public int KeyAmountNeeded()
    {
        return amountToActivateFinish;
    }
}
