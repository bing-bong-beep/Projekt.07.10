using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] public int maxHealth = 100;
    [SerializeField] public int Health = 100;
    //public Animator anim;
    public TextMeshProUGUI textHealth;

    void Start()
    {
        //anim = GetComponent<Animator>();
        textHealth.text = Health.ToString();
    }

    public bool isDead = false;

    public void TakeDamage(int damage)
    {
        Health = Health - damage;
        if (Health < 0)
        {
            Health = 0;
        }
        if (Health > maxHealth)
        {
            Health = maxHealth;
        }

        if (Health == 0)
        {
            isDead = true;
            //anim.SetTrigger("IsDead");
            Invoke(nameof(ReloadScene), 2);
        }
        textHealth.text = Health.ToString();

    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void SetHealth(int health)
    {
        Health = health;
        textHealth.text = health.ToString();
    }
}
