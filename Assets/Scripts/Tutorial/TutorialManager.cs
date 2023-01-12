using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using GlobalEvents;

public class TutorialManager : MonoBehaviour
{
    private TutorialEvent[] tutorialEvents;
    private int tutorialNum = 0;

    void Start()
    {
        tutorialEvents = new TutorialEvent[transform.childCount];
        Debug.Log(transform.childCount);
        for(int i = 0; i < transform.childCount; i++)
        {
            tutorialEvents[i] = transform.GetChild(i).GetComponent<TutorialEvent>();
        }
        NextTutorialEvent();
    }

    private void NextTutorialEvent()
    {
        tutorialEvents[tutorialNum].InitiateEvent();
        tutorialEvents[tutorialNum].onCompleteEvent += OnCompleteEvent;
        tutorialNum++;
    }

    public void OnCompleteEvent()
    {
        if(tutorialNum < tutorialEvents.Length)
            NextTutorialEvent();
    }
}
