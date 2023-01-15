using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimController : MonoBehaviour
{
    private Animator animator;

    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>();
        animator.speed = 0.3f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
