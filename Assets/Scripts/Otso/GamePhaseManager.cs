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

    public enum GamePhase { cardPhase, movePhase, labyrinthMovePhase};
    public GamePhase gamePhase;

    void Awake()
    {
        if (instance != null) Destroy(this);
        DontDestroyOnLoad(this);
    }

    public void UpdateGamePhase(GamePhase newState)
    {
        gamePhase = newState;
    }
}
