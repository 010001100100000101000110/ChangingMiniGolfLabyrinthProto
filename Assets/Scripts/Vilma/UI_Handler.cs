using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Handler : MonoBehaviour
{
    [SerializeField] TMP_Text launchesLeftText;
    [SerializeField] TMP_Text keysCollectedText;
    [SerializeField] TMP_Text resourcesCollectedText;
    [SerializeField] Image launchPowerFillImage;
    [SerializeField] GameObject gameOverPanel;
    
    Helper helper;

    void Start()
    {
        helper = FindObjectOfType<Helper>();
        UpdateLaunchesLeftAmount();
        UpdateKeysCollectedAmount();
        UpdateResourcesCollectedAmount();
    }

    void Update()
    {
        if (helper.controller.ballSelected) UpdateSlider();
    }

    void UpdateSlider()
    {
        launchPowerFillImage.fillAmount = helper.controller.GetDistance() / helper.controller.GetMaxDistance();
    }

    public void UpdateLaunchesLeftAmount()
    {
        launchesLeftText.text = "Launches left: " + helper.launchTracker.launchesLeft.ToString();
    }

    public void UpdateKeysCollectedAmount()
    {
        keysCollectedText.text = "Keys collected: " + helper.inventory.KeysCollected;
    }

    public void UpdateResourcesCollectedAmount()
    {
        resourcesCollectedText.text = "Resources collected: " + helper.inventory.ResourcesCollected;
    }

    public void SetActiveGameOverPanel()
    {
        if (helper.launchTracker.launchesLeft <= 0) gameOverPanel.SetActive(true);
    }
}
