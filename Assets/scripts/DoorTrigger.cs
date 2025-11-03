using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : DetectionZone
{

    public string DoorOpenAnimatorParamName = "DoorOpen";
    Animator animator;


    void Start()
    {
            animator = GetComponent<Animator>(); 
    }

    void Update()
    {
        if(detectedObjs.Count > 0)
        {
            animator.SetBool(DoorOpenAnimatorParamName, true);
        }
        else
        {
            animator.SetBool (DoorOpenAnimatorParamName, false);
        }
        
    }
}
