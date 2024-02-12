using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hoverScroll : MonoBehaviour
{
    [SerializeField] int direction;
    [SerializeField] scrollMe scrollMeObj;

    public void startScroll()
    {
        if (direction == 1)
            scrollMeObj.scrollUp();

        else if (direction == -1)
            scrollMeObj.scrollDown();

        else
            Debug.Log("ERROR SCROLL OUT OF BOUNDS");
    }
}
