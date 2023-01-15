using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GlobalEvents;

public class Car : Actor
{
    private Animator animator;

    [SerializeField]
    private float carSpeed = 0;

    private float acceleration = 1;
    [SerializeField] private float maxAcceleration = 1;
    [SerializeField] private float minAcceleration = 0.5f;

    public override void Awake()
    {
        base.Awake();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    
    void Update()
    {
        Vector3 newMovement = new Vector3(0,0,1);
        Move(newMovement);
        //animator.speed = carSpeed;
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

    public void SetCarSpeed(float newSpeed) 
    {
        carSpeed = newSpeed;

        if (carSpeed == newSpeed)
            return;

        StartCoroutine("ChangeSpeed", newSpeed);               
    }

    IEnumerator ChangeSpeed(float newSpeed) 
    {
        float distance = newSpeed - carSpeed;
        float startTime = Time.time;
        float startSpeed = carSpeed;

        while (carSpeed != newSpeed) 
        {
            float progress = ((Time.time - startTime) * acceleration) / distance;
            carSpeed = Mathf.Lerp(startSpeed, newSpeed, progress);
            yield return null;
        }
    }
}
