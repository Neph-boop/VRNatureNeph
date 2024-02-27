using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class selectWildlifeProg : MonoBehaviour
{
    [SerializeField] string uID;
    [SerializeField] string textName;
    [SerializeField] wildlifeDataScript wData;
    [SerializeField] wildlifeDataScript wDataOut;
    [SerializeField] int state;

    [SerializeField] AudioProgScript audioProgScript;
    /*  0: Deselected
     *  1: Hovered
     *  2: Selected
     */

    [SerializeField] new Renderer renderer;
    private Material nonSelectMat;
    private Material selectMat;
    private Material hoverMat;

    [SerializeField] float expProgress;
    [SerializeField] float expMax;
    [SerializeField] bool unlocked = false;

    [SerializeField] TextMeshPro label;
    //[SerializeField] TextMeshPro prog;
    [SerializeField] Image progessImage;
    [SerializeField] Sprite lockSprite;
    [SerializeField] Sprite unlockSprite;

    // Start is called before the first frame update
    void Start()
    {
        nonSelectMat =  GetComponentInParent<selectMaterialData>().getNonSelectMaterial();
        selectMat    =  GetComponentInParent<selectMaterialData>().getSelectMaterial();
        hoverMat     =  GetComponentInParent<selectMaterialData>().gethoverMaterial();
        state = 0;
        renderer = GetComponent<Renderer>();
        renderer.material = nonSelectMat;
        uID = wData.getUID();
        textName = wData.getSpeciesName();
        label.SetText(textName);
        //prog.SetText("0");
        progessImage.sprite = lockSprite;
        wDataOut = wData;

        audioProgScript = this.transform.parent.GetComponent<AudioProgScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (uID.Equals(""))
        {
            uID = wData.getUID();
            textName = wData.getSpeciesName();
            label.SetText(textName);
            wDataOut = wData;
        }
    }
    public void addProgress(float progress)
    {
        if (!unlocked)
        {
            expProgress += progress;
            //prog.SetText(expProgress.ToString());
            if (expProgress > expMax)
            {
                unlocked = true;
                //Debug.Log( textName + " Unlocked!!!");
                //prog.SetText("Unlocked!");
                progessImage.sprite = unlockSprite;
                audioProgScript.PlayEquipClip();
                wDataOut = wData;
            }
        }
        //Debug.Log(textName + " " + expProgress);
    }
    public void deselectButton()
    {
        state = 0;
        renderer.material = nonSelectMat;
    }
    public void hoverOverButton()
    {
        state = 1;
        renderer.material = hoverMat;
    }
    public void selectButton()
    {
        state = 2;
        renderer.material = selectMat;
        
    }

    public string getUID() { return uID; }
    public string getName() { return textName; }
    public int getState() { return state; }
    public wildlifeDataScript getWData() { return wDataOut; }

    public bool getIfUnlocked()
    {
        return unlocked;
    }
}
