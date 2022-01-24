using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSVLoader : MonoBehaviour
{
    TextAsset csvFile;
    char lineSeparator = '\n';
    char surround = '"';
    string[] fieldSeparator = { "\", \"" };

    public void LoadCSV()
    {
        csvFile = Resources.Load<TextAsset>("Localisation");
    }
}
