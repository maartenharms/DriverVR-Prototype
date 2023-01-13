using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GlobalEvents;

public class Car : Actor
{
    [SerializeField]
    private float movementSpeed = 0;

    private float acceleration = 1;
    [SerializeField] private float maxAcceleration = 1;
    [SerializeField] private float minAcceleration = 0.5f;

    // Update is called once per frame
    void Update()
    {
        Vector3 newMovement = new Vector3(0,0,1);
        Move(newMovement);
    }

    public override void Move(Vector3 direction)
    {
        float timeMovement = movementSpeed*Time.deltaTime;
        transform.position += direction * (timeMovement*acceleration);
    }

    public void Accelerate(float accelerate) 
    {
        if(accelerate < 1)
            GlobalEventManager.StartButtonEvent(GlobalEventManager.BUTTON.BREAK);
            
        acceleration = Mathf.Clamp(accelerate, minAcceleration, maxAcceleration);
    }
}
