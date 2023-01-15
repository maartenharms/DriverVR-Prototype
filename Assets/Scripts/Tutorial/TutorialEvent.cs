using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using GlobalEvents;

public class TutorialEvent : MonoBehaviour
{
    private GameObject[] tutorialObjects;
    public UnityAction onCompleteEvent;

    public void Awake()
    {
        // Find all childed gameobjects
        // and save the refferences in an array
        tutorialObjects = new GameObject[transform.childCount];
        for(int i = 0; i < transform.childCount; i++)
        {
            tutorialObjects[i] = transform.GetChild(i).gameObject;
        }

        // Disable child objects
        ToggleTutorialObjects(false);
    }

    // Start tutorial event
    public virtual void InitiateEvent()
    {
        // Enable child objects
        ToggleTutorialObjects(true);
    }

    // Finish tutorial event
    public virtual void OnCompleteEvent()
    {
        ToggleTutorialObjects(false);
        onCompleteEvent?.Invoke();
        onCompleteEvent = null;
        Debug.Log("event cleared");
    }

    // Enable or disable all childed gameobjects
    public void ToggleTutorialObjects(bool isActive)
    {
        foreach(GameObject obj in tutorialObjects)
        {
            obj.SetActive(isActive);
        }
    }
}
