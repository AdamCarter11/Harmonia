using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    private Image healthBar;
    public float currentHealth;
    private float maxHealth;
    PlayerHealth player;

    GameObject mozartText;
    GameObject panel;

    // Start is called before the first frame update
    void Start()
    {
        healthBar = GetComponent<Image>();
        player = FindObjectOfType<PlayerHealth>();
        maxHealth = player.getMaxHealth();
        panel = GameObject.Find("TextPanel");
    }

    void Update()
    {
        currentHealth = player.getHealth();
        healthBar.fillAmount = currentHealth / maxHealth;
        if (player.health == maxHealth/2)
        {
            healthBar.color = Color.yellow;
            textBasedOnHealth(3, "Baha! You are no match for a virtuoso such as myself.");
        }
        else if (player.health == maxHealth/5)
            healthBar.color = Color.red;
    }
    
    void textBasedOnHealth(float duration, string comment)
    {
        panel.SetActive(true);
        mozartText = GameObject.Find("MozartText");
        Text mtext = mozartText.GetComponent<Text>();
        mtext.text = comment;
        StartCoroutine(setTextBack(duration));
    }

    IEnumerator setTextBack(float duration)
    {
        yield return new WaitForSeconds(duration);
        panel.SetActive(false);
    }
}
