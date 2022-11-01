using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventMethods : MonoBehaviour
{
    [SerializeField] GameEvent OnResourceCollected;
    [SerializeField] GameEvent OnKeyCollected;
    [SerializeField] GameEvent OnBallLaunched;


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
}
