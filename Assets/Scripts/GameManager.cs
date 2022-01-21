using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get { return _instance; } }
    private static GameManager _instance;

    [SerializeField] GameObject hub;

    int currentStage;

    private void Start()
    {
        _instance = this;
        currentStage = PlayerPrefs.GetInt("PlayerStage");
        DialogueManager.Instance.EndOfDialogue.AddListener(NextStage);

        if (currentStage == 0)
        {
            DialogueManager.Instance.StartDialogue(GameObject.FindObjectOfType<DialogueTrigger>(), 0);
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
        hub.SetActive(true);
        SceneManager.UnloadSceneAsync(sceneName);
    }

    public void NextStage()
    {
        currentStage++;
        Debug.Log(currentStage);
        PlayerPrefs.SetInt("PlayerStage", currentStage);
        PlayerPrefs.Save();
    }
}