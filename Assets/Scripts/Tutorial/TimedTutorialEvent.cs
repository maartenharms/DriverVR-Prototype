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
        ToggleTutorialText(true);
        timerStarted = true;
    }

    void Update()
    {
        if(timerStarted)
        {
            Debug.Log(timer);
            timer += 1*Time.deltaTime;
            if(timer > tutorialTimer)
            {
                timerStarted = false;
                OnCompleteEvent();
            }
        }
    }

    public override void OnCompleteEvent(GlobalEventManager.BUTTON button = GlobalEventManager.BUTTON.ANY)
    {
        ToggleTutorialText(false);
        onCompleteEvent?.Invoke();
        onCompleteEvent = null;
    }
}
