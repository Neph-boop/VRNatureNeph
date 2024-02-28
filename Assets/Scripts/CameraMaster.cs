using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CameraMaster : MonoBehaviour
{

    public GameObject holsterGOSnap;
    private EquipmentStatus equipmentStatus;
    
    [SerializeField] private UnityEvent zoomToggleTrigger;
    [SerializeField] private UnityEvent takePictureTrigger;
    [SerializeField] private float CameraCooldown = 1;
    [SerializeField] private float CameraMax = 1;
    [SerializeField] private WildlifeManager wildlifeManager;

    private void Awake()
    {
        equipmentStatus = this.gameObject.GetComponent<EquipmentStatus>();
    }

    private void Update()
    {
        if (CameraCooldown > 0)
        {
            CameraCooldown -= Time.deltaTime;
        }
    }

    public void AttemptTakePicture(){
        if (equipmentStatus.GrabbedStatus() && CameraCooldown <= 0){
            ConfirmTakePicture();
            CameraCooldown = CameraMax;
        }
    }
    public void ConfirmTakePicture(){
        //TakePicture
        takePictureTrigger.Invoke();
        wildlifeManager.TakingPicture();
    }

    public void AttemptZoomToggle(){
        if (equipmentStatus.GrabbedStatus()){
            ConfirmZoomToggle();
        }
    }
    public void ConfirmZoomToggle(){
        //Zoom
        zoomToggleTrigger.Invoke();
    }

    public void SetWildlifeManager(WildlifeManager wildlife)
    { 
        wildlifeManager = wildlife;
    }
}
