using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpottingHeadtrack : MonoBehaviour
{
    private GameObject spotObject;

    // Start is called before the first frame update
    void Start()
    {
        spotObject = Instantiate(Resources.Load<GameObject>("Prefabs/DebugSpotter"));
        spotObject.transform.position = this.transform.position;
        spotObject.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        bool isSpotting = false;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward,out hit, 1000)) 
        {
            if(hit.transform.CompareTag("Obstacle"))
            {
            spotObject.transform.position = hit.point;
            isSpotting = true;
                    
            }
        }

        Debug.Log(hit.transform.name);
        spotObject.SetActive(isSpotting);
    }
}
