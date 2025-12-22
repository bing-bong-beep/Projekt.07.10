using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
        {
            return;
        }

        Inventory playerInventory = null;
        playerInventory = collision.gameObject.GetComponent<Inventory>();

        if (playerInventory == null) return;

        playerInventory.Collect();

        Destroy(gameObject);


    }
    
}
