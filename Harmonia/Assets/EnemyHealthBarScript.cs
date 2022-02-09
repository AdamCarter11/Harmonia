using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBarScript : MonoBehaviour
{
    private Image healthBar;
    public float currentHealth;
    private float maxHealth = 200f;
    EnemyHealth enemy;

    // Start is called before the first frame update
    void Start()
    {
        healthBar = GetComponent<Image>();
        enemy = FindObjectOfType<EnemyHealth>();
    }

    void Update()
    {
        currentHealth = enemy.health;
        healthBar.fillAmount = currentHealth / maxHealth;
        if (enemy.health == 100)
            healthBar.color = Color.yellow;
        else if (enemy.health == 30)
            healthBar.color = Color.red;
    }
}
