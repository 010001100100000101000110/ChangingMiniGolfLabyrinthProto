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
}
