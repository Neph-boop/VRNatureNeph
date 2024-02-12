using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolsterParentScript : MonoBehaviour
{
    public GameObject CamAnchor;
    public float RotationSpeed = 40;


    // Update is called once per frame
    private void Update()
    {
        transform.position = new Vector3(CamAnchor.transform.position.x, CamAnchor.transform.position.y / 2, CamAnchor.transform.position.z);

        var rotationDiff = CamAnchor.transform.eulerAngles.y - transform.eulerAngles.y;
        if (rotationDiff < 0){
            rotationDiff = rotationDiff * -1;
        }
        var finalRotationSpeed = RotationSpeed;

        if (rotationDiff > 60){
            finalRotationSpeed = RotationSpeed * 2;
        }
        else if (rotationDiff > 40 && rotationDiff <= 60){
            finalRotationSpeed = RotationSpeed;
        }
        else if (rotationDiff > 20 && rotationDiff <= 40){
            finalRotationSpeed = RotationSpeed / 2;
        }
        else if (rotationDiff > 0 && rotationDiff <= 20){
            finalRotationSpeed = RotationSpeed / 4;
        }
        
        var step = finalRotationSpeed * Time.deltaTime;

        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, CamAnchor.transform.eulerAngles.y, 0), step);
    }
}
