using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{

    public int damage = 40;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
        {
            return;
        }

        PlayerHealth health = collision.gameObject.GetComponent<PlayerHealth>();

        if (health == null)
        {
            return;
        }

        health.TakeDamage(damage);

    }
}
