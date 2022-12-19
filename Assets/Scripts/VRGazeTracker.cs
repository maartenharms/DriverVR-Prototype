using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VRGazeTracker : MonoBehaviour
{

    public TextMeshPro tmp;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position,transform.forward, out hit, 20))
        {
            Vector3 offset = new Vector3(0,0.01f,0);
            //Debug.DrawRay(transform.position + offset, -transform.forward, Color.blue, 1);
            Debug.DrawRay(transform.position + offset, transform.forward, Color.blue, 0.1f);
            if(tmp != null)
                tmp.text = hit.transform.name;
        }
    }
}
