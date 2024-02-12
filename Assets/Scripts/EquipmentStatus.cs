using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EquipmentStatus : MonoBehaviour
{
    [SerializeField] private UnityEvent GrabbingTrigger;
    [SerializeField] private UnityEvent LetGoTrigger;


    // Snap Attach
    public GameObject SnapAttach;

    // Basic Status
    public bool grabbed;
    public bool holstered;

    // Auto Holster
    public float holsterCooldownMax = 5;
    private float holsterCooldown = 0;

    private void Awake()
    {
        grabbed = false;
        holstered = true;
    }

    // GRABBING 
    public void IsGrabbed()
    {
        if (grabbed!)
        {
            GrabbingTrigger.Invoke();
        }
        grabbed = true;


        holsterCooldown = holsterCooldownMax;
        holstered = false;
    }
    public void IsNotGrabbed()
    {
        grabbed = false;
    }
    public bool GrabbedStatus()
    {
        return grabbed;
    }


    // HOLSTERING
    public void IsHolstered()
    {
        LetGoTrigger.Invoke();
        holstered = true;
    }
    public bool HolsteredStatus()
    {
        return holstered;
    }
    private void HolsteringScript()
    {
        transform.position = new Vector3(SnapAttach.transform.position.x, SnapAttach.transform.position.y, SnapAttach.transform.position.z);
        transform.rotation = SnapAttach.transform.rotation;
    }

    // UPDATE
    void Update()
    {
        if ((!grabbed) && (!holstered)){
            if(holsterCooldown > 0){
                holsterCooldown -= Time.deltaTime;
            }
            else if(holsterCooldown <= 0){
                //Holster Camera
                IsHolstered();
            }
        }
        if (holstered){
            HolsteringScript();
        }
    }
}
