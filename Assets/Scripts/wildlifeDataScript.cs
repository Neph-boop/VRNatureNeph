using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class wildlifeDataScript : MonoBehaviour
{
    [SerializeField] string uID; //PK
    [SerializeField] string scientificName;
    [SerializeField] string speciesName;
    [SerializeField] string speciesCategory;
    [SerializeField] string hintDescription;
    [SerializeField] string longDescription;
    //[SerializeField] Material myMaterial;
    public Texture2D picture;
    public TextAsset speciesData;

    //private float unlockProgress;

    //private bool firstDebug = true;

    // Start is called before the first frame update
    void Start()
    {
        dataRetriever(speciesData);
    }

    public string getUID()              { return uID; }
    public string getScientificName()   { return scientificName; }
    public string getSpeciesName()      { return speciesName; }
    public string getSpeciesCategory()  { return speciesCategory; }
    public string getHintDescription()  { return hintDescription; }
    public string getLongDescription()  { return longDescription; }
    public Texture2D getPicture()       { return picture; }
    //public Material getMaterial()       { return myMaterial; }
    

    private void dataRetriever(TextAsset t)
    {
        string data = t.ToString();
        int i = 0;
        while (i < 6)
        {
            string line = getFirstLine(data);
            line = removeFirstWord(line);
            inputData(i, line);
            i++;
            data = removeFirstLine(data);
        }
    }

    private void inputData(int field, string input)
    {
        if (field == 0) // uID
            uID = input;
        else if (field == 1) // scientific Name
            scientificName = input;
        else if (field == 2) // species Name
            speciesName = input;
        else if (field == 3) // species Category
            speciesCategory = input;
        else if (field == 4) // hint Description
            hintDescription = input;
        else if (field == 5) // long Description
            longDescription = input;
        else //Error
            Debug.Log("ERROR: DATA INPUT OUT OF BOUNDS");
    }

    private string getFirstLine(string output)
    {
        int until = output.IndexOf("\n");
        if (until >= 0)
        {
            output = output.Substring(0, until);
        }
        else if (until == -1)
            return output;
        return output;
    }

    private string removeFirstWord(string data)
    {
        int until = data.IndexOf(" ");
        if (until >= 0)
        {
            data = data.Remove(0, until + 1);
        }
        else if (until == -1)
            Debug.Log("ERROR: Cannot remove first word");
        return data;
    }

    private string removeFirstLine(string data)
    {
        //Look at end of line
        int until = data.IndexOf("\n");

        //if exists, remove the line
        if (until >= 0)
            data = data.Remove(0, until + 1);

        //if doesn't exist (then we're on the last line anyway)
        else if (until == -1)
            return "";
        return data;

    }

    private void debugOut()
    {
        Debug.Log("SCI: " + scientificName);
        Debug.Log("NAM: " + speciesName);
        Debug.Log("CAT: " + speciesCategory);
        Debug.Log("HNT: " + hintDescription);
        Debug.Log("LNG: " + longDescription);
    }
}
