using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collisions : MonoBehaviour
{
    EventMethods eventMethods;
    private void Awake()
    {
        eventMethods = FindObjectOfType<EventMethods>();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Key")
        {
            collider.gameObject.SetActive(false);
            eventMethods.KeyCollected();
        }
        if (collider.gameObject.tag == "Resource")
        {
            collider.gameObject.SetActive(false);
            eventMethods.ResourceCollected();
        }
        if (collider.gameObject.tag == "Finish")
        {
            
        }
    }
}
