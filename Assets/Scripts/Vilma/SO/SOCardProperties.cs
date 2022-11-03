using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu(fileName = "CardProperties", menuName = "ScriptableObjects/CardProperties")]
public class SOCardProperties : ScriptableObject
{
    [SerializeField] public string cardName;
    [SerializeField] public string cardDescription;
    [SerializeField] public Sprite cardImage;
}
