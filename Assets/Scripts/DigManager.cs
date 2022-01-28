using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DigManager : MonoBehaviour
{
    public static DigManager Instance { get { return _instance; } }
    private static DigManager _instance;
    [SerializeField] int numberOfArtifacts;
    int currentNumOfArtifacts = 0;
    [SerializeField] GameObject finishCanvas;
    [SerializeField] List<DialogueTrigger> dialogue = null;

    private void Awake()
    {
        _instance = this;
        currentNumOfArtifacts = 0;
        if (dialogue != null)
            dialogue[0].TriggerDialogue();
    }

    public void ArtifactFound()
    {
        currentNumOfArtifacts++;
        if (dialogue.Count > currentNumOfArtifacts)
            dialogue[currentNumOfArtifacts].TriggerDialogue();
        if (currentNumOfArtifacts == numberOfArtifacts)
        {
            Debug.Log("all artifacts found");
            finishCanvas.SetActive(true);
            //
        }
    }

    public void ReturnToHub(string sceneName)
    {
        GameManager.Instance.NextStage();
        GameManager.Instance.UnloadSceneAsync(sceneName);
    }
}
