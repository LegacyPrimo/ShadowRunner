using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuperGaugeObject : MonoBehaviour
{
    public static SuperGaugeObject instance;

    [SerializeField] private Slider gaugeSlider;
    [SerializeField] private FloatValue deathCounter;

    [SerializeField] private FloatValue startTimer;
    [SerializeField] private float currentTime;

    public bool enableSuper;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        enableSuper = false;
        gaugeSlider.maxValue = deathCounter.initialValue;
        gaugeSlider.value = 0;

        ResetSuperGauge();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateDeathCounter();
        EnableSuper();
        UseSuperGauge();
    }

    private void UpdateDeathCounter() 
    {
        gaugeSlider.value = deathCounter.runtimeValue;
    }

    private void ResetSuperGauge() 
    {
        currentTime = startTimer.initialValue;
    }

    private void EnableSuper() 
    {
        if (gaugeSlider.value == gaugeSlider.maxValue)
        {
            enableSuper = true;
        }
    }

    private void UseSuperGauge() 
    {
        if (enableSuper == true && PlayerController.instance.superIsPressed == true) 
        {
            currentTime -= 1 * Time.deltaTime;
            gaugeSlider.value = currentTime;

            if (currentTime <= 0)
            {
                deathCounter.runtimeValue = 0;
                currentTime = 0;
                gaugeSlider.value = 0;
                PlayerController.instance.superIsPressed = false;

                if (currentTime == 0)
                {
                    gaugeSlider.value = 0;
                    enableSuper = false;
                }
            }
        }
        
    }
}
