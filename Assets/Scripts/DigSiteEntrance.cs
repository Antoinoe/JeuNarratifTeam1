using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DigSiteEntrance : MonoBehaviour
{
    public int enterAtStage = 1;
    [SerializeField] GameTimeline timeline;

    private void Start()
    {
        foreach (GameTimeline.interactable item in timeline.timeline)
        {
            if (item.name == gameObject.name)
                enterAtStage = item.indexToUnlock;
        }
    }
    public void CheckEntrance(string sceneToLoad)
    {
        if(PlayerPrefs.GetInt("PlayerStage") == enterAtStage)
        {
            GameManager.Instance.LoadSceneAsync(sceneToLoad);
        }
        else
        {
            Debug.Log("can't enter");
        }
    }
}
