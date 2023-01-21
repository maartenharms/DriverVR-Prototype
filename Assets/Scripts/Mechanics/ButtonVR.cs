using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonVR : MonoBehaviour
{
    [SerializeField] private Material pressMat;
    [SerializeField] private Material unpressMat;
    [SerializeField] private GameObject outlineObject;

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
        button.GetComponent<Renderer>().material = unpressMat;
        outlineObject.SetActive(false);
    }

    private void ButtonPress(Collider other)
    {
        if(!isPressed)
        {
            presser = other.gameObject;
            button.transform.localPosition = buttonPressedPos;
            audioSource.Play();
            button.GetComponent<Renderer>().material = pressMat;
            onPress.Invoke();
            isPressed = true;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("VRHandLeft"))
        {
            outlineObject.SetActive(true);
            if(OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.LTouch))
                ButtonPress(other);
        }

        if(other.CompareTag("VRHandRight"))
        {
            outlineObject.SetActive(true);
            if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
                ButtonPress(other);
        }
    }

    void OnTriggerExit(Collider other)
    {
        outlineObject.SetActive(false);

        if (other.gameObject == presser)
        {
            presser = null;
            button.transform.localPosition = buttonReleasePos;
            button.GetComponent<Renderer>().material = unpressMat;
            onRelease.Invoke();
            isPressed = false;
        }
    }
}
