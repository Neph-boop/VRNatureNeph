using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class WildlifeManager : MonoBehaviour
{
    [SerializeField] WildlifeButtonManager buttonManager;
    [SerializeField] List<isInCameraView> inViewList;

    public List<GameObject> flewAwayList;
    [SerializeField] WildlifePlayerDetection wildlifeActivePD;
    //[SerializeField] PlayerCrouchScript playerCrouchScript; 
    [SerializeField] float wildlifeTimer = 0;
    [SerializeField] float wildlifeTimerMax = 10;
    // Start is called before the first frame update

    public void flewAway(GameObject wildlifePD)
    {
        flewAwayList.Add(wildlifePD);
        wildlifePD.SetActive(false);
    }

    void Update()
    {
        wildlifeTimer = wildlifeTimer + Time.deltaTime;
        if (wildlifeTimer > wildlifeTimerMax)
        {
            wildlifeTimer = 0;
            birdReturn();
        }
    }



    public void birdReturn()
    {
        if (flewAwayList.Count > 0) 
        {
            Debug.Log("TEST");
            Debug.Log(flewAwayList.Count);
            GameObject go = flewAwayList[0];
            go.SetActive(true);
            flewAwayList.Remove(go);
            Debug.Log(flewAwayList.Count);
        }
    }

    //public bool getPlayerCrouchRN()
    //{
    //    return playerCrouchScript.getStatus();
    //}



    public void addToList(GameObject gO)
    {
        inViewList.Add(gO.GetComponent<isInCameraView>());
    }
    public void removeFromList(GameObject gO)
    {
        for (int i = 0; i < inViewList.Count; i++)
        {
            if (inViewList[i] == gO.GetComponent<isInCameraView>())
            {
                inViewList.RemoveAt(i); break;
            }
        }
    }
    public void TakingPicture()
    {
        for (int i =0; i < inViewList.Count; i++)
        {
            inViewList[i].AttemptTakeAPictureOfMe();
        }
    }
    public WildlifeButtonManager getButtonManager()
    {
        return buttonManager;
    }
}
