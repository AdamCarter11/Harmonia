using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    private Image healthBar;
    public float currentHealth;
    private float maxHealth = 200f;
    PlayerHealth player;

    // Start is called before the first frame update
    void Start()
    {
        healthBar = GetComponent<Image>();
        player = FindObjectOfType<PlayerHealth>();
    }

    void Update()
    {
        currentHealth = player.health;
        healthBar.fillAmount = currentHealth / maxHealth;
        if (player.health == 100)
            healthBar.color = Color.yellow;
        else if (player.health == 30)
            healthBar.color = Color.red;
    }
}
