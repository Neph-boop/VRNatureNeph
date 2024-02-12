using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class LeftHandPointer : MonoBehaviour
{
    private LineRenderer line;
    public Transform lineOrigin;
    public Transform lineDestination;
    private Vector3 lineDirection;
    private Ray ray;
    private float maxDist = 10f;
    private RaycastHit hit;
    private RaycastHit journalHit;
    public LayerMask hitLayer;
    public LayerMask maskLayer;
    private bool isPointer;

    private bool isPressed;

    public InputActionProperty leftActivate;

    //public DragMe dragMe;
    public hoverScroll hoverUp;
    public hoverScroll hoverDown;

    public UnityEvent leftActivation; 
    public UnityEvent leftContinuation;
    public UnityEvent leftDeactivation;

    //public ProgressManager progressManager;

    // Start is called before the first frame update
    void Start()
    {
        line = GetComponent<LineRenderer>();
        line.enabled = false;
        isPointer = false;
    }


    // Update is called once per frame
    void Update()
    {
        if (isPointer)
        {
            getLineDirection();
            rayHitCheck();

            if (hit.collider != null)
            {
                if (hit.collider.gameObject.tag.Equals("ScrollUp"))
                {
                    hoverUp.startScroll();
                }
                if (hit.collider.gameObject.tag.Equals("ScrollDown"))
                {
                    hoverDown.startScroll();
                }
            }

            if(leftActivate.action.IsPressed() && !isPressed)
            {
                isPressed = true;
                leftActivation.Invoke(); // Called once Pressed
            }
            else if (leftActivate.action.IsPressed() && isPressed)
            {
                isPressed = true;
                leftContinuation.Invoke(); // Called while Held
            }
            if(!leftActivate.action.IsPressed())
            {
                isPressed = false;
                leftDeactivation.Invoke(); // Called once Released
            }
        }


        if (line.enabled)
        {
            line.SetPosition(0, lineOrigin.position);
            line.SetPosition(1, hit.point);
        }
    }

    public Vector3 getHitPoint()
    {
        return hit.point;
    }

    public Collider getJournalHitCollider()
    {
        return journalHit.collider;
    }

    public void TurnOnPointer()
    {
        isPointer = true;
        //line.enabled = true;

    }
    public void TurnOffPointer()
    {
        isPointer = false;
        line.enabled = false;
    }

    public void getLineDirection()
    {
        lineDirection = lineDestination.position - lineOrigin.position;
        lineDirection.Normalize();
    }

    public void rayHitCheck()
    {
        ray = new Ray(lineOrigin.position, lineDirection);
        if (Physics.Raycast(ray, out hit, maxDist, maskLayer, QueryTriggerInteraction.Collide)) //If hitting Journal/UI(within Mask)
        {
            line.enabled = true;
            Physics.Raycast(ray, out journalHit, maxDist, hitLayer, QueryTriggerInteraction.Collide); //If hitting Journal/Stencil
        }
        else
            line.enabled = false;
    }
    public bool getIsPressed()
    {
        return isPressed;
    }
}
