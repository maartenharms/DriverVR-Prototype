using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using GlobalEvents;
using TMPro;

public class TutorialEvent : MonoBehaviour
{
    public UnityAction onCompleteEvent;
    public TextMeshPro textObj;
    public AudioSource audioSource;

    public string tutorialText;
    public AudioClip voiceOver;

    public void Awake()
    {
        GameObject tutorialBox = GameObject.FindGameObjectWithTag("TutorialBox");
        textObj = tutorialBox.GetComponent<TextMeshPro>();
        audioSource = tutorialBox.GetComponent<AudioSource>();
    }

    // Start tutorial event
    public virtual void InitiateEvent()
    {
        textObj.text = tutorialText;
        audioSource.clip = voiceOver;
        audioSource.Play();
    }

    // Finish tutorial event
    public virtual void OnCompleteEvent()
    {
        audioSource.Stop();
        onCompleteEvent?.Invoke();
        onCompleteEvent = null;
        Debug.Log("event cleared");
    }
}
