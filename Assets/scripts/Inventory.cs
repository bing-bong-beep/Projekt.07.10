using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public int numberCollectible;
    public TextMeshProUGUI textCollectible;

    public void Collect()
    {
        numberCollectible++;
        textCollectible.text = numberCollectible.ToString();
    }

    public void SetInventory(int inventory)
    {
        numberCollectible = inventory;
        textCollectible.text = numberCollectible.ToString();
    }
}
