using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController
{
    public void StopTime()
    {
        Time.timeScale = 0f;
    }

    public void ResumeTime()
    {
        Time.timeScale = 1f;
    }
}
