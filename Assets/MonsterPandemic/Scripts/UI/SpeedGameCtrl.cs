using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedGameCtrl : ComponentBehavior
{
    private static SpeedGameCtrl instance;
    [SerializeField] private float preSpeed;

    public static SpeedGameCtrl Instance => instance;
    protected override void Awake()
    {
        if(instance != null) 
            Debug.LogError("Only 1 speedGameCtrl allow to exist");
        instance = this;
        preSpeed = 1;
    }

    public void StopGame()
    {
        SetSpeedGame(0);
    }

    public void ContinuePreviousSpeed()
    {
        Time.timeScale = preSpeed;
    }

    public void SetSpeedGame(float newSpeed)
    {
        if(Time.timeScale != 0)
            preSpeed = Time.timeScale;
        Time.timeScale = newSpeed;
    }
}
