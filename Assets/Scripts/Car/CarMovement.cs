using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public float movementSpeed;
    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 newMovement = new Vector3(0,0,movementSpeed);
        transform.position += newMovement;
    }
}
