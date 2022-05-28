using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesObject : MonoBehaviour
{
    [SerializeField] private FloatValue enemyDamage;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player") && PlayerController.instance.superIsPressed == false)
        {
            PlayerController.instance.CheckHealth(enemyDamage.runtimeValue);
        }

        if (collision.collider.CompareTag("Player") && SuperGaugeObject.instance.enableSuper == true && PlayerController.instance.superIsPressed == true) 
        {
            SpikeParent.instance.ChangeSpikeStates();
        }
    }
}
