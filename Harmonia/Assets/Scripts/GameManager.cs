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
    string[] badComments;
    string[] goodComments;
    GameObject panel;
    GameObject mozartText;

    // Start is called before the first frame update
    void Start()
    {
        judgeTextAnim = judgementText.GetComponent<Animator>();
        instance = this;
        judgementText.text = " ";
        comboText.text = " ";
        player = FindObjectOfType<PlayerHealth>();
        enemy = FindObjectOfType<EnemyHealth>();
        badComments = new string[]{ "*Scoffs* This music sickens me!", "My child has written better melodies than this!", "Horrible... HORRIBLE!", "You call this music? This is atrocious!",
            "You really thought you could challenge me? Pathetic.", "I'd rather listen to the clanging of pots and pans.", "Thou are not even holding the instrument properly!" };
        goodComments = new string[]{"My oh my! Perhaps you aren't so talentless after all...", "Stunning! Simply stunning!", "My ears... my ears have been blessed!",
            "My talent must be rubbing off on you...", "Quite impressive! Now let's see if you can keep this going.", "This would be a horrible time for a... DISTRACTION... wouldn't it?" };
        panel = GameObject.Find("TextPanel");
        mozartText = GameObject.Find("MozartText");
    }

    void Update()
    {
        if ((combo == 30 || combo == 50) && panel.activeInHierarchy == false)
        {
            randomComment(3, goodComments);
        }
        if ((combo == 10 || combo == 20) && panel.activeInHierarchy == false)
        {
            randomComment(3, badComments);
        }
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
        if (enemy.health >= 10)
            enemy.health -= 10;
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
        if (player.health >= 10)
            player.health -= 10;
    }

    public void randomComment(float duration, string[] comments)
    {
        panel.SetActive(true);
        mozartText = GameObject.Find("MozartText");
        Text mtext = mozartText.GetComponent<Text>();
        mtext.text = comments[Random.Range(0, comments.Length)];
        StartCoroutine(setTextBack(duration));
    }

    IEnumerator setTextBack(float duration)
    {
        yield return new WaitForSeconds(duration);
        panel.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
