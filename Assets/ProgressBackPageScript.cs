using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ProgressBackPageScript : MonoBehaviour
{
    //[SerializeField] wildlifeDataScript wData;

    [SerializeField] string uID;
    [SerializeField] string speciesName;
    [SerializeField] string scientificName;
    [SerializeField] string hintDescription;
    [SerializeField] string longDescription;
    //[SerializeField] List<Material> lockedMats;
    //[SerializeField] List<Material> material;

    [SerializeField] TextMeshPro textSpeciesName;
    [SerializeField] TextMeshPro textScientificName;
    [SerializeField] TextMeshPro textHintDescription;
    [SerializeField] TextMeshPro textLongDescription;
    [SerializeField] GameObject ImageFrame;
    [SerializeField] Renderer myRenderer;
    [SerializeField] Texture2D imageActual;
    public string lockedText = "[Locked]";
    [SerializeField] private bool unlocked = false;
    // Start is called before the first frame update
    void Start()
    {
        uID = ""; 
        speciesName = scientificName = hintDescription = longDescription = "Default";
        updateBackPageTextView();
        myRenderer = ImageFrame.GetComponent<Renderer>();
    }


    public void updateBackPage(wildlifeDataScript newWData, bool unlockedIn)
    {
        if ((uID.Equals(""))||(!newWData.getUID().Equals(uID)))
        {
            updateBackPageData(newWData, unlockedIn);
            
        }
        //unlocked = unlockedIn;
    }
    private void updateBackPageData(wildlifeDataScript wData, bool unlockedIn)
    {
        uID = wData.getUID();
        speciesName = wData.getSpeciesName();
        scientificName= wData.getScientificName();
        hintDescription = wData.getHintDescription();
        longDescription = wData.getLongDescription();
        imageActual = wData.getPicture();

        
        if (!unlockedIn)
        {
            longDescription = lockedText;
        }

        updateBackPageTextView();
    }
    private void updateBackPageTextView()
    {
        textSpeciesName.SetText(speciesName);
        textScientificName.SetText(scientificName);
        textHintDescription.SetText(hintDescription);
        textLongDescription.SetText(longDescription);

        if (!(imageActual == null))
        {
        MaterialPropertyBlock block = new MaterialPropertyBlock();
        myRenderer.GetPropertyBlock(block);
        block.SetTexture("_BaseMap", imageActual);
        myRenderer.SetPropertyBlock(block);
        }
    }
}
