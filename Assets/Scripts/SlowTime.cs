using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowTime : MonoBehaviour
{

    private float fixedTime;
    private float deltaTime;

    [SerializeField] private float newFixedTime;
    [SerializeField] private float newDeltaTime;

    // Start is called before the first frame update
    void Start()
    {
        fixedTime = Time.fixedDeltaTime;
        deltaTime = Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = newDeltaTime;
        Time.fixedDeltaTime = fixedTime * Time.timeScale;

    }
}
