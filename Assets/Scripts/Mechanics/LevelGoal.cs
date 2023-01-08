using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelGoal : MonoBehaviour
{
    public UnityAction onReachingGoal;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") 
        {
            onReachingGoal.Invoke();
        }
    }
}
