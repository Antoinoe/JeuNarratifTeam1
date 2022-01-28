using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [System.Serializable]
    public struct interactable
    {
        public string name;
        public string description;
        public DialogueTrigger dialogue;
    }

    public static GameManager Instance { get { return _instance; } }
    private static GameManager _instance;

    [SerializeField] GameObject hub;
    public bool returnTohubWithNextStag = false;

    int currentDialogue = 0;

    public int currentStage = 0;
    [SerializeField] List<interactable> timeline;

    private void Start()
    {
        _instance = this;
        currentStage = PlayerPrefs.GetInt("PlayerStage");
        //currentDialogue = PlayerPrefs.GetInt("DialogueStage");
        //DialogueManager.Instance.EndOfDialogue.AddListener(NextStage);

        if (currentStage == 0)
        {
            timeline[0].dialogue.TriggerDialogue();
            PlayerPrefs.SetInt("DialogueStage", currentDialogue);
            Debug.Log("tuto");
        }
    }

    public void LoadSceneAsync(string sceneName)
    {
        hub.SetActive(false);
        SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
    }
    
    public void UnloadSceneAsync(string sceneName)
    {
        if (returnTohubWithNextStag)
        {
            returnTohubWithNextStag = false;
            NextStage();
        }
        hub.SetActive(true);

        SceneManager.UnloadSceneAsync(sceneName);
    }
    
    public void LoadAndUnloadSceneAsync(string sceneNameToLoad, string sceneNameToUnload)
    {
        SceneManager.UnloadSceneAsync(sceneNameToUnload);
        SceneManager.LoadSceneAsync(sceneNameToLoad, LoadSceneMode.Additive);
    }

    public void NextStage()
    {
        currentStage++;
        PlayerPrefs.SetInt("PlayerStage", currentStage);
        PlayerPrefs.Save();
        
        if(timeline.Count >= currentStage && timeline[currentStage].dialogue != null )
            timeline[currentStage].dialogue.TriggerDialogue();
        
    }
}