using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadArtifact : MonoBehaviour
{
    public int artifactNum;
    bool puzzleDone = false;
    public string puzzleSceneName;
    public string viewSceneName;
    void Start()
    {
        string arifatcName = "Artifact" + artifactNum;
        puzzleDone = PlayerPrefs.GetInt(arifatcName) == 1;
    }

   public void ArtifactLoad()
    {
        if (puzzleDone)
        {
            GameManager.Instance.LoadAndUnloadSceneAsync(viewSceneName, "Table");
        }else
        {
            GameManager.Instance.LoadAndUnloadSceneAsync(puzzleSceneName, "Table");
        }
    }
}
