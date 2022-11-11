using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventMethods : MonoBehaviour
{
    [SerializeField] GameEvent OnResourceCollected;
    [SerializeField] GameEvent OnKeyCollected;
    [SerializeField] GameEvent OnBallLaunched;
    [SerializeField] GameEvent OnBallStopped;
    [SerializeField] GameEvent OnTryAgain;
    [SerializeField] GameEvent OnChooseCard;
    [SerializeField] GameEvent OnCardChosen;
    [SerializeField] GameEvent OnMazeRotate;
    [SerializeField] GameEvent OnSwapCells;
    [SerializeField] GameEvent OnActivateCardPhase;
    [SerializeField] GameEvent OnRotateCell;
    [SerializeField] GameEvent OnFinish;
    [SerializeField] GameEvent OnCardPlayed;
    [SerializeField] GameEvent OnStopLabyrinthChange;
    [SerializeField] GameEvent OnTwoLaunchesInARow;

    public void ResourceCollected()
    {
        OnResourceCollected?.Raise();
    }

    public void KeyCollected()
    {
        OnKeyCollected?.Raise();
    }

    public void BallLaunched()
    {
        OnBallLaunched?.Raise();
    }

    public void BallStopped()
    {
        OnBallStopped?.Raise();
    }

    public void TryAgain()
    {
        OnTryAgain?.Raise();
    }

    public void ChooseCard()
    {
        OnChooseCard?.Raise();
    }

    public void CardChosen()
    {
        OnCardChosen?.Raise();
    }

    public void MazeRotate()
    {
        OnMazeRotate?.Raise();
    }

    public void SwapCells()
    {
        OnSwapCells?.Raise();
    }

    public void ActivateCardPhase()
    {
        OnActivateCardPhase?.Raise();
    }

    public void RotateCell()
    {
        OnRotateCell?.Raise();
    }

    public void Finish()
    {
        OnFinish?.Raise();
    }

    public void CardPlayde()
    {
        OnCardPlayed?.Raise();
    }

    public void StopLabyrinthChange()
    {
        OnStopLabyrinthChange?.Raise();
    }

    public void TwoLaunchesInARow()
    {
        OnTwoLaunchesInARow?.Raise();
    }
}
