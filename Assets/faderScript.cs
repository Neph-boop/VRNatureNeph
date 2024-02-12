using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class faderScript : MonoBehaviour
{
    public bool fadeOnStart = true;
    public float fadeDuration = 1;
    public Color fadeColor;
    private Renderer myrenderer;
    public float myFade;
    [SerializeField] private Material myMaterial;
    [SerializeField] private int n = 0;
    [SerializeField] private float myCurrentFade;
    [SerializeField] private float myFinalFade;
    [SerializeField] private bool fading;

    [SerializeField] private MapManager myMapManager;

    public float fadeColorAlpha;
    
    // Start is called before the first frame update
    void Start()
    {
        myrenderer = GetComponent<Renderer>();
        if (fadeOnStart)
            fadeIn();
    }

    private void Update()
    {
        if (fading)
        {
            dofade(myCurrentFade, myFinalFade);
        }
    }

    public void fadeIn()
    {
        //myrenderer.material.color = new Color(255, 255, 0, 255);
        
        startfade(1,0);
    }

    public void fadeOut()
    {
        startfade(0,1);
    }

    public void startfade(float alphaIn, float alphaOut) 
    {
        myrenderer.material.color = new Color(n, n, n, alphaIn);
        myCurrentFade = alphaIn;
        myFinalFade = alphaOut;
        fading = true;
    }

    private void dofade(float currentFade, float FinalFade)
    {
        float fadeDirection = currentFade - FinalFade;
        if (fadeDirection < 0)
        {
            //Going dark, also end goal is 255;
            myCurrentFade = myCurrentFade + (Time.deltaTime / fadeDuration);
        }
        else if (fadeDirection > 0)
        {
            //Going seethrough, also end goal is 0;
            myCurrentFade = myCurrentFade - (Time.deltaTime / fadeDuration);
        }
        if (myCurrentFade > 1 && FinalFade == 1)
        {
            myCurrentFade = 1;
            fading = false;
            endfade();
        }
        else if (myCurrentFade < 0 && FinalFade == 0)
        {
            myCurrentFade = 0;
            fading = false;
            endfade();
        }
        myrenderer.material.color = new Color(n, n, n, myCurrentFade);
    }

    public void endfade()
    {
        myMapManager.allowMapChange();
    }
    /*
    public IEnumerator fadeRoutine(float alphaIn, float alphaOut)
    {
        float timer = 0;
        while (timer <= fadeDuration)
        {
            Color newColor = fadeColor;
            newColor.a = Mathf.Lerp(alphaIn, alphaOut, timer / fadeDuration);
            myFade = timer;
            //myrenderer.material.SetColor("_Color", newColor);
            myMaterial.color = newColor;
            timer += Time.deltaTime;
            yield return null;
        }
        Color newColorFinal = fadeColor;
        newColorFinal.a =  alphaOut;
        myMaterial.color = newColorFinal;
        //myrenderer.material.SetColor("_Color", newColorFinal);
    }
    */
}
