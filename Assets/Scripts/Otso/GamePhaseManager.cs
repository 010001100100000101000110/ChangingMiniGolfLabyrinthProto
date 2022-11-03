using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePhaseManager : MonoBehaviour
{
    public static GamePhaseManager Instance;
    EventMethods eventMethods;

    public enum GamePhase { cardPhase, movePhase, labyrinthMovePhase};
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

    
    public void UpdateGamePhase(GamePhase newState)
    {
        gamePhase = newState;

        switch (newState)
        {
            case GamePhase.cardPhase:
                break;
            case GamePhase.movePhase:
                break;
            case GamePhase.labyrinthMovePhase:
                eventMethods.MazeRotate();
                break;
        }
    }
}
