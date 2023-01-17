using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GlobalEvents;

public class Car : Actor
{
    public AnimController animator;

    [SerializeField]
    private float carSpeed = 0;

    private float acceleration = 1;
    [SerializeField] private float maxAcceleration = 1;
    [SerializeField] private float minAcceleration = 0.5f;

    public override void Awake()
    {
        base.Awake();
        animator.SetAnimationSpeed(carSpeed);
    }

    // Update is called once per frame
    
    void Update()
    {
        //Vector3 newMovement = new Vector3(0,0,1);
        //Move(newMovement);
    }

    public void SlowdownCar()
    {
        GlobalEventManager.StartButtonEvent(GlobalEventManager.BUTTON.BREAK);

        if(carSpeed == minAcceleration)
            SetCarSpeed(maxAcceleration);
        else if(carSpeed == maxAcceleration)
            SetCarSpeed(minAcceleration);
    }
    
    public void SetCarSpeed(float newSpeed) 
    {
        Debug.Log("Set Speed");
        carSpeed = newSpeed;

        animator.LerpAnimationSpeed(newSpeed);
    }

    public override void Move(Vector3 direction)
    {
        float timeMovement = carSpeed*Time.deltaTime;
        transform.position += direction * (timeMovement*acceleration);
    }

    public void Accelerate(float accelerate) 
    {
        if(accelerate < 1)
            GlobalEventManager.StartButtonEvent(GlobalEventManager.BUTTON.BREAK);
          
        acceleration = Mathf.Clamp(accelerate, minAcceleration, maxAcceleration);
    }    
}
