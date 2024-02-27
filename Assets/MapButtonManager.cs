using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;

public class MapButtonManager : MonoBehaviour
{

    public LeftHandPointer lHPointer;
    [SerializeField] private Collider pointedAtCollider;

    [SerializeField] private MapButton activeBtn;

    [SerializeField] private MapManager mapManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pointedAtCollider = lHPointer.getJournalHitCollider();
        if (pointedAtCollider != null && (checkIfBtn(pointedAtCollider)))
        {
            activeBtn = pointedAtCollider.GetComponent<MapButton>();
        }
        else
        {
            activeBtn = null;
        }
    }

    private bool checkIfBtn(Collider pAtCollider)
    {
        if (pAtCollider.gameObject.tag == "Button")
            return true;
        return false;
    }

    public void attemptSelectScene()
    {
        if (activeBtn != null)
        {
            mapManager.goToScene(activeBtn.getSceneIndex(), activeBtn.getWeatherCondition());
        }
    }

    public int selectScene()
    {
        return activeBtn.getSceneIndex();
    }

    public void SetActiveButton(MapButton button)
    {
        activeBtn = button;
        attemptSelectScene();
    }


}
