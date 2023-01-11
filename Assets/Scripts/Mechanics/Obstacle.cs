using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Obstacle : MonoBehaviour
{
    [SerializeField] public int pointValue = 0;

    public bool isCompleted;
    
    private bool isActivated = false;

    public UnityAction<int> onCompleteTrigger;
    public UnityAction onFailTrigger;

    public virtual void ToggleTrigger()
    {
        isActivated = !isActivated;
    }

    public virtual void CompleteTrigger() 
    {
        if(!isActivated)
        {
            FailTrigger();
            return;
        }

        if (!isCompleted)
        {
            Debug.Log("Trigger");
            onCompleteTrigger.Invoke(pointValue);
            isCompleted = true;
        }
    }

    public virtual void FailTrigger()
    {
        if(!isCompleted)
            onFailTrigger.Invoke();
    }
}