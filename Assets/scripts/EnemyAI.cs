using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 2f;          
    public float chaseDistance = 4f;  
    public float attackDistance = 1f; 

    [Header("Patrol")]
    public Transform[] patrolPoints;  
    private int currentPoint = 0;     

    [Header("References")]
    public Transform player;        
    public Animator anim;         

    [Header("Attack")]
    public int damage = 10;        
    public float attackCooldown = 1.5f; 
    private float lastAttackTime;

    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.position);

        if (distance <= attackDistance)
        {
            Attack();
        }
        else if (distance <= chaseDistance)
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
      
        Transform target = patrolPoints[currentPoint];

        transform.position = Vector2.MoveTowards(
            transform.position,
            target.position,
            speed * Time.deltaTime
        );

        if (Vector2.Distance(transform.position, target.position) < 0.1f)
        {
            currentPoint = (currentPoint + 1) % patrolPoints.Length;
        }

        Flip(target.position.x - transform.position.x);
    }

    void Chase()
    {

        transform.position = Vector2.MoveTowards(
            transform.position,
            player.position,
            speed * Time.deltaTime
        );

        Flip(player.position.x - transform.position.x);
    }

    void Attack()
    {
        if (Time.time < lastAttackTime + attackCooldown)
            return;

        anim.SetTrigger("Attack");

        PlayerHealth stats = player.GetComponent<PlayerHealth>();
        if (stats != null)
        {
            stats.TakeDamage(damage);
        }

        lastAttackTime = Time.time;
    }

    void Flip(float directionX)
    {
        if (Mathf.Abs(directionX) < 0.01f) return;

        transform.localScale = new Vector3(
            Mathf.Sign(directionX),
            1,
            1
        );
    }



}
