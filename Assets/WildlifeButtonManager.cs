using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WildlifeButtonManager : MonoBehaviour
{
    public selectWildlifeProg[] ButtonList;
    //public List<selectWildlifeProg> ButtonList2;
    private int ButtonListSize;
    // Start is called before the first frame update
    void Start()
    {
        ButtonListSize = ButtonList.Length;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TookAPictureOfMe(string uID, float score)
    {
        Debug.Log("TESTING PLEASE WORK");
        for (int i = 0; i < ButtonListSize; i++) 
        {
            if (ButtonList[i].getName() == uID)
            {
                ButtonList[i].addProgress(score);
            }
        }
        /*
        for (int x = 0; x < ButtonListSize; x++)
        {
            if (uID.Equals(ButtonList[x].getUID())) 
            {
                Debug.Log(ButtonList[x].getName() + " : THIS IS GOT PICTURED 100% AND IS GETTING POINTS");
                ButtonList[x].addProgress(score);
            }
        }
        */
    }
}
