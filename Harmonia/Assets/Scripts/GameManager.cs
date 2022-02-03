using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int combo;
    public int notesHit;
    public int totalNotes;
    public int accuracy;
    public Text judgementText;
    public Text comboText;
    public Text accText;
    PlayerHealth player;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        judgementText.text = " ";
        comboText.text = " ";
        player = FindObjectOfType<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void NoteHit()
    {
        judgementText.text = "Perfect!!";
        judgementText.color = Color.yellow;
        combo++;
        notesHit++;
        totalNotes++;
        accuracy = notesHit / totalNotes;
        comboText.text = combo.ToString();
        accText.text = accuracy.ToString() + " %";
        if (player.health <= 190)
            player.health += 10;
    }

    public void NoteMiss()
    {
        judgementText.text = "Miss!";
        judgementText.color = Color.red;
        combo = 0;
        totalNotes++;
        accuracy = notesHit / totalNotes;
        comboText.text = combo.ToString();
        accText.text = accuracy.ToString() + " %";
        if (player.health >= 10)
            player.health -= 10;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
