using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoctorManager : MonoBehaviour
{
    [SerializeField] GameTimeline timeline;
    [System.Serializable]
    class ExpertDialogues
    {
        public string name;
        int _indexToUnlock;
        public int indexToUnlock
        {
            get { return _indexToUnlock; }
            set { _indexToUnlock = value; }
        }
    }
    [SerializeField] List<ExpertDialogues> allDialogues;

    private void Start()
    {
        for(int i = 0; i < allDialogues.Count; i++)
        {
            foreach (GameTimeline.interactable item in timeline.timeline)
            {
                if (item.name == allDialogues[i].name)
                {
                    allDialogues[i].indexToUnlock = item.indexToUnlock;
                }
                    
            }
        }
    }

    public void CheckDialogues()
    {
        int currentStage = PlayerPrefs.GetInt("PlayerStage");

        foreach (ExpertDialogues item in allDialogues)
        {
            if(item.indexToUnlock == currentStage) // change to always have the option to see this dialoque again
            {
                DialogueManager.Instance.StartDialogue(GameObject.FindObjectOfType<DialogueTrigger>(), currentStage);
            }
        }
    }
}
