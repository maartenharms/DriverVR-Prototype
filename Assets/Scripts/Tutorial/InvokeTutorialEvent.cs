using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InvokeTutorialEvent : TutorialEvent
{
    public UnityEvent tutorialEvent;

    private void Update()
    {
        if (onCompleteEvent == null)
            return;

        if (!audioSource.isPlaying)
            OnCompleteEvent();
    }

    public override void InitiateEvent()
    {
        base.InitiateEvent();
        tutorialEvent?.Invoke();
    }
}
