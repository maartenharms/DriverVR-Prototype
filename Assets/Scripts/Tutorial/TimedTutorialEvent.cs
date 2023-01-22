using System.Collections;
using System.Collections.Generic;
using GlobalEvents;
using UnityEngine;

public class TimedTutorialEvent : TutorialEvent
{
    [SerializeField] private float tutorialTimer;
    private float timer = 0;

    private bool timerStarted = false;

    public override void InitiateEvent()
    {
        timerStarted = true;

        base.InitiateEvent();
    }

    void Update()
    {
        if(timerStarted)
        {
            timer += 1*Time.deltaTime;
            if(timer > tutorialTimer)
            {
                timerStarted = false;
                OnCompleteEvent();
            }
        }
    }
}
