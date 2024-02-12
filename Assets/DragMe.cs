using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DragMe : MonoBehaviour
{
    public Vector3 dragOrigin;
    public Vector3 dragTarget;
    public float speed;

    //private bool alreadydragging = false;
    
    public LeftHandPointer pointer;

    public GameObject dragObject;
    public GameObject dragDestination;


    //[SerializeField] private Transform transform;
    [SerializeField] private bool isDragging = false;
    [SerializeField] private UnityEvent leftActivate;

    // Start is called before the first frame update
    void Start()
    {
        //transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        dragObject.transform.position = dragOrigin;
        dragDestination.transform.position = dragTarget;
        if (isDragging)
        {
            //continueDrag(pointer.getHitPoint()); 
            Vector3 shortDest = Vector3.Lerp(dragOrigin, dragTarget, speed * Time.deltaTime);
            //transform.position = shortDest - dragOrigin;
            dragOrigin = shortDest;
        }
    }

    public void beginDrag(Vector3 dragStartingPoint)
    {
        Debug.Log("BEGIN DRAG");
        //ector3 dragStartingPoint = pointer.getHitPoint();
        dragOrigin = dragStartingPoint;
        isDragging = true;
    }
    public void continueDrag(Vector3 hitInput)
    {
        dragTarget = hitInput;
    }
    public void endDrag() 
    {
        Debug.Log("END DRAG");
        isDragging = false;
    }

    public void setDragTarget(Vector3 hitInput)
    {

    }
}
