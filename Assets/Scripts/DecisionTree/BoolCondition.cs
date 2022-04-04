using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoolCondition : Condition
{
    public bool Value { get; set; }
    public bool Parameter { get; set; }

    public override bool isTrue()
    {
        return (Parameter == Value);
    }
}
