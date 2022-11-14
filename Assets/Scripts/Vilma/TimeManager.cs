using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public void SetTimeScaleTo(int scale)
    {
        Time.timeScale = scale;
    }

}
