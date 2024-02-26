using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class JournalMaster : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private int currentJournalState = 0;

    public GameObject[] journalTabs;


    /*
    public GameObject Progress_Tab_Front;
    public GameObject Progress_Tab_Back;
    public GameObject Maps_Tab;
    public GameObject Maps_Tab;
    public GameObject Gallery_Tab;
    public GameObject Gallery_Tab;
    public GameObject Settings_Tab;
    public GameObject Settings_Tab;
    */
    /*
     * States:
     * 0 = Progress/wildlife
     * 1 = Maps
     * 2 = Gallery
     * 3 = Settings
     */

    public UnityEvent<int> OnSwitchState;

    private void Start()
    {
        switchState(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void switchState(int state)
    {
        currentJournalState = state;
        updateState(state);
     }

    private void updateState(int state)
    {
        turnOffTabs();

        if (currentJournalState == 0) {
            journalTabs[0].SetActive(true);
            journalTabs[1].SetActive(true);
        }
        else if (currentJournalState == 1)
        {
            journalTabs[2].SetActive(true);
            journalTabs[3].SetActive(true);
        }
        else if (currentJournalState == 2)
        {
            journalTabs[4].SetActive(true);
            journalTabs[5].SetActive(true);
        }
        else if (currentJournalState == 3)
        {
            journalTabs[6].SetActive(true);
            journalTabs[7].SetActive(true);
        }

        OnSwitchState?.Invoke(state);
    }

    private void turnOffTabs()
    {
        for (int i = 0; i < journalTabs.Length; i++)
        {
            journalTabs[i].SetActive(false);
        }
    }
}
