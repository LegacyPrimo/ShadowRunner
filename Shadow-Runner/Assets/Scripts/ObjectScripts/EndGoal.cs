using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGoal : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private ParticleSystem coinEffect;

    private bool isFinished;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            animator.SetBool("isFinished", true);
            coinEffect.Play();
            EndGoalTextAnimation.instance.AnimateText();
            PlayerController.instance.ResetHealth();
            
            isFinished = true;
            StartCoroutine(DisableObject());
        }
    }

    private IEnumerator DisableObject() 
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        this.gameObject.SetActive(false);
        
    }
}
