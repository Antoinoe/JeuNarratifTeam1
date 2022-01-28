using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DigSiteEntrance : MonoBehaviour
{
    public int enterAtStage = 1;

    public void CheckEntrance(string sceneToLoad)
    {
        if(GameManager.Instance.currentStage == enterAtStage)
        {
            GameManager.Instance.LoadSceneAsync(sceneToLoad);
        }
        else
        {
            Debug.Log("can't enter");
        }
    }
}
