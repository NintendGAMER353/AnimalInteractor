using UnityEngine;

public class Timer
{
    private float duration;
    private float startTime;
    public Timer(float duration)
    {
        this.duration = duration;
        startTime = Time.time;
    }

    public bool Finished
    {
        get { return Time.time > startTime + duration; }
    }

    public void Reset()
    {
        startTime = Time.time;
    }
}
