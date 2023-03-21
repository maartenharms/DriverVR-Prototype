using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringWheelControll : MonoBehaviour
{
    public GameObject rightHand;
    private Transform rightHandOriginalParent;
    private bool rightHandOnWheel = false;

    public GameObject leftHand;
    private Transform leftHandOriginalParent;
    private bool leftHandOnWheel = false;

    public Transform[] snappPositions;

    public float currentSteeringWheelRotation = 0;

    public Transform directionalObject;

    private void Update()
    {
        ReleaseHandsFromWheel();

        ConvertHandRotationToSteeringWheelRotation();

        currentSteeringWheelRotation = -transform.rotation.eulerAngles.z;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("VRHandLeft"))
        {


            if (leftHandOnWheel == false && OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.LTouch))
            {
                PlaceHandOnWheel(ref leftHand, ref leftHandOriginalParent, ref leftHandOnWheel);
            }
        }    

        if (other.CompareTag("VRHandRight"))
        {
            if (rightHandOnWheel == false && OVRInput.GetDown (OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.RTouch))
            {
                PlaceHandOnWheel(ref rightHand, ref rightHandOriginalParent, ref rightHandOnWheel);
            }
        }
    }

    private void ReleaseHandsFromWheel()
    {
        if (rightHandOnWheel == true && OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.RTouch))
        {

            rightHand.transform.parent = rightHandOriginalParent;
            rightHand.transform.position = rightHandOriginalParent.position;
            rightHand.transform.rotation = rightHandOriginalParent.rotation;
            rightHandOnWheel = false;
        }

        if (leftHandOnWheel == true && OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.LTouch))
        {
            leftHand.transform.parent = leftHandOriginalParent;
            leftHand.transform.rotation = leftHandOriginalParent.rotation;
            leftHand.transform.position = leftHandOriginalParent.position;
            leftHandOnWheel = false;
        }

        if (leftHandOnWheel == false && rightHandOnWheel == false)
        {
            transform.parent = transform.root;
        }    
    }
    private void PlaceHandOnWheel(ref GameObject hand, ref Transform originalParent, ref bool handOnWheel)
    {
        var shortestDistance = Vector3.Distance(snappPositions[0].position, hand.transform.position);
        var bestSnapp = snappPositions[0];

        foreach (var snappPosition in snappPositions)
        {
            if (snappPosition.childCount == 0)
            {
                var distance = Vector3.Distance(snappPosition.position, hand.transform.position);

                if (distance < shortestDistance)
                {
                    shortestDistance = distance;
                    bestSnapp = snappPosition;
                }    
            }
        }
        originalParent = hand.transform.parent;


        hand.transform.parent = bestSnapp.transform;
        hand.transform.position = bestSnapp.transform.position;

        handOnWheel = true;
    }

    private void ConvertHandRotationToSteeringWheelRotation()
    {
        if (rightHandOnWheel == true && leftHandOnWheel == false)
        {
            Quaternion newRot = Quaternion.Euler(0, 0, rightHandOriginalParent.transform.rotation.eulerAngles.z);
            directionalObject.rotation = newRot;
            transform.parent = directionalObject;
        }
        else
        if (rightHandOnWheel == false && leftHandOnWheel == true)
        {
            Quaternion newRot = Quaternion.Euler(0, 0, leftHandOriginalParent.transform.rotation.eulerAngles.z);
            directionalObject.rotation = newRot;
            transform.parent = directionalObject;
        }    
        else
        if (rightHandOnWheel == true && leftHandOnWheel == true)
        {
            Quaternion newRotLeft = Quaternion.Euler(0, 0, leftHandOriginalParent.transform.rotation.eulerAngles.z);
            Quaternion newRotRight = Quaternion.Euler(0, 0, rightHandOriginalParent.transform.rotation.eulerAngles.z);
            Quaternion finalRot = Quaternion.Slerp(newRotLeft, newRotRight, 1.0f / 2.0f);
            directionalObject.rotation = finalRot;
            transform.parent = directionalObject;
        }
    }
}
