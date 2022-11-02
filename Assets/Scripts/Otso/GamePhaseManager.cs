using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePhaseManager : MonoBehaviour
{
    private static GamePhaseManager instance;

    public static GamePhaseManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GamePhaseManager>();
                if (instance == null)
                {
                    instance = new GameObject().AddComponent<GamePhaseManager>();
                }
            }

            return instance;
        }
    }

    UI_Handler uiHandler;

    public enum GamePhase { cardPhase, movePhase, labyrinthMovePhase};
    public GamePhase gamePhase;
    public bool canMove;

    void Awake()
    {
        if (instance != null) Destroy(this);
        DontDestroyOnLoad(this);
        uiHandler = FindObjectOfType<UI_Handler>();
    }

    private void Update()
    {
    }

    public void UpdateGamePhase(GamePhase newState)
    {
        gamePhase = newState;

        switch (newState)
        {
            case GamePhase.cardPhase:
                CanMove(false);
                break;
            case GamePhase.movePhase:
                CanMove(true);
                break;
            case GamePhase.labyrinthMovePhase:
                CanMove(false);
                break;
        }
        uiHandler.UpdateGamePhaseText();
    }

    public bool CanMove(bool canLaunch)
    {
        return canLaunch;
    }
}
