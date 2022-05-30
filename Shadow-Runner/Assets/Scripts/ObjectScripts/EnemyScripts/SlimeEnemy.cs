using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeEnemy : EnemyParent
{
    [Header("Enemy Pathing")]
    [SerializeField] Transform[] paths;
    [SerializeField] private int currentPathPoint;
    [SerializeField] private Transform currentPathGoal;
    [SerializeField] private float roundDistance;
    private ParticleSystem deathEffect;
    private SpriteRenderer thisRenderer;
    private PolygonCollider2D thisCollider;

    private void Awake()
    {
        thisCollider = GetComponent<PolygonCollider2D>();
        thisRenderer = GetComponent<SpriteRenderer>();
        deathEffect = GetComponentInChildren<ParticleSystem>();
    }

    public override void CheckEnemyDistance()
    {
        if (Vector3.Distance(enemyTarget.position, transform.position) <= moveArea && Vector3.Distance(enemyTarget.position, transform.position) > attackArea)
        {
            Vector3 temporary = Vector3.MoveTowards(transform.position, enemyTarget.position, enemySpeed * Time.fixedDeltaTime);
            SetAnimation(temporary - transform.position);
            rigidbody.MovePosition(temporary);
            animator.SetBool("isWalking", true);
        }

        if (Vector3.Distance(enemyTarget.position, transform.position) > moveArea)
        {
            if (Vector3.Distance(transform.position, paths[currentPathPoint].position) > roundDistance)
            {
                Vector3 temporary = Vector3.MoveTowards(transform.position, paths[currentPathPoint].position, enemySpeed * Time.fixedDeltaTime);
                SetAnimation(temporary - transform.position);
                animator.SetBool("isWalking", true);
                rigidbody.MovePosition(temporary);
            }
            else
            {
                ChangeIdlePathing();
            }
        }
    }

    private void ChangeIdlePathing()
    {
        if (currentPathPoint == paths.Length - 1)
        {
            currentPathPoint = 0;
            currentPathGoal = paths[0];
        }
        else 
        {
            currentPathPoint++;
            currentPathGoal = paths[currentPathPoint];
        }
    }

    private void DisableObject() 
    {
        this.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("HitBox")) 
        {
            deathEffect.Play();
            thisRenderer.enabled = false;
            thisCollider.enabled = false;
            Invoke("DisableObject", 0.8f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player") && PlayerController.instance.superIsPressed == false)
        {
            PlayerController.instance.CheckHealth(enemyAttack);
        }

        if (collision.collider.CompareTag("Player") && PlayerController.instance.superIsPressed == true)
        {
            deathEffect.Play();
            thisRenderer.enabled = false;
            thisCollider.enabled = false;
            Invoke("DisableObject", 0.8f);
        }


    }

}
