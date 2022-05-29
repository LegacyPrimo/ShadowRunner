using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GaugeSlideObject : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        animator.SetBool("Normal", true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
