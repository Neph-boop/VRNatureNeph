using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WildlifePlayerDetection : MonoBehaviour
{

    private WildlifeManager wildlifeManager;
    private GameObject playerObj;
    //[SerializeField] LensCamScript lensCamScript;
    private GameObject myObj;
    private float playerDist;
    [SerializeField] float playerMinDist;
    [SerializeField] float playerMinDistCrouch;
    [SerializeField] bool isPlayerCrouching;

    [SerializeField] bool appearanceStatus;
    public isInCameraView isInCameraViewComponent;

    private ParticleSystem particleSys;

    [SerializeField] float reappearTimer;
    [SerializeField] float reappearTimeMax;
    //private bool vanished;

    // Start is called before the first frame update
    void Start()
    {
        //vanished = false;
        reappearTimer = 0.0f;
        appearanceStatus = true;
        myObj = this.gameObject;
        playerObj = this.GetComponentInParent<ProvidePlayer>().getPlayer();
        wildlifeManager = this.GetComponentInParent<WildlifeManager>();
        isInCameraViewComponent = this.GetComponent<isInCameraView>();
        particleSys = GetComponent<ParticleSystem>();
        reappearTimeMax = 4.0f;

        //lensCamScript = this.GetComponentInParent<ProvideCamera>().getCamera().GetComponent<LensCamScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPlayerCrouching)
        {
            if (checkPlayerDist())
            {
                if(appearanceStatus)
                {
                    Vanish();
                }
            }
            else
            {
                if(!appearanceStatus)
                {
                    reappearTimer += Time.deltaTime;
                    if (reappearTimer > reappearTimeMax)
                    {
                        Appear();
                    }
                }
            }
        }
    }

    public bool checkPlayerDist()
    {
        playerDist = Vector3.Distance(myObj.transform.position, playerObj.gameObject.transform.position);
        if (playerDist < playerMinDist)
            return true;
        else
            return false;
    }
    public void Vanish() 
    {
        appearanceStatus = false;
        if (!particleSys.isPlaying) particleSys.Play();
        isInCameraViewComponent.enabled = false;
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
        //vanished = true;

        //Emmit feathers and dust
        //wildlifeManager.flewAway(this.gameObject);
    }

    public void Appear()
    {
        appearanceStatus = true;
        if (particleSys.isPlaying) particleSys.Stop();
        isInCameraViewComponent.enabled = true;
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(true);

        }
        reappearTimer = 0.0f;
        //Flapping sounds
        //Emit feathers and dust
    }

    public void isPlayerCrouchRN()
    {
        //return wildlifeManager.getPlayerCrouch();
    }
}
