using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObstacleEvent : Obstacle
{
    public Actor actor;

    public override void ToggleTrigger()
    {
        base.ToggleTrigger();

        actor.EventTrigger();
        actor.actorCompleteEvent += CompleteTrigger;
    }
}
