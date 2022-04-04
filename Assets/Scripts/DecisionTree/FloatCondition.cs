using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatCondition : Condition
{
    public enum eCompare
    {
        Equal,
        Greater,
        Less
    }

    public eCompare Compare { get; set; } = eCompare.Equal;
    public float CompareFloat
    {
        set 
        {
            Compare = (eCompare)value;
        }
    }
    public float Value { get; set; }
    public string ValueString
    {
        set
        {
            float.TryParse(value, out float v);
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
                isTrue = Parameter == Value;
                break;
            case eCompare.Greater:
                isTrue = Parameter > Value;
                break;
            case eCompare.Less:
                isTrue = Parameter < Value;
                break;
        }
        return isTrue;
    }
}
