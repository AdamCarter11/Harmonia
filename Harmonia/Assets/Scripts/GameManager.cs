using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int combo;
    public float notesHit;
    public float totalNotes;
    public float accuracy;
    public Text judgementText;
    public Text comboText;
    public Text accText;
    PlayerHealth player;
    EnemyHealth enemy;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        judgementText.text = " ";
        comboText.text = " ";
        player = FindObjectOfType<PlayerHealth>();
        enemy = FindObjectOfType<EnemyHealth>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void NoteHitPerfect()
    {
        judgementText.text = "Perfect!!";
        judgementText.color = Color.yellow;
        combo++;
        notesHit++;
        totalNotes++;
        accuracy = (notesHit / totalNotes) * 100;
        comboText.text = combo.ToString();
        accText.text = accuracy.ToString("F2") + " %";
        if (enemy.health >= 10)
            enemy.health -= 10;
    }

    public void NoteHitGreat()
    {
        judgementText.text = "Great!!";
        judgementText.color = Color.green;
        combo++;
        notesHit++;
        totalNotes++;
        accuracy = (notesHit / totalNotes) * 100;
        comboText.text = combo.ToString();
        accText.text = accuracy.ToString("F2") + " %";
        if (enemy.health >= 10)
            enemy.health -= 10;
    }

    public void NoteMiss()
    {
        judgementText.text = "Miss!";
        judgementText.color = Color.red;
        combo = 0;
        totalNotes++;
        accuracy = (notesHit / totalNotes) * 100;
        comboText.text = combo.ToString();
        accText.text = accuracy.ToString("F2") + " %";
        if (player.health >= 10)
            player.health -= 10;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
