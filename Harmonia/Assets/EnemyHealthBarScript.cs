using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBarScript : MonoBehaviour
{
    private Image healthBar;
    public float currentHealth;
    private float maxHealth;
    EnemyHealth enemy;

    // Start is called before the first frame update
    void Start()
    {
        healthBar = GetComponent<Image>();
        enemy = FindObjectOfType<EnemyHealth>();
        maxHealth = enemy.getMaxHealth();
        currentHealth = enemy.getHealth();
    }

    void Update()
    {
        currentHealth = enemy.getHealth();
        healthBar.fillAmount = currentHealth / maxHealth;
        if (currentHealth == maxHealth / 2)
            healthBar.color = Color.yellow;
        else if (currentHealth == maxHealth / 5)
            healthBar.color = Color.red;
    }
}
