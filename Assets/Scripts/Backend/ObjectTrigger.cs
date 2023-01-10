using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObjectTrigger : MonoBehaviour
{
    public UnityEvent triggerEnter;
    public UnityEvent triggerExit;

    public string checkForTag = "";

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag(checkForTag))
            return;

        triggerEnter.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag(checkForTag))
            return;

        triggerExit.Invoke();
    }
}