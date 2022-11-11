using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePhaseManager : MonoBehaviour
{
    public static GamePhaseManager Instance;
    EventMethods eventMethods;
    Helper helper;

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
        helper = FindObjectOfType<Helper>();
    }

    //vilman juttu
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
        }
    }

    public void CardPhaseCheck()
    {
        if (Instance.gamePhase == GamePhase.cardPhase)
        {
            Instance.eventMethods.ActivateCardPhase();
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
                CardPhaseCheck();
                helper.uiHandler.ActivatePlayCardOrMovePanel();
                helper.uiHandler.UpdateGamePhaseText();
                break;
            case GamePhase.movePhase:
                helper.uiHandler.UpdateGamePhaseText();
                break;
            case GamePhase.labyrinthMovePhase:
                helper.uiHandler.UpdateGamePhaseText();
                Instance.eventMethods.MazeRotate();
                helper.mazeManager.EnableLabyrinthChange();
                break;
        }
    }
}
