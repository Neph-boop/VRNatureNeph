using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProvideCamera : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    public Camera getCamera() { return _camera; }
}
