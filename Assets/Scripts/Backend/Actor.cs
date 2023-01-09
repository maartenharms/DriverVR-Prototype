using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour
{
    private void Awake()
    {
        gameObject.tag = "Actor";
        Debug.Log(gameObject.GetInstanceID());
    }

    public virtual void Move(Vector3 direction) 
    {
    // Actor specific movement code
    }
}
