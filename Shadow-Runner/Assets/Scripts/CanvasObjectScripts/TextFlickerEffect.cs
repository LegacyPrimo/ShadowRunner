using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextFlickerEffect : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI clickTextObject;

    private void Awake()
    {
        clickTextObject = GetComponent<TextMeshProUGUI>();
    }

    // Start is called before the first frame update
    void Start()
    {
        StartToFlicker();   
    }

    private void StartToFlicker() 
    {
        StopCoroutine(FlickerTextEffect());
        StartCoroutine(FlickerTextEffect());
    }

    private IEnumerator FlickerTextEffect() 
    {
        while (true) 
        {
            switch (clickTextObject.color.a.ToString()) 
            {
                case "0":
                    clickTextObject.color = new Color(clickTextObject.color.r, clickTextObject.color.g, clickTextObject.color.b, 1);
                    yield return new WaitForSeconds(0.5f);
                    break;
                case "1":
                    clickTextObject.color = new Color(clickTextObject.color.r, clickTextObject.color.g, clickTextObject.color.b, 0);
                    yield return new WaitForSeconds(0.5f);
                    break;
            }
        }
    }
}
