using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GlobalEvents;

public class SpotTutorialEvent : TutorialEvent
{
    [SerializeField] private SpottableObject spotObject;

    public override void InitiateEvent()
    {
        spotObject.onCompleteTrigger += OnSpotObjectComplete;

        base.InitiateEvent();
    }

    private void OnSpotObjectComplete<T>(T argument) 
    {
        OnCompleteEvent();
    }
}
