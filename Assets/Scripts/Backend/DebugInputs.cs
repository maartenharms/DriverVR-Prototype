using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Commands;
using Score;

public class DebugInputs : MonoBehaviour
{
    public GameObject car;

    public float turnSpeed = 45;
    private float turnLimit = 90;

    public int showScore;

    private UnityAction accelerateEvent;
    public UnityEvent toggleHeadlightEvent;
    public UnityEvent toggleRadioEvent;
    public UnityEvent playAnimation;

    private void Awake()
    {
        accelerateEvent += car.GetComponent<Car>().SlowdownCar;
    }

    // Update is called once per frame
    void Update()
    {
        float input = 0;
        //float acceleration = 1;

        if (Input.GetKey(KeyCode.A))
            input -= turnSpeed;

        if (Input.GetKey(KeyCode.D))
            input += turnSpeed;

        if (Input.GetKeyDown(KeyCode.S))
           accelerateEvent?.Invoke();

        if (Input.GetKeyDown(KeyCode.F))
            toggleHeadlightEvent?.Invoke();

        if (Input.GetKeyDown(KeyCode.R))
            toggleRadioEvent?.Invoke();

        if (Input.GetKeyDown(KeyCode.P))
            playAnimation.Invoke();

        //MoveActorCommand move = new MoveActorCommand(
        //    car.GetInstanceID(),
        //    new Vector3(input / turnLimit, 0, 0)
        //    );

        //move.Excecute();
        //accelerateEvent?.Invoke(acceleration);

        showScore = ScoreSystem.ScoreTotal;
    }
}
