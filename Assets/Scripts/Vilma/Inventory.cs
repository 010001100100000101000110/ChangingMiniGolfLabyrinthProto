using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int KeysCollected { get; private set; }
    public int ResourcesCollected { get; private set; }

    public void AddToKeysCollected()
    {
        KeysCollected++;
    }
    public void AddToResourcesCollected()
    {
        ResourcesCollected++;
    }
}
