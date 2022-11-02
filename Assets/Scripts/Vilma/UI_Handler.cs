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
    [SerializeField] TMP_Text gamePhaseText;
    [SerializeField] Image launchPowerFillImage;
    LaunchTracker launchTracker;
    Inventory inventory;
    BallController controller;

    private void Awake()
    {
        launchTracker = FindObjectOfType<LaunchTracker>();
        inventory = FindObjectOfType<Inventory>();
        controller = FindObjectOfType<BallController>();
        UpdateLaunchesLeftAmount();
        UpdateKeysCollectedAmount();
        UpdateResourcesCollectedAmount();
        UpdateGamePhaseText();
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

    public void UpdateGamePhaseText()
    {
        gamePhaseText.text = "Game Phase: " + GamePhaseManager.Instance.gamePhase;
    }
}
