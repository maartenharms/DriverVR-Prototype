using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventTrigger : MonoBehaviour
{
    public UnityEvent activateEvent;
    public UnityEvent deactivateEvent;

    public void OnPlayerEnter() 
    {
        activateEvent.Invoke();
        Debug.Log("activate event");
    }

    public void OnPlayerExit()
    {
        deactivateEvent.Invoke();
        Debug.Log("deactivate event");
    }
}
