using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deer : MonoBehaviour
{
	public float Speed;
	public Animator Animator;
	public bool IsIdling;
    
    void Update()
    {
		if(IsIdling)
		{
			Animator.SetBool("Idle", true);
		}
		else
		{
			var velocity = Vector3.forward * Speed;
			transform.Translate(velocity * Time.deltaTime);
			Animator.SetBool("Idle", false);
		}
    }
}
