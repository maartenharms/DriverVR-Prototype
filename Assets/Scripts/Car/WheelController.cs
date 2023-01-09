using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Commands;

public class WheelController : MonoBehaviour
{

    public GameObject leftHand;
    private Transform leftHandOriginalParent;
    private bool leftHandOnWheel = false;

    public GameObject rightHand;
    private Transform rightHandOriginalParent;
    private bool rightHandOnWheel = false;

    [SerializeField] private Transform[] snapPositions;

    public float currentWheelRotation;

    private Transform originalParent;
    public Transform directionalObject;

    private int turnLimit = 90;

    public GameObject car;

    // Start is called before the first frame update
    void Start()
    {
        leftHand = GameObject.FindGameObjectWithTag("VRHandLeft");
        leftHandOriginalParent = leftHand.transform.parent;

        rightHand = GameObject.FindGameObjectWithTag("VRHandRight");
        rightHandOriginalParent = rightHand.transform.parent;

        originalParent = transform.parent;
    }

    // Update is called once per frame
    void Update()
    {
        ReleaseHandsFromWheel();
        ConvertHandToWheelRoation();
        currentWheelRotation = -transform.rotation.eulerAngles.z;
        ConvertRotationToDirection();
    }

    private void ReleaseHandsFromWheel()
    {
        // Left Hand
        if (leftHandOnWheel && OVRInput.GetUp(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.LTouch))
        {
            leftHand.transform.parent = leftHandOriginalParent;
            leftHand.transform.position = leftHandOriginalParent.position;
            leftHand.transform.rotation = leftHandOriginalParent.rotation;
            leftHandOnWheel = false;
        }

        //Right Hand
        if (rightHandOnWheel && OVRInput.GetUp(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.RTouch))
        {
            rightHand.transform.parent = rightHandOriginalParent;
            rightHand.transform.position = rightHandOriginalParent.position;
            rightHand.transform.rotation = rightHandOriginalParent.rotation;
            rightHandOnWheel = false;
        }

        // If neither hand is on wheel, reset wheel parent
        if (!leftHandOnWheel && !rightHandOnWheel)
            transform.parent = originalParent;
    }

    private void ConvertHandToWheelRoation() 
    {
        if (!leftHandOnWheel && !rightHandOnWheel)
            return;
        
        // Get hand rotation in euler angles
        Quaternion newRotL = Quaternion.Euler(0, 0, leftHandOriginalParent.rotation.eulerAngles.z);
        Quaternion newRotR = Quaternion.Euler(0, 0, rightHandOriginalParent.rotation.eulerAngles.z);

        // If only the left hand is on the wheel
        if (leftHandOnWheel && !rightHandOnWheel)
            directionalObject.rotation = newRotL;

        // If only the right hand is on the wheel
        if (rightHandOnWheel && !leftHandOnWheel)
            directionalObject.rotation = newRotR;

        // If both hands are on the wheel
        if (leftHandOnWheel && rightHandOnWheel) 
        {
            // Create an average between the two rotation values
            Quaternion finalRot = Quaternion.Slerp(newRotL, newRotR, 0.5f);
            directionalObject.rotation = finalRot;
        }

        // Set parent to directional object
        transform.parent = directionalObject;
    }

    private void ConvertRotationToDirection()
    {
        float clampwheelrotation = Mathf.Clamp(currentWheelRotation,-turnLimit, turnLimit);
        Vector3 direction = Vector3.zero;
        direction.x = clampwheelrotation / turnLimit;

        MoveActorCommand move = new MoveActorCommand(
            car.GetInstanceID(),
            direction
            );

        move.Excecute();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("VRHandLeft") || other.CompareTag("VRHandRight")) 
        {
            // Left Hand
            if (!leftHandOnWheel && OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.LTouch)) 
            {
                PlaceHandOnWheel(ref leftHand, ref leftHandOriginalParent, ref leftHandOnWheel);
            }

            //Right Hand
            if (!rightHandOnWheel && OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.RTouch))
            {
                PlaceHandOnWheel(ref rightHand, ref rightHandOriginalParent, ref rightHandOnWheel);
            }
        }
    }

    private void PlaceHandOnWheel(ref GameObject hand, ref Transform originalParent, ref bool handOnWheel) 
    {
        // Default snap to first snap point
        // Save distance as current shortest
        float shortestDistance = Vector3.Distance(snapPositions[0].position, hand.transform.position);
        Transform bestSnap = snapPositions[0];

        // Itterate through all snap points
        foreach (Transform snapPoint in snapPositions) 
        {
            // If no hands are connected to this snap point
            if (snapPoint.childCount == 0) 
            {
                // Get the distance between snap point and hand
                float distance = Vector3.Distance(snapPoint.position, hand.transform.position);

                // Check if this distance is less the the first set distance
                if (distance < shortestDistance) 
                {
                    shortestDistance = distance;
                    bestSnap = snapPoint;
                }
            }
        }

        // Used to reset hands after release
        originalParent = hand.transform.parent;

        hand.transform.parent = bestSnap;
        hand.transform.position = bestSnap.position;

        handOnWheel = true;
    }
}
