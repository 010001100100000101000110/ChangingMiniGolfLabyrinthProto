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
            Debug.Log(this.gameObject);
            this.gameObject.SetActive(true);
        }
    }
}
