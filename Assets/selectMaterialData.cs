using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selectMaterialData : MonoBehaviour
{
    [SerializeField] Material nonSelectMat;
    [SerializeField] Material selectMat;
    [SerializeField] Material hoverMat;
    // Start is called before the first frame update
    public Material getNonSelectMaterial() { return nonSelectMat; }
    public Material getSelectMaterial() { return selectMat; }
    public Material gethoverMaterial() { return hoverMat; }
}
