using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Actor : MonoBehaviour
{
    public UnityAction actorCompleteEvent;

    public virtual void Awake()
    {
        gameObject.tag = "Actor";
    }

    public virtual void Move(Vector3 direction) 
    {
    // Actor specific movement code
    }

    public virtual void EventTrigger() 
    {
    
    }
}
