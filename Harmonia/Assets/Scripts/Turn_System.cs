using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class Turn_System : MonoBehaviour
{
    // vars
    private BattleState state;

    public GameObject SongItem1;
    public GameObject SongItem2;
    public GameObject SongItem3;
    public GameObject SongItem4;
    private GameObject SongToPlay;
    public Text InfoText;
    public writingReading reader;

    private int whichSong;

    public AudioSource audio_player;

    public writingReading TextReader;

    // player objects
    // character playerChara
    // character enemyChara

    public static Turn_System instance;
    public GameObject Menu_UI;
    public GameObject PlayerPlayUI;
    public GameObject EnemyPlayUI;

    public Animator player_animator;
    public Animator enemy_animator;

    void Start()
    {
        instance = this;
        state = BattleState.START;
        StartCoroutine(SetupBattle());
    }

    IEnumerator SetupBattle()
    {
        // Setup and spawn characters and load whatever needs to be loaded
        yield return new WaitForSeconds(2f);

        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }

    void PlayerTurn()
    {
        SongItem1.GetComponentInChildren<Text>().text = SongItem1.GetComponent<SongItem>().getName();
        SongItem2.GetComponentInChildren<Text>().text = SongItem2.GetComponent<SongItem>().getName();
        SongItem3.GetComponentInChildren<Text>().text = SongItem3.GetComponent<SongItem>().getName();
        SongItem4.GetComponentInChildren<Text>().text = SongItem4.GetComponent<SongItem>().getName();
        print("Player Turn");
        // enable player to make choices for turn
        Menu_UI.SetActive(true);
    }

    public void playPreview(int song)
    {
        whichSong = song;
        audio_player.Stop();
        if (song == 1)
        {
            InfoText.text = SongItem1.GetComponent<SongItem>().getName() + "\nBPM: " + SongItem1.GetComponent<SongItem>().getBPM() + "\nGenre: "
            + SongItem1.GetComponent<SongItem>().getGenre() + "\nLength: " + Mathf.Round(SongItem1.GetComponent<SongItem>().getAudio().length) + "s\n" + "Info";
            audio_player.clip = SongItem1.GetComponent<SongItem>().getAudio();
            audio_player.Play();
        }
        else if (song == 2)
        {
            InfoText.text = SongItem2.GetComponent<SongItem>().getName() + "\nBPM: " + SongItem2.GetComponent<SongItem>().getBPM() + "\nGenre: "
            + SongItem2.GetComponent<SongItem>().getGenre() + "\nLength: " + Mathf.Round(SongItem2.GetComponent<SongItem>().getAudio().length) + "s\n" + "Info";
            audio_player.clip = SongItem2.GetComponent<SongItem>().getAudio();
            audio_player.Play();
        }
        else if (song == 3)
        {
            InfoText.text = SongItem3.GetComponent<SongItem>().getName() + "\nBPM: " + SongItem3.GetComponent<SongItem>().getBPM() + "\nGenre: "
            + SongItem3.GetComponent<SongItem>().getGenre() + "\nLength: " + Mathf.Round(SongItem3.GetComponent<SongItem>().getAudio().length) + "s\n" + "Info";
            audio_player.clip = SongItem3.GetComponent<SongItem>().getAudio();
            audio_player.Play();
        }
        else if (song == 4)
        {
            InfoText.text = SongItem4.GetComponent<SongItem>().getName() + "\nBPM: " + SongItem4.GetComponent<SongItem>().getBPM() + "\nGenre: "
            + SongItem4.GetComponent<SongItem>().getGenre() + "\nLength: " + Mathf.Round(SongItem4.GetComponent<SongItem>().getAudio().length) + "s\n" + "Info";
            audio_player.clip = SongItem4.GetComponent<SongItem>().getAudio();
            audio_player.Play();
        }
    }

    // when an option is picked
    public void OnChoicePicked()
    {
        if (state != BattleState.PLAYERTURN)
        {
            return;
        }
        audio_player.Stop();
        Menu_UI.SetActive(false);
        if (whichSong == 1)
        {
            SongToPlay = SongItem1;
        }
        else if (whichSong == 2)
        {
            SongToPlay = SongItem2;
        }
        else if (whichSong == 3)
        {
            SongToPlay = SongItem3;
        }
        else if (whichSong == 4)
        {
            SongToPlay = SongItem4;
        }
        StartCoroutine(PlayerPerform(SongToPlay));
    }

    IEnumerator PlayerPerform(GameObject song)
    {
        state = BattleState.ENEMYTURN;
        PlayerPlayUI.SetActive(true);
        // perform song
        TextReader.setUp(song.GetComponent<SongItem>().getText(), song.GetComponent<SongItem>().getText2(), song.GetComponent<SongItem>().getBPM());
        yield return new WaitForSeconds(2.5f);
        audio_player.clip = song.GetComponent<SongItem>().getAudio();
        audio_player.Play();
        yield return new WaitForSeconds(SongItem3.GetComponent<SongItem>().getAudio().length);
        reader.endCoroutine();
        yield return new WaitForSeconds(2f);

        // enemy take damage
        // bool isDead = enemyChara.TakeDamage(damage);
        bool isDead = false;
        enemy_animator.Play("Mozart_Hit");

        // update HUDs
        if (isDead)
        {
            state = BattleState.WON;
            EndBattle();
        }
        else
        {
            PlayerPlayUI.SetActive(false);
            StartCoroutine(EnemyTurn());
        }
    }

    IEnumerator EnemyTurn()
    {
        print("Enemy Turn");
        state = BattleState.PLAYERTURN;
        // enemy performs
        yield return new WaitForSeconds(2f);

        // player take damage
        //  bool isDead = enemyChara.TakeDamage(damage);
        bool isDead = false;
        enemy_animator.Play("Player_Hit");

        if (isDead)
        {
            state = BattleState.LOST;
            EndBattle();
        }
        else
        {
            PlayerTurn();
        }
    }

    void EndBattle()
    {
        if (state == BattleState.WON)
        {
            // win
        }
        else if (state == BattleState.LOST)
        {
            // lose
        }
    }
}