using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonVR : MonoBehaviour
{
    [SerializeField] private GameObject button;
    [SerializeField] private UnityAction onPress;
    [SerializeField] private UnityAction onRelease;
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

    void OnTriggerEnter(Collider other)
    {
        if(other.tag != "VRHandLeft" || other.tag != "VRHandRight")
            return;
        
        if(!isPressed)
        {
            presser = other.gameObject;
            button.transform.localPosition = buttonPressedPos;
            audioSource.Play();
            onPress.Invoke();
            isPressed = true;
        }
    }
}
