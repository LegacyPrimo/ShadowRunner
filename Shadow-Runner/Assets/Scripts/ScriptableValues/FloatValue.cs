using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Scriptable Values", menuName = "Values/Float Value")]
[System.Serializable]
public class FloatValue : ScriptableObject
{
    public float initialValue;
    public float runtimeValue;
}
