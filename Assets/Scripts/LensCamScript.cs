using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LensCamScript : MonoBehaviour
{
    public Camera cam;
    public GameObject thiscam;
    public GalleryHandler GalleryHandlerRef;
    public bool ToggleStatus;
    public bool isGrabbed;
    private bool PictureTaking;

    public int fileCounter = 1;



    void Awake()
    {
        thiscam.SetActive(false);
    }

    private void Start()
    {
        GetSaveData();
    }

    private void GetSaveData()
    {
        fileCounter = GameData.GetInt(GameData.IMAGE_COUNTER_SAVE_NAME);
        if (fileCounter > GalleryHandlerRef.ImageListCount)
            fileCounter = 1;
        
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
        if (!Directory.Exists(GameData.GALLERY_SAVE_PATH))
            Directory.CreateDirectory(GameData.GALLERY_SAVE_PATH);
  
        File.WriteAllBytes(GameData.GALLERY_SAVE_PATH + fileCounter + ".png", Bytes);
        GameData.SaveInt(GameData.IMAGE_COUNTER_SAVE_NAME, fileCounter);
        fileCounter++;
        if (fileCounter > GalleryHandlerRef.ImageListCount)
            fileCounter = 1;
        //Debug.Log("CLICK!");
    }

    public void TakePicture(){
       PictureTaking = true;
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
