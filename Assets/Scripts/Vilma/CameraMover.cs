using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    public void TurnCameraRight()
    {

        this.transform.Rotate(this.transform.rotation.x, this.transform.rotation.y - 90, this.transform.rotation.z, Space.Self);
        Debug.Log("KIKIKAKA");
    }
    public void TurnCameraLeft()
    {
        this.transform.Rotate(this.transform.rotation.x, this.transform.rotation.y + 90, this.transform.rotation.z, Space.Self);
    }

}
