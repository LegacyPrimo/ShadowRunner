using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesObject : MonoBehaviour
{
    [SerializeField] private FloatValue enemyDamage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player") && SuperGaugeObject.instance.enableSuper == false)
        {
            PlayerController.instance.CheckHealth(enemyDamage.runtimeValue);
        }

        if (collision.collider.CompareTag("Player") && SuperGaugeObject.instance.enableSuper == true) 
        {
            Destroy(this.gameObject);
        }
    }
}
