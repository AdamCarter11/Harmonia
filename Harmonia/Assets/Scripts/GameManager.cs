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
    public Animator judgeTextAnim;
    PlayerHealth player;
    EnemyHealth enemy;

    // Start is called before the first frame update
    void Start()
    {
        judgeTextAnim = judgementText.GetComponent<Animator>();
        instance = this;
        judgementText.text = " ";
        comboText.text = " ";
        player = FindObjectOfType<PlayerHealth>();
        enemy = FindObjectOfType<EnemyHealth>();
    }

    public void NoteHitPerfect()
    {
        judgeTextAnim.Play("JudgementText", -1, 0);
        judgementText.text = "Perfect!!";
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

    public void NoteHitGreat()
    {
        judgeTextAnim.Play("JudgementText", -1, 0);
        judgementText.text = "Great!";
        judgementText.color = Color.yellow;
        combo++;
        notesHit++;
        totalNotes++;
        accuracy = (notesHit / totalNotes) * 100;
        comboText.text = combo.ToString();
        accText.text = accuracy.ToString("F2") + " %";
        if (enemy.health >= 1)
            enemy.health -= 1;
    }

    public void NoteMiss()
    {
        judgeTextAnim.Play("JudgementText", -1, 0);
        judgementText.text = "Miss";
        judgementText.color = Color.red;
        combo = 0;
        totalNotes++;
        accuracy = (notesHit / totalNotes) * 100;
        comboText.text = combo.ToString();
        accText.text = accuracy.ToString("F2") + " %";
        if (player.health >= 1)
            player.health -= 1;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
