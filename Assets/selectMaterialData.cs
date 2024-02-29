using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selectMaterialData : MonoBehaviour
{
    [SerializeField] Material nonSelectMat;
    [SerializeField] Material selectMat;
    [SerializeField] Material hoverMat;
    [SerializeField] Color nonSelectColor;
    [SerializeField] Color selectColor;
    [SerializeField] Color hoverColor;
    // Start is called before the first frame update
    public Material getNonSelectMaterial() { return nonSelectMat; }
    public Material getSelectMaterial() { return selectMat; }
    public Material gethoverMaterial() { return hoverMat; }

    public Color getNonSelectColor() { return nonSelectColor; }
    public Color getSelectColor() { return selectColor; }
    public Color gethoverColor() { return hoverColor; }
}
