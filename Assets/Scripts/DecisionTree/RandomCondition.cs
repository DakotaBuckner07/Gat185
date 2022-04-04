using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCondition : Condition 
{
    public bool value { get; set; } 
    public override bool isTrue() 
    {
        if ((prevFrame + 1) != DecisionTree.frame) 
        {
            value = (Random.Range(0, 2) == 0) ? true : false;
        }
        prevFrame = DecisionTree.frame; 
        return value; 
    }
}