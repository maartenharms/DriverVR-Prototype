using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Obstacle : MonoBehaviour
{
    [SerializeField] public int pointValue = 0;

    public bool isCompleted;

    public UnityAction<int> onCompleteTrigger;

    public virtual void CompleteTrigger() 
    {
        if (!isCompleted)
        {
            Debug.Log("Trigger");
            onCompleteTrigger.Invoke(pointValue);
            isCompleted = true;
        }
    }
}
