using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeObject : MonoBehaviour
{
    private SpikeParent spikeParent;
    [SerializeField] private FloatValue enemyDamage;

    private void Awake()
    {
        spikeParent = GetComponentInParent<SpikeParent>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player") && PlayerController.instance.superIsPressed == false)
        {
            PlayerController.instance.CheckHealth(enemyDamage.runtimeValue);
        }

        if (collision.collider.CompareTag("Player") && PlayerController.instance.superIsPressed == true)
        {
            spikeParent.ChangeSpikeStates();
        }
    }
}
