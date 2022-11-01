using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchTracker : MonoBehaviour
{
    public int launchesLeft { get; private set; }
    [SerializeField] int launchCapacity;

    void Awake()
    {
        ResetLaunches();
    }
    public void SubtractFromLaunches()
    {
        launchesLeft--;
    }
    public void AddToLaunches(int amount)
    {
        launchesLeft += amount;
    }
     public void ResetLaunches()
    {
        launchesLeft = launchCapacity;
    }
}
