using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
[CreateAssetMenu(fileName = "CardProperties", menuName = "ScriptableObjects/CardProperties")]
public class SOCardProperties : ScriptableObject
{
    public string CardName;
    public string CardDescription;
    public Sprite CardImage;
    public GameEvent CardEvent;
}
