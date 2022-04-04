using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtilityObject : MonoBehaviour
{
    public string id;
    public string animationID;
    public float duration;
    public Transform location;
    public GameObject actionFX;
    public UtilityScore[] Scores { get; set; }

    void Start()
    {
        Scores = GetComponentsInChildren<UtilityScore>();
    }

    public float GetScore(string inId)
    {
        float change = 0;
        foreach(var score in Scores)
        {
            if (score.id == inId) change += score.change;
        }

        return change;
    }
}
