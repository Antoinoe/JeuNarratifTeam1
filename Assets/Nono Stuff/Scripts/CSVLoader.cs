using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
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

    public Dictionary<string, string> GetDictionaryValues(string attributeId)
    {
        Dictionary<string, string> dictionary = new Dictionary<string, string>();
        string[] lines = csvFile.text.Split(lineSeparator);
        int attributeIndex = -1;
        string[] headers = lines[0].Split(fieldSeparator, System.StringSplitOptions.None);

        for (int i = 0; i < headers.Length; i++)
        {
            if (headers[i].Contains(attributeId))
            {
                attributeIndex = i;
                print(attributeIndex);
                break;
            }
        }

        Regex CSVParser = new Regex(",(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))");

        for (int i = 1; i < lines.Length; i++)
        {
            string line = lines[i];
            string[] fields = CSVParser.Split(line);

            for (int f = 0; f < fields.Length; f++)
            {
                fields[f] = fields[f].TrimStart(' ', surround);
                fields[f] = fields[f].TrimEnd(surround);
            }

            if (fields.Length > attributeIndex)
            {
                var key = fields[0];

                if (dictionary.ContainsKey(key)) { continue; }

                var value = fields[attributeIndex];

                dictionary.Add(key, value);
                print(key+" "+ value);
                //expected output - exemple : key = "0001" - value = "Hi I'm Samantha!" si en anglais et "Salut moi c'est Samantha!" en français
                //actual result : key = "0001" - value "0001" peu importe la langue séléctionnée
            }
        }
        return dictionary;
    }
}
