using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Scriptable Values", menuName = "Values/Vector Value")]
[System.Serializable]
public class VectorValue : ScriptableObject
{
    public Vector2 startingPosition;
    public Vector2 currentPosition;
}
