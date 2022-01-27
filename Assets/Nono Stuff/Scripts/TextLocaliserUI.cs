using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextLocaliserUI : MonoBehaviour
{
    Text textField;
    public string key;
    void Start()
    {
        //faire la différence entre un objet Texte et un objet Sentence
        //--> parce qu'il faut faire la trad pour l'UI et les dialogues (si dialogue, prendre la variable "key" depuis le scipt Sentence
        textField = GetComponent<Text>();
        UpdateText();
        LocalisationManager.Instance.languageChanged.AddListener(UpdateText);
    }

    private void UpdateText()
    {
        string value = LocalisationManager.GetLocalisedValue(key);
        textField.text = value;
    }
}
