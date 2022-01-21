using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance { get { return _instance; } }
    private static DialogueManager _instance;
    Queue<string> sentences;
    [SerializeField] GameObject outputCanvas;
    [SerializeField] Text outputContent, outputName;
    [SerializeField] Image outputSprite;
    DialogueTrigger _nextNpc;
    int _nextNpcDialIndex;

    public UnityEngine.Events.UnityEvent EndOfDialogue;
    void Start()
    {
        _instance = this;
        sentences = new Queue<string>();
    }

    public void StartDialogue(DialogueTrigger npc, int dialogueNbr)
    {
        outputCanvas.SetActive(true);
        _nextNpc = npc.dialogue[dialogueNbr].nextNpcToTalk;
        _nextNpcDialIndex = npc.dialogue[dialogueNbr].nextDialogueIndexToShow;
        outputSprite.sprite = npc.sprite;

        Debug.Log("starting conversation with " + npc.name);
        outputName.text = npc.name;
        sentences.Clear();
        foreach(string sentence in npc.dialogue[dialogueNbr].sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
        
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        print(sentence);
        outputContent.text = sentence;
        
    }

    private void EndDialogue()
    {
        if(_nextNpc == null)
        {
            print("!!!end of conversation!!!");
            EndOfDialogue.Invoke(); 
            outputCanvas.SetActive(false);
            // quitte le dialogue
        }
        else
        {
            StartDialogue(_nextNpc, _nextNpcDialIndex);
        }
    }
}
