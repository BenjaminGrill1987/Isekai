using System;
using UnityEngine;

public class Timer
{
    private float currentTime, startTime;
    public float CurrentTime => currentTime;
    public float StartTime => startTime;
    private Action _action;


    public Timer(float newStartTime, Action action)
    {
        currentTime = newStartTime;
        startTime = newStartTime;
        _action = action;
    }

    public void Tick()
    {
        currentTime -= Time.fixedDeltaTime;

        if (currentTime <= 0f)
        {
            _action?.Invoke();
            ResetTimer();
        }
    }

    public void ResetTimer()
    {
        currentTime = startTime;
    }

    public void TimerUpdate(float newStartTime)
    {
        currentTime = newStartTime;
        startTime = newStartTime;
    }
}
