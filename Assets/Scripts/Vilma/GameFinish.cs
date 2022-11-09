using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFinish : MonoBehaviour
{
    Helper helper;

    void Start()
    {
        helper = FindObjectOfType<Helper>();
        gameObject.SetActive(false);
    }
    public void ActivateFinish()
    {
        if (helper.inventory.KeysCollected >= helper.inventory.KeyAmountNeeded())
        {
            this.gameObject.SetActive(true);
        }
    }
}
