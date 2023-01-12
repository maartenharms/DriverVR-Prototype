using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using GlobalEvents;

public class TutorialEvent : MonoBehaviour
{
    [SerializeField] private GlobalEventManager.BUTTON listenToButton;

    private GameObject[] tutorialText;
    public UnityAction onCompleteEvent;

    public void Awake()
    {
        tutorialText = new GameObject[transform.childCount];
        for(int i = 0; i < transform.childCount; i++)
        {
            tutorialText[i] = transform.GetChild(i).gameObject;
        }

        ToggleTutorialText(false);
    }

    public virtual void InitiateEvent()
    {
        GlobalEventManager.onButtonEvent += OnCompleteEvent;

        ToggleTutorialText(true);
    }

    public virtual void OnCompleteEvent(GlobalEventManager.BUTTON button = GlobalEventManager.BUTTON.ANY)
    {
        if(button == listenToButton)
        {
            ToggleTutorialText(false);
            onCompleteEvent?.Invoke();
            onCompleteEvent = null;
        }
    }

    public void ToggleTutorialText(bool isActive)
    {
        foreach(GameObject obj in tutorialText)
        {
            obj.SetActive(isActive);
        }
    }
}
