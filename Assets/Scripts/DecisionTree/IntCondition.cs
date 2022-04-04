using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntCondition : Condition
{
    public enum eCompare
    {
        Equal,
        Greater,
        Less
    }

    public eCompare Compare { get; set; } = eCompare.Equal;
    public int CompareInt 
    {
        set 
        {
            Compare = (eCompare)value;
        }
    }
    public int Value { get; set; }
    public string ValueString
    {
        set
        {
            int.TryParse(value, out int v);
            Value = v;
        }
    }
    public float Parameter { get; set; }

    public override bool isTrue()
    {
        bool isTrue = false;
        switch (Compare)
        {
            case eCompare.Equal:
                isTrue = ((int)Parameter == Value);
                break;
            case eCompare.Greater:
                isTrue = ((int)Parameter > Value);
                break;
            case eCompare.Less:
                isTrue = ((int)Parameter < Value);
                break;
            default:
                break;
        }
        return isTrue;
    }
}
