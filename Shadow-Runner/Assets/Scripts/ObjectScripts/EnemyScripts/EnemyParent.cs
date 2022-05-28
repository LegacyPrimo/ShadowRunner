using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyParent : MonoBehaviour
{
    [Header("Enemy Settings")]
    public Transform enemyTarget;
    [SerializeField] private FloatValue moveAreaValue;
    [SerializeField] private FloatValue attackAreaValue;
    [SerializeField] private FloatValue enemySpeedValue;

    public float moveArea;
    public float attackArea;
    public float enemySpeed;

    public Animator animator;
    public Rigidbody2D rigidbody;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
        enemyTarget = GameObject.FindGameObjectWithTag("Player").transform;
        moveArea = moveAreaValue.initialValue;
        attackArea = attackAreaValue.initialValue;
        enemySpeed = enemySpeedValue.initialValue;

    }

    private void FixedUpdate()
    {
        CheckEnemyDistance();
    }

    public virtual void CheckEnemyDistance()
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
            animator.SetBool("isWalking", false);
        }
    }

    private void SetAnimationFloat(Vector2 vector)
    {
        animator.SetFloat("moveX", vector.x);
    }

    public void SetAnimation(Vector2 direction)
    {
        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            if (direction.x > 0)
            {
                SetAnimationFloat(Vector2.right);
            }
            if (direction.x < 0)
            {
                SetAnimationFloat(Vector2.left);
            }
        }
    }
}
