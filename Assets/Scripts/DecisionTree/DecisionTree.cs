using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecisionTree : MonoBehaviour
{
    public DecisionNode root;
    public static int frame = 0;

    void Update()
    {
        DecisionNode[] nodes = FindObjectsOfType<DecisionNode>();
        foreach (var n in nodes) n.State = DecisionNode.eState.Inactive;
        frame++;
        if(root != null) root.Execute();
    }
}
