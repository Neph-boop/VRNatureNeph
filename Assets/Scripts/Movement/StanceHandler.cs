using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class StanceHandler : MonoBehaviour
{
    [SerializeField]
    private Transform _mainCamera;
    [SerializeField]
    private Transform _cameraOffset;
    [SerializeField]
    private float _physicalCrouchHeightY;

    private float _normalHeightY = 0;

    private float _crouchHeightY;

    [SerializeField]
    private bool _isButtonActivated = true;

    private bool _isCrouching = false;

    //For testing crouch only, remove on release
    [SerializeField]
    private TextMeshProUGUI _crouchStateText;

    private void Update()
    {
        PhysicalCrouching();
    }

    private void PhysicalCrouching()
    {
        if (_isButtonActivated)
            return;

        _isCrouching = (_mainCamera.localPosition.y <= _physicalCrouchHeightY);
        _crouchStateText.text = _isCrouching.ToString();
    }

    public void OnCrouchButtonPressed()
    {
        Debug.Log("BUTTON PRESSING TO CROUCH");
        if (!_isButtonActivated)
            return;

        _isCrouching = !_isCrouching;
        _crouchHeightY = -(_mainCamera.transform.localPosition.y / 2);
        _cameraOffset.position = new Vector3(_cameraOffset.position.x, (_isCrouching) ? _crouchHeightY : _normalHeightY, _cameraOffset.position.z);
        _crouchStateText.text = _isCrouching.ToString();
    }

    public void ToggleCrouchButton(bool isEnable)
    {
        _isButtonActivated = isEnable;
    }
}
