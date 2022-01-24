using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] Text _outputContent, _outputName;
    [SerializeField] Image _outputSprite;

    Sentence[] _sentences;
    int _index;
    float _textSpeed, _currentTextSpeed;
    bool _isTextFullyDisplayed = false;
    public void InitializeDialogue(Sentence[] sentences, float textSpeed)
    {
        //display dialogue box
        _sentences = sentences;
        _index = 0;
        _textSpeed = textSpeed;
        _currentTextSpeed = _textSpeed;
        StartDialogue(_index);
    }
    public void StartDialogue(int index)
    {
        print("starting conversation with " + _sentences[index].npcName);
        _outputName.text = _sentences[index].npcName;
        _outputSprite.sprite = _sentences[index].npcSprite;
        StartCoroutine(DisplayText(_sentences[index].sentence));
    }

    public void NextSentence()
    {
        if (_isTextFullyDisplayed)
        {
            if (_index >= _sentences.Length - 1)
            {
                EndConversation();
                return;
            }
            _index += 1;
            StartDialogue(_index);
        }
        else
        {
            _currentTextSpeed = 0;
            print("speeding process");
        }
        
    }

    private void EndConversation()
    {
        print("conversation has ended");
        //close dialogue box
    }

    IEnumerator DisplayText(string text)
    {
        _isTextFullyDisplayed = false;
        _outputContent.text = "";
        foreach (char letter in text.ToCharArray())
        {
            yield return new WaitForSeconds(_currentTextSpeed);
            _outputContent.text += letter;
        }
        _isTextFullyDisplayed = true;
        _currentTextSpeed = _textSpeed;
    }
}
