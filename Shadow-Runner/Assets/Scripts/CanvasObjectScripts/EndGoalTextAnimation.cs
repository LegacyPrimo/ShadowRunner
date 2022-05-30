using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGoalTextAnimation : MonoBehaviour
{
    public static EndGoalTextAnimation instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        transform.localScale = Vector2.zero;
    }

    public void AnimateText() 
    {
        transform.LeanScale(Vector2.one, 0.8f).setEaseInOutSine();
        StartCoroutine(MinimizeText());
    }

    private IEnumerator MinimizeText() 
    {
        yield return new WaitForSeconds(1.5f);
        transform.LeanScale(Vector2.zero, 1f).setEaseInBack();
        
    }
}
