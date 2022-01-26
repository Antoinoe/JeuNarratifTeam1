using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoctorManager : MonoBehaviour
{
    [SerializeField] List<int> indexToUnlock;
    [SerializeField] List<DialogueTrigger> allDialogues;
    bool dialoguetriggered;
    [SerializeField] bool isDoctor = false;

    private void Start()
    {
        DialogueManager.Instance.EndOfDialogue.AddListener(NextStage);
    }
    public void CheckDialogues()
    {
        int currentStage = PlayerPrefs.GetInt("PlayerStage");

        for (int i = 0; i < allDialogues.Count; i++)
        {
            if (indexToUnlock[i] == currentStage) // change to always have the option to see this dialoque again
            {
                allDialogues[i].TriggerDialogue();
                if(isDoctor)
                    dialoguetriggered = true;
            }
        }
    }

    private void NextStage()
    {
        if (dialoguetriggered)
        {
            GameManager.Instance.NextStage();
        }
    }
}
