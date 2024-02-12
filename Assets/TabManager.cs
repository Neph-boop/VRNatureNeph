using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabManager : MonoBehaviour
{
    [SerializeField] private JournalMaster journalMaster;
    [SerializeField] private int currentState = 0;

    [SerializeField] private GameObject progressTab;
    [SerializeField] private GameObject mapTab;
    [SerializeField] private GameObject galleryTab;
    [SerializeField] private GameObject settingsTab;

    public LeftHandPointer lHPointer;
    [SerializeField] private Collider pointedAtCollider;
    // Start is called before the first frame update
    void Update()
    {
        pointedAtCollider = lHPointer.getJournalHitCollider();
    }

    public void attemptChangeTab()
    {
        if (pointedAtCollider == progressTab.GetComponent<Collider>()) {
            journalMaster.switchState(0);
        }
        else if (pointedAtCollider == mapTab.GetComponent<Collider>()) {
            journalMaster.switchState(1);
        }
        else if (pointedAtCollider == galleryTab.GetComponent<Collider>()) {
            journalMaster.switchState(2);
        }
        else if (pointedAtCollider == settingsTab.GetComponent<Collider>()) {
            journalMaster.switchState(3);
        }
        else
        {
            Debug.Log(pointedAtCollider.name);
        }

    }
}
