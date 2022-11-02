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
    LaunchTracker launchTracker;
    Inventory inventory;
    BallController controller;

    private void Start()
    {
        launchTracker = FindObjectOfType<LaunchTracker>();
        inventory = FindObjectOfType<Inventory>();
        controller = FindObjectOfType<BallController>();
        UpdateLaunchesLeftAmount();
        UpdateKeysCollectedAmount();
        UpdateResourcesCollectedAmount();
    }

    private void Update()
    {
        if (controller.ballSelected) UpdateSlider();
    }

    void UpdateSlider()
    {
        launchPowerFillImage.fillAmount =  controller.GetDistance() / controller.GetMaxDistance();
        Debug.Log(controller.GetDistance());
        Debug.Log(controller.GetMaxDistance());
    }

    public void UpdateLaunchesLeftAmount()
    {
        launchesLeftText.text = "Launches left: " + launchTracker.launchesLeft.ToString();
    }

    public void UpdateKeysCollectedAmount()
    {
        keysCollectedText.text = "Keys collected: " + inventory.KeysCollected;
    }

    public void UpdateResourcesCollectedAmount()
    {
        resourcesCollectedText.text = "Resources collected: " + inventory.ResourcesCollected;
    }

    public void SetActiveGameOverPanel()
    {
        if (launchTracker.launchesLeft <= 0) gameOverPanel.SetActive(true);
    }
}
