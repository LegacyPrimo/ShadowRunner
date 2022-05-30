using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CongratulationsManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AnimateText();   
    }

    public void AnimateText()
    {
        transform.LeanScale(Vector2.one, 0.8f).setEaseInOutSine();
        StartCoroutine(MinimizeText());
    }

    private IEnumerator MinimizeText()
    {
        yield return new WaitForSeconds(10f);
        transform.LeanScale(Vector2.zero, 1f).setEaseInBack();

    }
}
