using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthHandler : MonoBehaviour
{
    public int maxHealth;
    public int health;
    [SerializeField] private bool canBeHealed;

    public void ApplyDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            health = 0;
            Destroy(gameObject);
        }
    }

    public bool Heal(int healing)
    {
        bool healed = true;

        if (canBeHealed)
        {
            health += healing;

            if (health > maxHealth)
            {
                health = maxHealth;
                healed = false;
            }
        } else
        {
            healed = false;
        }

        return healed;
    }

    private void Start()
    {
        health = maxHealth;
    }
}
