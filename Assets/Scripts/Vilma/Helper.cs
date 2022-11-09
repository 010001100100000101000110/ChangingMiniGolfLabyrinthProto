using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helper : MonoBehaviour
{
    public BallController controller;
    public EventMethods eventMethods;
    public Inventory inventory;
    public LaunchTracker launchTracker;
    public UI_Handler uiHandler;
    public PlayerCardInventory playerCardInventory;
    public CardRandomizer cardRandomizer;

    void Awake()
    {
        controller = FindObjectOfType<BallController>();
        eventMethods = FindObjectOfType<EventMethods>();
        inventory = FindObjectOfType<Inventory>();
        launchTracker = FindObjectOfType<LaunchTracker>();
        uiHandler = FindObjectOfType<UI_Handler>();
        playerCardInventory = FindObjectOfType<PlayerCardInventory>();
        cardRandomizer = FindObjectOfType<CardRandomizer>();
    }
}
