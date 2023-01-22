using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpottableObject : Obstacle
{
    [SerializeField] private float spotTime = 0;
    private float currentSpotTime = 0;

    private bool isSpotted = false;

    private bool hasOutline = false;
    [SerializeField] private GameObject outlineObject;
    private Material outlineMat;

    public override void Awake()
    {
        base.Awake();
        isActivated = true;
        if (outlineObject != null)
            hasOutline = true;

        if (hasOutline) 
        {
            outlineMat = outlineObject.GetComponent<Renderer>().material;
            outlineObject.SetActive(false);
        }
        
    }

    private void Update()
    {
        if (isCompleted)
            return;

        if (!isSpotted && currentSpotTime > 0) 
        {
            ChangeOutlineColor(Color.red, Color.green, (currentSpotTime / spotTime));
            currentSpotTime -= 1 * Time.deltaTime;
            if (currentSpotTime < 0)
                currentSpotTime = 0;
        }
    }

    private void ChangeOutlineColor(Color startColor, Color endColor, float progress) 
    {
        if (!hasOutline)
            return;
        Color newColor = Color.Lerp(startColor, endColor, progress);
        outlineMat.color = newColor;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Spotter")
        {
            if(hasOutline)
                outlineObject.SetActive(true);

            isSpotted = true;
            currentSpotTime += 1 * Time.deltaTime;
            ChangeOutlineColor(Color.red, Color.green, (currentSpotTime/spotTime));
            if (currentSpotTime >= spotTime)
                CompleteTrigger();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Spotter") 
        {
            if(hasOutline)
                outlineObject.SetActive(false);

            isSpotted = false;
        }
    }
}
