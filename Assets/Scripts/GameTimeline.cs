using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "timeline", menuName = "Story/GameTimeline", order = 1)]
public class GameTimeline : ScriptableObject
{
    [System.Serializable]
    public struct interactable
    {
        public string name;
        public string description;
        public int indexToUnlock;

    }

    public List<interactable> timeline;
}
