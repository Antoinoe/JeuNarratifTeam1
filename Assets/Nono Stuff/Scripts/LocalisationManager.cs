using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalisationManager : MonoBehaviour
{
    public enum Language
    {
        English,
        French,
        //zhong guo (*-*()
    };

    public static Language language = Language.French; // à changer quand on appuie sur le bouton du menu d'option
    private static Dictionary<string, string> localisedEN;
    private static Dictionary<string, string> localisedFR;

    public static bool isInit;

    public static void Init()
    {
        CSVLoader csvloader = new CSVLoader();
        csvloader.LoadCSV();

        localisedEN = csvloader.GetDictionaryValues("en");
        localisedFR = csvloader.GetDictionaryValues("fr");
        isInit = true;
    }

    public static string GetLocalisedValue(string key)
    {
        if (!isInit) { Init(); }
        string value = key;
        switch (language)
        {
            case Language.English:
                localisedEN.TryGetValue(key, out value);
                break;

            case Language.French:
                localisedFR.TryGetValue(key, out value);
                break;
        }
 
        return value;
    }
}
