using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using GlobalEvents;

public class Radio : Actor
{
    private AudioSource audioSource;
    public UnityAction onEventTrigger;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void ToggleRadio()
    {
        GlobalEventManager.StartButtonEvent(GlobalEventManager.BUTTON.RADIO);
        actorCompleteEvent?.Invoke();

        if (audioSource.isPlaying)
            audioSource.Stop();
        else
            audioSource.Play();
    }

    public override void EventTrigger() 
    {
        audioSource.Play();
    }
}