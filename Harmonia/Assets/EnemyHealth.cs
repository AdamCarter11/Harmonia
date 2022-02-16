using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health;
    public float maxHealth;

    public void setHealth(float val)
    {
        health = val;
        maxHealth = health;
    }

    public bool isDead()
    {
        if (health <= 0)
        {
            return true;
        }
        return false;
    }

    public void takeDamage(float damage)
    {
        health -= damage;
    }

    public float getHealth()
    {
        return health;
    }

    public float getMaxHealth()
    {
        return maxHealth;
    }
}
