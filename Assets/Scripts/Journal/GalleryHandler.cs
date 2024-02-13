using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GalleryHandler : MonoBehaviour
{
    [SerializeField]
    private List<RawImage> _galleryImageList;

    public int ImageListCount => _galleryImageList.Count;
    //Listens to Journal Master OnSwitchState callback
    public void ShowGallery(int state)
    {
        if (state == 2)
        {
            ShowImages();
        }
    }

    public void ShowImages()
    {
        GetImages();
    }

    public void GetImages()
    {
        if (!Directory.Exists(GameData.GALLERY_SAVE_PATH))
            Directory.CreateDirectory(GameData.GALLERY_SAVE_PATH);

        string[] images = Directory.GetFiles(GameData.GALLERY_SAVE_PATH);
        for (int i = 0; i < images.Length; i++)
        {
            if (i > _galleryImageList.Count - 1)
                break;
            Texture2D texture = new Texture2D(512,512, TextureFormat.ARGB32, false);
            texture.LoadImage(File.ReadAllBytes(images[i]));
            texture.Apply();
            _galleryImageList[i].texture = texture;
        }
    }
}
