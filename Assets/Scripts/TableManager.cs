using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableManager : MonoBehaviour
{
    public List<int> stageToUnlock;
    public List<GameObject> artifactsToUnlock;
    private void Start()
    {
        int currentStage = GameManager.Instance.currentStage;
        for (int i = 0; i < artifactsToUnlock.Count; i++)
        {
            if(stageToUnlock[i] <= currentStage)
            {
                artifactsToUnlock[i].SetActive(true);
            }
        }
    }

    public void LoadArtifact(string sceneName)
    {
        GameManager.Instance.LoadSceneAsync(sceneName);
    }
    
    public void BackToHub()
    {
        GameManager.Instance.UnloadSceneAsync("Table");
    }
}
