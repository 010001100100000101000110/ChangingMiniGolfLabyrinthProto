using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu(fileName = "CardProperties", menuName = "ScriptableObjects/CardProperties")]
public class SOProperties : ScriptableObject
{
    [SerializeField] string cardName;
    [SerializeField] string cardDescription;
    [SerializeField] Sprite cardImage;
}
