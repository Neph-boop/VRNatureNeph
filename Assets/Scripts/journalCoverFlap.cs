using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 -0.025 0 0
 0 0 0
 0.0125 0.25 0.185065
 */
public class journalCoverFlap : MonoBehaviour
{
    Quaternion closed = Quaternion.Euler( 0, 0, 0);
    public Transform journalTransform;
    public Transform coverTransform;
    public HingeJoint joint;
    //public JointMotor myMotor;
    //public JointLimits limits;

    private bool boolClosed;
    // Start is called before the first frame update
    void Start()
    {
        boolClosed = true;
    }

    // Update is called once per frame
    void Update()
    {
        //closed = Quaternion.Euler(journaltransform.rotation.x, transform.rotation.y, transform.rotation.z);
        if (boolClosed)
        {
            //closed = Quaternion.Euler(journalTransform.rotation.x, journalTransform.rotation.y, journalTransform.rotation.z);
            coverTransform.localRotation = closed;
        }
    }

    public void OnCloseJournal()
    {
        var motor = joint.motor;
        var limits = joint.limits;

        boolClosed = true;
        
        motor.targetVelocity = 0;
        motor.force = 0;
        limits.max = 0;

        joint.motor = motor;
        joint.limits = limits;
    }

    public void OnOpenJournal()
    {
        var motor = joint.motor;
        var limits = joint.limits;

        boolClosed = false;

        motor.targetVelocity = 500;
        motor.force = 1; 
        limits.max = 140;
        
        joint.motor = motor;
        joint.limits = limits;
    }
}
