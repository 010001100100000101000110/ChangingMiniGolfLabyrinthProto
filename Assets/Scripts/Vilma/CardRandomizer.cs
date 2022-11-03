using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardRandomizer : MonoBehaviour
{
    [SerializeField] ScriptableObject[] cards;

    [SerializeField] Image cardImage1;
    [SerializeField] Image cardImage2;
    [SerializeField] Image cardImage3;

    void RandomizeCards()
    {
        //cardImage1.sprite = cards[Random.RandomRange(0,4)].cardim
    }
}
