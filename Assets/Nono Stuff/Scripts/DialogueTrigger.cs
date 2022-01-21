using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour
{
    public string name;
    public Sprite sprite;
    public Dialogue[] dialogue;
    
    public void TriggerDialogue( int index)
    {
        FindObjectOfType<DialogueManager>().StartDialogue(this, index);
    }
}
