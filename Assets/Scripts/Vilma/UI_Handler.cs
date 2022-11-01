using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_Handler : MonoBehaviour
{
    [SerializeField] TMP_Text launchesLeftText;
    [SerializeField] TMP_Text keysCollectedText;
    [SerializeField] TMP_Text resourcesCollectedText;
    LaunchTracker launchTracker;
    Inventory inventory;

    private void Start()
    {
        launchTracker = FindObjectOfType<LaunchTracker>();
        inventory = FindObjectOfType<Inventory>();
        UpdateLaunchesLeftAmount();
        UpdateKeysCollectedAmount();
        UpdateResourcesCollectedAmount();
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
}
