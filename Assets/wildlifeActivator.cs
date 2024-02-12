using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class wildlifeActivator : MonoBehaviour
{
    public GameObject myGameObject;

    public Vector3 temp;

    [SerializeField] Transform mytransform;
    [SerializeField] float active = -0.79f;
    [SerializeField] float unactive = -50.79f;

    [SerializeField] bool test = false;

    // Start is called before the first frame update
    void Start()
    {
        active = -0.79f;
        unactive = -50.79f;
        temp = myGameObject.transform.position;
        deactivateMe();
        //mytransform = GetComponent<Transform>();
    }

    private void Update()
    {
        /*
        if (test)
        {
            activateMe();
        }
        else
        {
            deactivateMe();
        }
        */
    }

    public void activateMe()
    {
        Debug.Log("Activating");
        temp.y = active;
        myGameObject.transform.position = temp;
    }
    public void deactivateMe()
    {
        Debug.Log("DE Activating");
        temp.y = unactive;
        myGameObject.transform.position = temp;
        //mytransform.position.Set(mytransform.position.x, unactive, mytransform.position.z);
    }

}
