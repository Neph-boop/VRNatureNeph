using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class isInCameraView : MonoBehaviour
{
    public new Camera camera;
    new MeshRenderer renderer;
    Plane[] cameraFrustrum;
    [SerializeField] GameObject cameraTarget;
    new Collider collider;
    //public TextMesh textMesh;
    //public TextMeshPro textMeshPro;
    RaycastHit hit;
    public LayerMask maskLayer;
    public WildlifeButtonManager wildlifeButtonManager;
    public WildlifeManager wildlifeManager;

    [SerializeField] private bool isInView = false;
    [SerializeField] private float scoreMultiplier = 0.5f;
    [SerializeField] private string myName;


    // Start is called before the first frame update
    void Start()
    {
        ///renderer = GetComponent<MeshRenderer>();
        collider = cameraTarget.GetComponent<Collider>();
        wildlifeManager = GetComponentInParent<WildlifeManager>();
        wildlifeButtonManager = wildlifeManager.getButtonManager();
        myName = GetComponentInChildren<wildlifeDataScript>().getSpeciesName();
    }

    // Update is called once per frame
    void Update()
        
    {
        if (myName == "")
        {
            myName = GetComponentInChildren<wildlifeDataScript>().getSpeciesName();
        }
        var bounds = collider.bounds;
        cameraFrustrum = GeometryUtility.CalculateFrustumPlanes(camera);
        if (GeometryUtility.TestPlanesAABB(cameraFrustrum, bounds))
        {
            
            isInFront();
            if (!isInView)
            {
                isInView = true;
                wildlifeManager.addToList(this.gameObject);
            }
        }
        else
        {
            //textMeshPro.text = "0";
            if (isInView)
            {
                isInView = false;
                wildlifeManager.removeFromList(this.gameObject);
            }
        }
    }

    public void AttemptTakeAPictureOfMe()
    {
        //Debug.Log("TYTEST");
        if (isInView)
        {
            detectObstruction();
            //Debug.Log(myName + " WHAT IS MY NAME");
            wildlifeButtonManager.TookAPictureOfMe(myName, isInFront());
        }
    }

    private void detectObstruction()
    {//Physics.Raycast(ray, out hit, maxDist, maskLayer, QueryTriggerInteraction.Collide
        if (Physics.Linecast(camera.transform.position, cameraTarget.transform.position, out hit, maskLayer, QueryTriggerInteraction.Ignore))
        {
            Debug.Log(hit.collider.gameObject.name + " was in the way");
            if (hit.collider.gameObject == cameraTarget)
            {
                Debug.Log("SUCCESSFUL PICTURE");
            }
        }
    }

    public float isInFront()
    { 
        Vector3 camForward = camera.transform.TransformDirection(Vector3.forward);
        Vector3 camToMe = camera.transform.position - cameraTarget.transform.position;

        float score = Vector3.Dot(camForward.normalized, camToMe.normalized);
        score = ((score * -1) - 0.90F) * 100;
        //textMesh.text = score.ToString();
        score = Mathf.Round(score*100.0f);
        //textMeshPro.text = score.ToString();
        return score*scoreMultiplier;
    }
}
