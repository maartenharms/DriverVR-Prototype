using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InvokeTutorialEvent : TutorialEvent
{
    public UnityEvent tutorialEvent;

    public override void InitiateEvent()
    {
        tutorialEvent.Invoke();
        OnCompleteEvent();
    }
}
