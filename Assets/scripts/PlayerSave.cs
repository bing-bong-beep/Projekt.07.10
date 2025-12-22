using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSave : MonoBehaviour
{
    public PlayerHealth health;
    public Inventory inventory;
    

    private void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.S))
        {
            Save();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            Load();
        }    
                       
    }

    public void Save()
    {
        SaveData data = new SaveData();
        data.health = health.Health;
        data.coins = inventory.numberCollectible;
        data.position = new float[]
        {
            transform.position.x,
            transform.position.y,
            transform.position.z,
        };
        SaveSystem.Save(data);
        Debug.Log("Game Saved");
    }

    public void Load()
    {
        SaveData data = SaveSystem.Load();
       
        transform.position = new Vector3(
            data.position[0],
            data.position[1],
            data.position[2]
        );
        health.SetHealth(data.health);
        inventory.SetInventory(data.coins);
        Debug.Log("Game Loaded");
    }

}
