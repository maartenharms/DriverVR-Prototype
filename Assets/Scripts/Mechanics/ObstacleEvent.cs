using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObstacleEvent : Obstacle
{
    public UnityEvent obstacleEvent;

    public override void ToggleTrigger()
    {
        base.ToggleTrigger();

        obstacleEvent.Invoke();
    }
}
