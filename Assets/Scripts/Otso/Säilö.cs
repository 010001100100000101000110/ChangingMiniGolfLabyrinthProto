using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Säilö : MonoBehaviour
{
    [SerializeField] TMP_Text infoDescriptionText;

    public void UpdateTutorialText(InfoDescription tutorialText)
    {
        infoDescriptionText.text = tutorialText.tutorialText;
    }
}
