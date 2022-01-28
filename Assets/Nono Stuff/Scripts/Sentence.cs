using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[System.Serializable]
public class Sentence
{
    public string npcName;
    public Sprite npcSprite;
    public string locKey; //cl� csv � r�cup�rer depuis le TextLocaliserUI
    [TextArea(2, 10)] public string sentence;// endroit � indiquer pour changer la langue
    
}
