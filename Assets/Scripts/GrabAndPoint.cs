using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class GrabAndPoint : MonoBehaviour
{
    public HandData leftHandPose;
    public HandData leftHandPoint;

    private Vector3 startHandPosition;
    private Vector3 finalHandPosition;
    
    private Quaternion startHandRotation;
    private Quaternion finalHandRotation;

    private Quaternion[] startFingerRotations;
    private Quaternion[] finalFingerRotations;

    // Start is called before the first frame update
    void Start()
    {
        XRGrabInteractable grabInteractable = GetComponent<XRGrabInteractable>();
    
        grabInteractable.selectEntered.AddListener(SetupPose);
        grabInteractable.selectExited.AddListener(UnSetPose);

        leftHandPoint.gameObject.SetActive(false);
    }

    public void SetupPose(BaseInteractionEventArgs arg)
    {
        if(arg.interactorObject is XRDirectInteractor){
            HandData handData = leftHandPose;
            handData.animator.enabled = false;
            
                SetHandDataValues(handData, leftHandPoint);

            SetHandData(handData, finalHandPosition, finalHandRotation, finalFingerRotations);
        }
    }

    public void UnSetPose(BaseInteractionEventArgs arg)
    {
        if(arg.interactorObject is XRDirectInteractor)
        {
            HandData handData = leftHandPose;
            handData.animator.enabled = true;
            
            SetHandData(handData, startHandPosition, startHandRotation, startFingerRotations);
        }
    }

    public void SetHandDataValues(HandData h1, HandData h2)
    {
        startHandPosition = h1.root.localPosition;
        finalHandPosition = h2.root.localPosition;

        startHandRotation = h1.root.localRotation;
        finalHandRotation = h2.root.localRotation;
        
        startFingerRotations = new Quaternion[h1.fingerBones.Length];
        finalFingerRotations = new Quaternion[h1.fingerBones.Length];

        for (int i = 0; i < h1.fingerBones.Length; i++)
        {
            startFingerRotations[i] = h1.fingerBones[i].localRotation;
            finalFingerRotations[i] = h2.fingerBones[i].localRotation;
        }


    }

    public void SetHandData(HandData h, Vector3 newPosition, Quaternion newRotation, Quaternion[] newBonesRotation)
    {
        h.root.localPosition = newPosition;
        h.root.localRotation = newRotation;

        for (int i = 0; i < newBonesRotation.Length; i++)
        {
            h.fingerBones[i].localRotation = newBonesRotation[i];
        }

    }

    /*
#if UNITY_EDITOR

    [MenuItem("Tools/Mirror Selected Right Grab Pose")]
    public static void MirrorRightPose()
    {
        GrabAndPose handPose = Selection.activeGameObject.GetComponent<GrabAndPose>();
        handPose.MirrorPose(handPose.leftHandPose, handPose.rightHandPose);
    }

#endif
    public void MirrorPose(HandData poseToMirror, HandData poseUsedToMirror)
    {
        Vector3 mirroredPosition = poseUsedToMirror.root.localPosition;
        mirroredPosition.x *= -1;

        Quaternion mirroredQuaternion = poseUsedToMirror.root.localRotation;
        mirroredQuaternion.y *= -1;
        mirroredQuaternion.z *= -1;

        poseToMirror.root.localPosition = mirroredPosition;
        poseToMirror.root.localRotation = mirroredQuaternion;

        for (int i = 0; i < poseUsedToMirror.fingerBones.Length; i++)
        {
            poseToMirror.fingerBones[i].localRotation = poseUsedToMirror.fingerBones[i].localRotation;
        }
    }
     */
}
