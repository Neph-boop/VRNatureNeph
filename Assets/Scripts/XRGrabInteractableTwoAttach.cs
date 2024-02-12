using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XRGrabInteractableTwoAttach : XRGrabInteractable
{
    private float repairer;
    public Transform leftAttachTransform;
    public Transform rightAttachTransform;
    private SelectEnterEventArgs prevArgs;

    protected override void Awake()
    {
        repairer = 0;
        base.Awake();
    }
    
    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        prevArgs = args;
        CompareHands(args);
        repairer = 5;
        base.OnSelectEntered(args);
    }

    private void CompareHands(SelectEnterEventArgs args)
    {     
        if (args.interactorObject.transform.CompareTag("LeftHand"))
        {
            attachTransform = leftAttachTransform;
        }
        else if (args.interactorObject.transform.CompareTag("RightHand"))
        {
            attachTransform = rightAttachTransform;
        }
    }

    private void Update()
    {
        if (repairer > 1)
        {
            repairer -= 1;
        }
        else if (repairer == 1)
        {
            repairer -= 1;
            base.OnSelectEntered(prevArgs);
        }   
    }

}
