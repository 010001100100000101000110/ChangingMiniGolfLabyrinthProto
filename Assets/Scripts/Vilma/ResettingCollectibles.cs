using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResettingCollectibles : MonoBehaviour
{
    [SerializeField] GameObject[] keys;
    [SerializeField] GameObject[] resources;

    private void Start()
    {
        keys = GameObject.FindGameObjectsWithTag("Key");
        resources = GameObject.FindGameObjectsWithTag("Resource");
    }

    public void ResetCollected()
    {
        for (int i = 0; i < keys.Length; i++)
        {
            keys[i].SetActive(true);
        }

        for (int i = 0; i < resources.Length; i++)
        {
            resources[i].SetActive(true);
        }
    }


}
