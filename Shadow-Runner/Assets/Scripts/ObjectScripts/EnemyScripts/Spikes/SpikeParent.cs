using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeParent : MonoBehaviour
{
    public static SpikeParent instance;
    [SerializeField] private ParticleSystem spikeEffect;
    [SerializeField] private GameObject spikeObject;


    private void Awake()
    {
        instance = this;
        
        spikeEffect = GetComponentInChildren<ParticleSystem>();
    }

    public void ChangeSpikeStates() 
    {
        spikeEffect.Play();
        spikeObject.SetActive(false);
    }
}
