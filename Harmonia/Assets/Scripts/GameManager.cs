using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int combo;
    public Text judgementText;
    public Text comboText;
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
        combo += 1;
        comboText.text = combo.ToString();
        if (player.health <= 190)
            player.health += 10;
    }

    public void NoteMiss(GameObject note)
    {
        judgementText.text = "Miss!";
        judgementText.color = Color.red;
        combo = 0;
        comboText.text = combo.ToString();
        if (player.health >= 10)
            player.health -= 10;
        Destroy(note);
    }
}
