using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MapManager : MonoBehaviour
{
    [SerializeField] faderScript fader;

    [SerializeField] int currentMap = 0;
    [SerializeField] int nextMap;
    [SerializeField] int defaultMap;
    [SerializeField] bool mapchangeBool = false;
    [SerializeField] bool waitingforPermission = false;

    [SerializeField] wildlifeActivator gonzagaWildlifeActivator;
    [SerializeField] GameObject GonzagaFloor;

    [SerializeField] wildlifeActivator lowereastWildlifeActivator;
    [SerializeField] GameObject LowerEastFloor;

    [SerializeField] resetStartingPoint rSP;

    //List<AsyncOperation> scenesToLoad = new List<AsyncOperation>();
    //List<string> loadedScenes = new List<string>();
    //List<string> scenesTobeLoaded = new List<string>();

    private void Start()
    {
        //scenesTobeLoaded.Add("Main VR Scene");
        //scenesToLoad.Add(SceneManager.LoadSceneAsync("Main VR Scene"));
        //scenesToLoad.Add(SceneManager.LoadSceneAsync("VR GonzagaParking", LoadSceneMode.Additive));
    }

    // Update is called once per frame
    [System.Obsolete]
    void Update()
    {
        /*
        if (scenesTobeLoaded != null)
        {
            //checkScene(scenesTobeLoaded);
        }
        */

        if (currentMap == 1)
        {
            nextMap = 2;
            Debug.Log(nextMap);
            changeMap(nextMap);
            activateScene(nextMap);
            rSP.resetPosition();
            endFade();
        }

        if (waitingforPermission)
        {
            if (mapchangeBool)
            {
                Debug.Log(nextMap);
                changeMap(nextMap);
                activateScene(nextMap);
                rSP.resetPosition();
                endFade();
            }
        }
    }
    /*
    private void checkScene(List<string> targetscenes)
    {
        for (int i = 0; i < targetscenes.Count; i++)
        {
            if targetscene
        }
    }*/

    [System.Obsolete]
    public void changeMap(int sceneIndex)
    {
        Debug.Log("CHANGING MAP");
        if (currentMap != 0)
        {
            SceneManager.UnloadSceneAsync(currentMap);
        }
        //        scenesToLoad.Add(SceneManager.LoadSceneAsync(nextMap, LoadSceneMode.Additive));
        SceneManager.LoadSceneAsync(sceneIndex, LoadSceneMode.Additive);
        currentMap = sceneIndex;
        waitingforPermission = false;

        Debug.Log("Scene: " + sceneIndex);
        //StartCoroutine(loadingScenes());
    }
    /*
    public IEnumerator loadingScenes()
    {
        float totalProgress = 0;
        for (int i = 0; i<scenesToLoad.Count; i++)
        {
            while (!scenesToLoad[i].isDone)
            {
                totalProgress += scenesToLoad[i].progress;
                yield return null;

            }
        }
    }*/

    public void allowMapChange()
    {
        mapchangeBool = true;
    }

    private void startFade()
    {
        fader.fadeOut();
    }
    private void endFade()
    {
        fader.fadeIn();
    }


    public void goToScene(int sceneIndex)
    {
        startFade();
        mapchangeBool = false;
        waitingforPermission = true;
        nextMap = sceneIndex;
    }
    /*
    public void GoToScene(int sceneIndex)
    {
        fader.fadeIn();
        StartCoroutine(GoToSceneRoutine(sceneIndex));
    }

    IEnumerator GoToSceneRoutine(int sceneIndex)
    {
        fader.fadeOut();
        yield return new WaitForSeconds(fader.fadeDuration);
        SceneManager.LoadScene(sceneIndex);
        
    }
    */
    private void activateScene(int sceneIndex)
    {
        gonzagaWildlifeActivator.deactivateMe();
        lowereastWildlifeActivator.deactivateMe();

        GonzagaFloor.SetActive(false);
        LowerEastFloor.SetActive(false);

        if (sceneIndex == 2) //Gonzaga
        {
            Debug.Log("activateScene");
            gonzagaWildlifeActivator.activateMe();
            GonzagaFloor.SetActive(true);
        }
        if (sceneIndex == 3)
        {
            Debug.Log("activateScene");
            lowereastWildlifeActivator.activateMe();
            LowerEastFloor.SetActive(true);
        }
    }
}
