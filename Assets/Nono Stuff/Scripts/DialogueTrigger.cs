using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour
{
    /*    public string name;
        public Sprite sprite;
        public Dialogue[] dialogue;
        */
    public float textSpeed;
    public Sentence[] sentence;
    
    public void TriggerDialogue()
    {
        //print(sentence[0].npcName);
        DialogueManager.Instance.InitializeDialogue(sentence, textSpeed);
    }
}
