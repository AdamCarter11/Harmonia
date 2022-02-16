using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
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

    public void addHealth(float val)
    {
        if (health + val > maxHealth)
        {
            health = maxHealth;
        }
        else
        {
            health += val;
        }
    }

    public float getMaxHealth()
    {
        return maxHealth;
    }
    public float getHealth()
    {
        return health;
    }
}
