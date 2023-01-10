using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour
{
    private void Awake()
    {
        gameObject.tag = "Actor";
    }

    public virtual void Move(Vector3 direction) 
    {
    // Actor specific movement code
    }
}
