using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimController : MonoBehaviour
{
    private Animator animator;
    public float acceleration;

    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>();
        animator.speed = 0;
    }

    /* Debug Update
    void Update()
    {
        Debug.Log(animator.speed);
        if(Input.GetKeyDown(KeyCode.W))
            LerpAnimationSpeed(1);

        if(Input.GetKeyDown(KeyCode.S))
            LerpAnimationSpeed(0.3f);
    }
    */

    public void LerpAnimationSpeed(float targetSpeed)
    {
        if(animator.speed == targetSpeed)
            return;
        StopCoroutine("ChangeSpeed");
        StartCoroutine("ChangeSpeed", targetSpeed);  
    }

    public void SetAnimationSpeed(float _speed)
    {
        animator.speed = _speed;
    }

    IEnumerator ChangeSpeed(float targetSpeed) 
    {
        float startTime = Time.time;
        float speed = animator.speed;
        float distance = targetSpeed - speed;
        if(distance < 0)
            distance *= -1;

        while (animator.speed != targetSpeed) 
        {
            float progress = ((Time.time - startTime) * acceleration) / distance;
            animator.speed = Mathf.Lerp(speed, targetSpeed, progress);
            yield return null;
        }
    }
}
