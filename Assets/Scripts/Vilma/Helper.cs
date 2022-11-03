using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helper : MonoBehaviour
{
    public BallController controller;
    public EventMethods eventMethods;
    public Inventory inventory;
    public LaunchTracker launchTracker;

    void Awake()
    {
        controller = FindObjectOfType<BallController>();
        eventMethods = FindObjectOfType<EventMethods>();
        inventory = FindObjectOfType<Inventory>();
        launchTracker = FindObjectOfType<LaunchTracker>();
    }
}
