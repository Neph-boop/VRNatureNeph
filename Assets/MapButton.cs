using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapButton : MonoBehaviour
{
    [SerializeField] private int mySceneIndex;
    [SerializeField] private string mySceneName;
    [SerializeField] private MapManager.WeatherCondition weatherCondition;
    
    public int getSceneIndex()
    {
        return mySceneIndex;
    }
    public string getSceneName()
    {
        return mySceneName;
    }

    public MapManager.WeatherCondition getWeatherCondition() 
    {
        return weatherCondition;
    }
}
