using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Holsterable : MonoBehaviour
{

    public GameObject holsterPocket;
    private GameObject equipment;
    private EquipmentStatus linkToEquipment;
    
    private void Awake()
    {
        equipment = this.gameObject;
        linkToEquipment = equipment.GetComponent<EquipmentStatus>();
    }

    //Object has Entered Holster Area.
    public void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.CompareTag(holsterPocket.tag))
        {
            if((!linkToEquipment.GrabbedStatus()) && !linkToEquipment.HolsteredStatus())
            {
                Debug.Log(col.GetComponent<Collider>().tag + " VS " + holsterPocket.tag);
                linkToEquipment.IsHolstered();
            }
        }
    }

}
