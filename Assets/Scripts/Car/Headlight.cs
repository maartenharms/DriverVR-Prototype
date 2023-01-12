using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GlobalEvents;

public class Headlight : Actor
{
    private GameObject[] lamps;

    private void Start()
    {
        lamps = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++) 
        {
            lamps[i] = transform.GetChild(i).gameObject;
        }
    }

    public void ToggleHeadlights()
    {
        GlobalEventManager.StartButtonEvent(GlobalEventManager.BUTTON.HEADLIGHT);
        actorCompleteEvent?.Invoke();

        bool isActive = lamps[0].activeSelf;

        foreach (GameObject _lamp in lamps) 
        {
            _lamp.SetActive(!isActive);
        }
    }

    public override void EventTrigger()
    {
        foreach (GameObject _lamp in lamps)
        {
            _lamp.SetActive(false);
        }
    }
}
