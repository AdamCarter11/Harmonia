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

    GameObject mozartText;
    GameObject panel;

    // Start is called before the first frame update
    void Start()
    {
        healthBar = GetComponent<Image>();
        player = FindObjectOfType<PlayerHealth>();

        panel = GameObject.Find("TextPanel");
    }

    void Update()
    {
        currentHealth = player.health;
        healthBar.fillAmount = currentHealth / maxHealth;
        if (player.health == 100)
        {
            healthBar.color = Color.yellow;
            textBasedOnHealth(3, "Baha! You are no match for a virtuoso such as myself.");
        }
        else if (player.health == 30)
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
