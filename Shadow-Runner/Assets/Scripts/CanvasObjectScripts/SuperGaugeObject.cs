using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuperGaugeObject : MonoBehaviour
{
    [SerializeField] private Slider gaugeSlider;
    [SerializeField] private FloatValue deathCounter;

    public bool enableSuper;

    // Start is called before the first frame update
    void Start()
    {
        gaugeSlider.maxValue = deathCounter.initialValue;
        gaugeSlider.value = 0;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateDeathCounter();

        if (gaugeSlider.value == gaugeSlider.maxValue) 
        {
            enableSuper = true;
        }
    }

    void UpdateDeathCounter() 
    {
        gaugeSlider.value = deathCounter.runtimeValue;
    }
}
