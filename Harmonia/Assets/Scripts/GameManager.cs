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
    public float weighted_score;
    public float total_possible_score;
    public Text judgementText;
    public Text comboText;
    public Text accText;
    public Animator judgeTextAnim;

    string[] badComments;
    string[] goodComments;
    GameObject panel;
    GameObject mozartText;

    public Turn_System turn_system;

    public AudioSource perfectNote;

    public AIButtonPress Target1;
    public AIButtonPress Target2;
    public AIButtonPress Target3;
    public AIButtonPress Target4;
    public AIButtonPress Target5;

    // Start is called before the first frame update
    void Start()
    {
        judgeTextAnim = judgementText.GetComponent<Animator>();
        instance = this;
        judgementText.text = " ";
        comboText.text = " ";
        badComments = new string[]{ "Scoffs This music sickens me!", "My child has written better melodies than this!", "Horrible... HORRIBLE!", "You call this music? This is atrocious!",
            "You really thought you could challenge me? Pathetic.", "I'd rather listen to the clanging of pots and pans.", "Thou are not even holding the instrument properly!" };
        goodComments = new string[]{"My oh my! Perhaps you aren't so talentless after all...", "Stunning! Simply stunning!", "My ears... my ears have been blessed!",
            "My talent must be rubbing off on you...", "Quite impressive! Now let's see if you can keep this going.", "This would be a horrible time for a... DISTRACTION... wouldn't it?" };
        panel = GameObject.Find("TextPanel");
        mozartText = GameObject.Find("MozartText");
    }

    private void Update()
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

    public void resetStats()
    {
        combo = 0;
        notesHit = 0;
        totalNotes = 0;
        accuracy = 0;
        weighted_score = 0;
        total_possible_score = 0;
        judgementText.text = " ";
        comboText.text = " ";
        accText.text = accuracy.ToString("F2") + " %";
    }

    public void NoteHitPerfect()
    {
        judgeTextAnim.Play("JudgementText", -1, 0);
        judgementText.text = "Perfect!!";
        judgementText.color = Color.green;
        combo++;
        notesHit++;
        totalNotes++;
        weighted_score += 1;
        total_possible_score += 1;
        accuracy = (weighted_score / total_possible_score) * 100;
        comboText.text = combo.ToString();
        accText.text = accuracy.ToString("F2") + " %";
        turn_system.NoteHitPerfect();
        //plays sfx
        if(perfectNote != null){
            perfectNote.Play();
        }
    }

    public void NoteHitGreat()
    {
        judgeTextAnim.Play("JudgementText", -1, 0);
        judgementText.text = "Great!";
        judgementText.color = Color.yellow;
        combo++;
        notesHit++;
        totalNotes++;
        weighted_score += 0.8f;
        total_possible_score += 1;
        accuracy = (weighted_score / total_possible_score) * 100;
        comboText.text = combo.ToString();
        accText.text = accuracy.ToString("F2") + " %";
        turn_system.NoteHitGreat();
    }

    public void NoteMiss()
    {
        judgeTextAnim.Play("JudgementText", -1, 0);
        judgementText.text = "Miss";
        judgementText.color = Color.red;
        combo = 0;
        totalNotes++;
        total_possible_score += 1;
        accuracy = (weighted_score / total_possible_score) * 100;
        comboText.text = combo.ToString();
        accText.text = accuracy.ToString("F2") + " %";
        turn_system.NoteMiss();
    }

    public void NoteHitAI()
    {
        turn_system.NoteHitAI();
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
