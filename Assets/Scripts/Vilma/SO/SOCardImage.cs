using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
[CreateAssetMenu(fileName = "Image", menuName = "ScriptableObjects/Image")]
public class SOCardImage : ScriptableObject
{
    public TMP_Text cardName;
    public TMP_Text cardDescription;
    public Image cardSprite;
}
