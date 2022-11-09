using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePhaseManager : MonoBehaviour
{
    public static GamePhaseManager Instance;
    EventMethods eventMethods;
    UI_Handler uiHandler;

    [Serializable]
    public enum GamePhase { cardPhase, movePhase, labyrinthMovePhase, testiPhase }
    public GamePhase gamePhase;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        eventMethods = FindObjectOfType<EventMethods>();
    }

    private void Start()
    {
        uiHandler = FindObjectOfType<UI_Handler>();
    }

    //vilman juttu
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            UpdateGamePhase(GamePhase.cardPhase);
        }
    }

    public void SetEnum(string newState)
    {
        gamePhase = (GamePhase)Enum.Parse(typeof(GamePhase), newState);
    }

    public void UpdateGamePhase(GamePhase newState)
    {
        Instance.gamePhase = newState;

        switch (newState)
        {
            case GamePhase.cardPhase:
                Instance.eventMethods.ActivateCardPhase();
                break;
            case GamePhase.movePhase:
                break;
            case GamePhase.labyrinthMovePhase:
                Instance.eventMethods.MazeRotate();
                break;
            case GamePhase.testiPhase:
                break;
        }
        Instance.uiHandler.UpdateGamePhaseText();
    }
}
