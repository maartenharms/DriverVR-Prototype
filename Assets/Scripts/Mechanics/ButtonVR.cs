using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonVR : MonoBehaviour
{
    [SerializeField] private GameObject button;
    [SerializeField] public UnityEvent onPress;
    [SerializeField] public UnityEvent onRelease;
    private AudioSource audioSource;
    private GameObject presser;
    private bool isPressed;

    private Vector3 buttonReleasePos;
    [SerializeField] private Vector3 buttonPressedPos;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        isPressed = false;

        buttonReleasePos = button.transform.localPosition;
    }

    private void ButtonPress(Collider other)
    {
        if(!isPressed)
        {
            presser = other.gameObject;
            button.transform.localPosition = buttonPressedPos;
            audioSource.Play();
            onPress.Invoke();
            isPressed = true;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("VRHandLeft"))
        {
            if(OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.LTouch))
            ButtonPress(other);
        }

        if(other.CompareTag("VRHandRight"))
        {
            if(OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.RTouch))
            ButtonPress(other);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject == presser)
        {
            presser = null;
            button.transform.localPosition = buttonReleasePos;
            onRelease.Invoke();
            isPressed = false;
        }
    }
}
