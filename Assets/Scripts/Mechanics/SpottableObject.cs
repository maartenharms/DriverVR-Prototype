using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpottableObject : Obstacle
{
    [SerializeField] private float spotTime = 0;
    private float currentSpotTime = 0;

    private bool isSpotted = false;

    [SerializeField] private GameObject outlineObject;
    private Material outlineMat;

    public override void Awake()
    {
        base.Awake();
        isActivated = true;
        outlineMat = outlineObject.GetComponent<Renderer>().material;
        outlineObject.SetActive(false);
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
        Color newColor = Color.Lerp(startColor, endColor, progress);
        outlineMat.color = newColor;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Spotter")
        {
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
            outlineObject.SetActive(false);
            isSpotted = false;
        }
    }
}
