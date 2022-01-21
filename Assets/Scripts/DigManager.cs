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

    private void Awake()
    {
        _instance = this;
        currentNumOfArtifacts = 0;
    }

    public void ArtifactFound()
    {
        currentNumOfArtifacts++;
        if (currentNumOfArtifacts == numberOfArtifacts)
        {
            Debug.Log("all artifacts found");
            finishCanvas.SetActive(true);
            GameManager.Instance.NextStage();
        }
    }

    public void ReturnToHub(string sceneName)
    {
        GameManager.Instance.UnloadSceneAsync(sceneName);
    }
}
