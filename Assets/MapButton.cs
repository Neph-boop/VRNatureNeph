using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapButton : MonoBehaviour
{
    [SerializeField] private int mySceneIndex;
    [SerializeField] private string mySceneName;
    
    public int getSceneIndex()
    {
        return mySceneIndex;
    }
    public string getSceneName()
    {
        return mySceneName;
    }
}
