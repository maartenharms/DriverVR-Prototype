using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GlobalEvents;

public class ButtonTutorialEvent : TutorialEvent
{
    [SerializeField] private GlobalEventManager.BUTTON listenToButton;

    public override void InitiateEvent()
    {
        GlobalEventManager.onButtonEvent += ButtonCheck;

        base.InitiateEvent();
    }

    private void ButtonCheck(GlobalEventManager.BUTTON button = GlobalEventManager.BUTTON.ANY) 
    {
        if (button == listenToButton)
            OnCompleteEvent();
    }
}
