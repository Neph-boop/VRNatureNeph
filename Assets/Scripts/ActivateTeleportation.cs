using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ActivateTeleportation : MonoBehaviour
{
    public InputActionProperty leftMoveListen;
    public InputActionProperty leftMoveActivate;
    private Vector2 vectorValue;
    public GameObject leftTeleportation;


    // Update is called once per frame
    void Update()
    {
        vectorValue = leftMoveListen.action.ReadValue<Vector2>();
            leftTeleportation.SetActive(vectorValue.sqrMagnitude > 0.1 );
    }
}
