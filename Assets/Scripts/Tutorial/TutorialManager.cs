using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TutorialManager : MonoBehaviour
{
    private enum TutorialStage {
        TELEPORT = 0,
        CAMERA = 1,
        JOURNAL = 2,
        SNEAKING = 3,
        FINAL = 4
    }
    [SerializeField]
    private GameObject _tutorialPillarParent;

    [SerializeField]
    private GameObject _cameraObject;
    [SerializeField]
    private GameObject _cameraSnapObject;
    [SerializeField]
    private GameObject _journalObject;
    [SerializeField]
    private GameObject _journalSnapObject;

    [SerializeField]
    private LocomotionProvider _locomotionProvider;
    [SerializeField]
    private List<GameObject> _tutorialPillars;

    private TutorialStage _currentStage = TutorialStage.TELEPORT;


    private void Start()
    {
        Init();
        _locomotionProvider.endLocomotion += OnEndLocomotion;
    }

    private void Init()
    {
        Debug.Log(GameData.Is_Tutorial);
        if (GameData.Is_Tutorial)
        {
            _cameraObject.SetActive(false);
            _journalObject.SetActive(false);
            _cameraSnapObject.SetActive(false);
            _journalSnapObject.SetActive(false);
            ToggleShowTutorialParent(true);
            LoadCurrentTutorial();
        }

    }

    public void ToggleShowTutorialParent(bool isEnable)
    {
        if (!GameData.Is_Tutorial)
            return;

       _tutorialPillarParent.SetActive(isEnable);
    }
    private void LoadCurrentTutorial()
    {
        if (!GameData.Is_Tutorial)
            return;

        _tutorialPillars.ForEach(x => x.SetActive(false));

        if (_currentStage > TutorialStage.FINAL)
            return;

        _tutorialPillars[(int)_currentStage].SetActive(true);
    }

    private void SetNextTutorial()
    {
        if (!GameData.Is_Tutorial)
            return;

        _currentStage++;
    }

    private void OnEndLocomotion(LocomotionSystem system)
    {
        if (!GameData.Is_Tutorial)
            return;
        if (_currentStage == TutorialStage.TELEPORT)
        {
            SetNextTutorial();
            LoadCurrentTutorial();
            _cameraObject.SetActive(true);
            _cameraSnapObject.SetActive(true);
        }
    }

    public void OnTakePicture()
    {
        if (!GameData.Is_Tutorial)
            return;
        if (_currentStage == TutorialStage.CAMERA)
        {
            SetNextTutorial();
            LoadCurrentTutorial();
        }
        _journalObject.SetActive(true);
        _journalSnapObject.SetActive(true);
    }

    public void OnJournalExit()
    {
        if (!GameData.Is_Tutorial)
            return;
        if (_currentStage == TutorialStage.JOURNAL)
        {
            SetNextTutorial();
            LoadCurrentTutorial();
        }
    }

    public void OnBirdPictured()
    {
        if (!GameData.Is_Tutorial)
            return;
        if (_currentStage == TutorialStage.SNEAKING)
        {
            SetNextTutorial();
            LoadCurrentTutorial();
        }
    }
}
