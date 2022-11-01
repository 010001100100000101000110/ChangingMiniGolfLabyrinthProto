using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    public void TurnCameraRight()
    {
        transform.rotation *= Quaternion.Euler(0, -90, 0);
    }
    public void TurnCameraLeft()
    {
        transform.rotation *= Quaternion.Euler(0, 90, 0);
    }

}
