using System;
using UnityEngine;

[Serializable]
public class BoolReference
{
    [SerializeField] private bool useConstant = true;
    [SerializeField] private bool constantValue;
    [SerializeField] private BoolVariable variable;

    public bool Value {
        get => useConstant ? constantValue : variable != null && variable.Value;

        set 
        {
            if(useConstant) 
            {
                constantValue = value;
            }
            else if (variable != null) 
            {
                variable.Value = value;
            }
        }
    }

    public bool useConstantValue { get => useConstant; }
}
