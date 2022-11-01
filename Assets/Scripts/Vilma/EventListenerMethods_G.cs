using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventListenerMethods_G : MonoBehaviour
{
    [SerializeField] GameEvent OnBallLaunched;
    [SerializeField] GameEvent OnBallStopped;
    [SerializeField] GameEvent OnBallTeleported;
    [SerializeField] GameEvent OnGameFinished;
    [SerializeField] GameEvent OnRetry;
    [SerializeField] GameEvent OnChargesDrained; //

    public void BallLaunched()
    {
        OnBallLaunched?.Raise();
    }
    public void BallStopped()
    {
        OnBallStopped?.Raise();
    }
    public void BallTeleported()
    {
        OnBallTeleported?.Raise();
    }
    public void GameFinished()
    {
        OnGameFinished?.Raise();
    }
    public void Retry()
    {
        OnRetry?.Raise();
    }

    public void ChargesDrained() //
    {
        OnChargesDrained?.Raise(); //
    }
}
