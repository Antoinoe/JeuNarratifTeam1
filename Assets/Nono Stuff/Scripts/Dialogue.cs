using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Dialogue
{
    public string dialogueDescription;
    [TextArea(2,10)]
    public string[] sentences;
    public DialogueTrigger nextNpcToTalk;
    public int nextDialogueIndexToShow;
    //public Image characterSprite;
}
