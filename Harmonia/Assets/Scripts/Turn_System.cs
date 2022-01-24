using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class Turn_System : MonoBehaviour
{
    // vars
    private BattleState state;
    private GameObject player;
    private GameObject enemy;

    public Transform playerSpawn;
    public Transform enemySpawn;

    public GameObject SongItem1;
    public Text InfoText;

    public AudioSource audio_player;

    // player objects
    // character playerChara
    // character enemyChara

    public static Turn_System instance;
    public GameObject Menu_UI;
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
        SongItem1.GetComponentInChildren<Text>().text =  SongItem1.GetComponent<SongItem>().getName();
        print("Player Turn");
        // enable player to make choices for turn
        Menu_UI.SetActive(true);
    }

    public void playPreview(int song)
    {
        audio_player.Stop();
        if (song == 1)
        {
            InfoText.text = "Name: " + SongItem1.GetComponent<SongItem>().getName() + "\nBPM:" + SongItem1.GetComponent<SongItem>().getBPM() + "\nGenre: "
            + SongItem1.GetComponent<SongItem>().getGenre() + "\nLength: " + SongItem1.GetComponent<SongItem>().getAudio().length + "s\n" + "info";
            audio_player.clip = SongItem1.GetComponent<SongItem>().getAudio();
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
        Menu_UI.SetActive(false);
        StartCoroutine(PlayerPerform());
    }

    IEnumerator PlayerPerform()
    {
        state = BattleState.ENEMYTURN;
        // perform song
        yield return new WaitForSeconds(2f);

        // enemy take damage
        // bool isDead = enemyChara.TakeDamage(damage);
        bool isDead = false;
        // update HUDs
        if (isDead)
        {
            state = BattleState.WON;
            EndBattle();
        }
        else
        {
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