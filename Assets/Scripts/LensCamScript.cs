using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LensCamScript : MonoBehaviour
{
    public Camera cam;
    public GameObject thiscam;
    public bool ToggleStatus;
    public bool isGrabbed;
    private bool PictureTaking;

    public int fileCounter = 0;

    void Awake()
    {
        thiscam.SetActive(false);
    }

    public void ToggleZoom(){
        if (ToggleStatus){
            cam.focalLength = 160;
        }
        else {
            cam.focalLength = 60;
        }
        ToggleStatus = !ToggleStatus;
    }

    public void TakePictureLateUpdate(){
        RenderTexture currentRT = RenderTexture.active;
        RenderTexture.active = cam.targetTexture;
 
        cam.Render();
 
        Texture2D Image = new Texture2D(cam.targetTexture.width, cam.targetTexture.height);
        Image.ReadPixels(new Rect(0, 0, cam.targetTexture.width, cam.targetTexture.height), 0, 0);
        Image.Apply();
        RenderTexture.active = currentRT;
 
        var Bytes = Image.EncodeToPNG();
        Destroy(Image);
 
        File.WriteAllBytes(Application.dataPath + "/Backgrounds/" + fileCounter + ".png", Bytes);
        fileCounter++;

        //Debug.Log("CLICK!");
    }

    public void TakePicture(){
        //PictureTaking = true;
    }

    private void LateUpdate(){
        if (PictureTaking)
        {
            TakePictureLateUpdate();
            PictureTaking = false;
        }
    }

    public Vector3 getPosition() 
    {
        return thiscam.transform.position;
    }
}
