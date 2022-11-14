using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayeCardButtonCheck : MonoBehaviour
{
    Helper helper;
    void Start()
    {
        helper = FindObjectOfType<Helper>();
    }

    void Update()
    {
        if (helper.playerCardInventory.cardInventory.Count <= 0) this.gameObject.SetActive(false);
        else this.gameObject.SetActive(true);
    }
}
