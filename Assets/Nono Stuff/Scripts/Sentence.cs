using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Sentence
{
    public string npcName;
    public Sprite npcSprite;
    [TextArea(2, 10)] public string sentence;
    
}
