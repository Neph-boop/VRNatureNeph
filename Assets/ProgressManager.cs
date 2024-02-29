using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ProgressManager : MonoBehaviour
{
    // Currently not in use
    [SerializeField] private UnityEvent activateButton;
    [SerializeField] private UnityEvent hoverButton;

    public LeftHandPointer lHPointer;

    public selectWildlifeProg selectedButton;

    public selectWildlifeProg hoveredButton;

    [SerializeField] private Collider pointedAtCollider;

    public ProgressBackPageScript progBPscript;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Continuously checks what Pointer is Pointing At.
        pointedAtCollider = lHPointer.getJournalHitCollider();
        //If Pointing at a Button
        if ((pointedAtCollider != null ) && (checkIfBtn(pointedAtCollider)))
        {   
            //If wasn't pointing at anything
            if (hoveredButton == null)
            {
                hoveredButton = pointedAtCollider.GetComponent<selectWildlifeProg>();
            }

            //If pointing at a new Button
            else if (!hoveredButton.getUID().Equals(pointedAtCollider.GetComponent<selectWildlifeProg>().getUID()))
            {
                //If old button was not selected
                if (hoveredButton.getState() == 1)
                {
                    hoveredButton.deselectButton();
                }
                hoveredButton = pointedAtCollider.GetComponent<selectWildlifeProg>();
            }
            //If pointnig at an unselected button
            if (hoveredButton.getState() == 0)
            {
                hoveredButton.hoverOverButton();
            }
        }
        //Pointing at nothing important
        else
            hoveredButton = null;
    }

    private bool checkIfBtn(Collider pAtCollider)
    {
        if (pAtCollider.gameObject.tag == "Button")
            return true;
        return false;
    }

    public void attemptSelect()
    {
        //If hovering over something
        if (hoveredButton != null)
        {
            //If Already selected something else
            if (selectedButton != null)
            {
                selectedButton.deselectButton();
            }
            selectedButton = hoveredButton;
            selectedButton.selectButton();
            activateButton.Invoke();
            progBPscript.updateBackPage(selectedButton.getWData(), selectedButton.getIfUnlocked());
        }
    }

    public void SetSelectedButton(selectWildlifeProg button)
    {
        progBPscript.updateBackPage(button.getWData(), button.getIfUnlocked());
    }
    

}
