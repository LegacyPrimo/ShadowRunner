using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This is the Parent Class for the Enemy Objects. The methods here are generalized but can be overriden when it is needed, especially the movement of the objects.


public class EnemyParent : MonoBehaviour
{
    [Header("Enemy Settings")]
    public Transform enemyTarget;
    [SerializeField] private FloatValue moveAreaValue;
    [SerializeField] private FloatValue attackAreaValue;
    [SerializeField] private FloatValue enemySpeedValue;
    [SerializeField] private FloatValue enemyAttackValue;

    public float moveArea;
    public float attackArea;
    public float enemySpeed;
    public float enemyAttack;

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
        enemyAttack = enemyAttackValue.initialValue;
    }

    private void FixedUpdate()
    {
        CheckEnemyDistance();
    }

    //Checking Enemy Distance can be overriden especially if it is decided if we will need pathing and other things etc.
    //It can also be noted that this is the general movement for the enemy without the pathing.
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

    #region Setting the animation Movement for the Enemy Characters
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
    #endregion

    #region Collision Methods
    //It is usually mainly for the Player effect, if there is still time then, enemy to enemy might come to effect in the future
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player") && PlayerController.instance.superIsPressed == false) 
        {
            PlayerController.instance.CheckHealth(enemyAttack);
        }
    }
    #endregion
}
