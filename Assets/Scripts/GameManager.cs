using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get { return _instance; } }
    private static GameManager _instance;
    
    [SerializeField] int numberOfArtifacts;
    int currentNumOfArtifacts = 0;

    private void Awake()
    {
        _instance = this;
        currentNumOfArtifacts = 0;
    }

    public void ArtifactFound()
    {
        currentNumOfArtifacts++;
        if(currentNumOfArtifacts == numberOfArtifacts)
        {
            Debug.Log("all artifacts found");
        }
    }
}
