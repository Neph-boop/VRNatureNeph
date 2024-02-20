using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
//using UnityEngine.InputSystem.Controls;
//using UnityEngine.XR.Interaction.Toolkit.Inputs;

public class MyLeftController : MonoBehaviour
{

    
    private bool primaryBPressed;
    [SerializeField]
    InputActionProperty primaryButton;
    [SerializeField] 
    private UnityEvent primaryButtonOnPressTrigger;
    [SerializeField] 
    private UnityEvent primaryButtonOnHoldTrigger;
    

    private bool secondaryBPressed;
    [SerializeField]
    InputActionProperty secondaryButton;
    [SerializeField] 
    private UnityEvent secondaryButtonOnPressTrigger;
    [SerializeField] 
    private UnityEvent secondaryButtonOnHoldTrigger;

    private float primaryButtonState;
    private float secondaryButtonState;
    
    private void Awake()
    {
        primaryBPressed = false;
        secondaryBPressed = false;
    }

    private void OnPrimaryButtonPress()
    {
        primaryButtonOnPressTrigger.Invoke();
    }
    private void OnPrimaryButtonHold()
    {
        primaryButtonOnHoldTrigger.Invoke();
    }
    private void OnSecondaryButtonPress()
    {
        secondaryButtonOnPressTrigger.Invoke();
    }
    private void OnSecondaryButtonHold()
    {
        secondaryButtonOnHoldTrigger.Invoke();
    }

    public void DebugPrimaryPRESS(){
        Debug.Log("Primary Button Pressed");
    }

    void Update()
    {
        primaryButtonState = primaryButton.action.ReadValue<float>();
        if (primaryButtonState == 1)
        {
            if(!primaryBPressed)
            {
                OnPrimaryButtonPress();
                primaryBPressed = true;
            }
            else if(primaryBPressed)
            {
                OnPrimaryButtonHold();
            }
        }
        else
        {
            primaryBPressed = false;
        }
        secondaryButtonState = secondaryButton.action.ReadValue<float>();
        if (secondaryButtonState == 1)
        {
            if(!secondaryBPressed)
            {
                OnSecondaryButtonPress();
                primaryBPressed = true;
            }
            else if(secondaryBPressed)
            {
                OnSecondaryButtonHold();
            }
        }
    }
}
