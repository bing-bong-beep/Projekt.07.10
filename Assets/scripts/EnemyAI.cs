using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    [Header("Movement")]
    public float speed = 2f;
    public float chaseRange = 5f;
    public float attackDistance = 1f;

    [Header("Patrol")]
    public Transform[] patrolPoints;
    private int currentPoint = 0;

    [Header("Attack")]
    public int damage = 10;
    public float attackCooldown = 1.5f;
    private float lastAttackTime = 0f;

    [Header("References")]
    public Transform player;
    public Animator anim;

    private void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, transform.position);
        if(distanceToPlayer <= attackDistance)
        {
            Attack();
        }
        else if(distanceToPlayer <= chaseRange)
        {
            Chase();
        }
        else
        {
            Patrol();
        }


    }

    void Patrol()
    {
        //anim.SetBool("isMoving", true);
        Transform targetPoint = patrolPoints[currentPoint];

        transform.position = Vector2.MoveTowards(transform.position, targetPoint.position, speed * Time.deltaTime);

        if(Vector2.Distance(transform.position, targetPoint.position) < 0.1)
        {
            currentPoint = (currentPoint + 1) % patrolPoints.Length;
        }
    }

    void Chase()
    {

        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

    }

    void Attack()
    {

        if(Time.time > lastAttackTime + attackCooldown)
        {
            return;
        }
        
        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
        if(playerHealth != null)
        {
            playerHealth.TakeDamage(damage);    
        }
        lastAttackTime = Time.time;

    }
}
