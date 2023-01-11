using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpottableObject : Obstacle
{
    [SerializeField] private float spotTime = 0;
    private float currentSpotTime = 0;

    private bool isSpotted = false;

    public override void Awake()
    {
        base.Awake();
        isActivated = true;
    }

    private void Update()
    {
        if (isCompleted)
            return;

        if (!isSpotted && currentSpotTime > 0) 
        {
            currentSpotTime -= 1 * Time.deltaTime;
            if (currentSpotTime < 0)
                currentSpotTime = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Spotter")
        {
            isSpotted = true;
            currentSpotTime += 1 * Time.deltaTime;
            if (currentSpotTime >= spotTime)
                CompleteTrigger();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Spotter")
            isSpotted = false;
    }
}
