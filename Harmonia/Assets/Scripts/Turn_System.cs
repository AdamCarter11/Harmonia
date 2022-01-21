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
        print("Player Turn");
        // enable player to make choices for turn
        Menu_UI.SetActive(true);
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