using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class Turn_System : MonoBehaviour
{
    // vars
    private BattleState state;

    public GameObject SongItem1;
    public GameObject SongItem2;
    public GameObject SongItem3;
    public GameObject SongItem4;
    private SongItem SongToPlay;
    public Text InfoText;
    public writingReading reader;

    private int whichSong;

    public AudioSource audio_player;

    public writingReading TextReader;

    public static Turn_System instance;
    public GameObject Menu_UI;
    public GameObject PlayerPlayUI;
    public GameObject EnemyPlayUI;

    public Animator player_animator;
    public Animator enemy_animator;

    public CharacterSO PlayerObject;
    public CharacterSO EnemyObject;

    public EnemyHealth enemyhealth;
    public PlayerHealth playerhealth;

    // damage calculation
    private float damagePerNote;
    private float combo;
    private float damageModifier;
    private float amtOfNotes;
    private float currentNotesAmt;
    private float hitNotesAmt;
    private float highestCombo;
    Song EnemyPlaySong;

    //star abilities stuff
    private int starCount = 0;
    private int comboThreshold = 1;
    [SerializeField] private Image star1, star2, star3;
    [SerializeField] private Sprite starReplacement, originStar;
    private float playerStarDamageModifier = 1, enemyStarDamageModifier = 1;

    // stars
    public float threshold;
    private float star_combo;
    private float drift;

    // stats
    public GameManager game_manager;

    // ai autoplay

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
        enemyhealth.setHealth(EnemyObject.getHealth());
        playerhealth.setHealth(PlayerObject.getHealth());

        state = BattleState.PLAYERTURN;
        resetStats();
        game_manager.resetStats();
        PlayerTurn();
    }

    void PlayerTurn()
    {
        SongItem1.GetComponentInChildren<Text>().text = SongItem1.GetComponent<SongItem>().getName();
        SongItem2.GetComponentInChildren<Text>().text = SongItem2.GetComponent<SongItem>().getName();
        SongItem3.GetComponentInChildren<Text>().text = SongItem3.GetComponent<SongItem>().getName();
        SongItem4.GetComponentInChildren<Text>().text = SongItem4.GetComponent<SongItem>().getName();
        //print("Player Turn");
        // enable player to make choices for turn
        Menu_UI.SetActive(true);
    }

    public void playPreview(int song)
    {
        whichSong = song;
        audio_player.Stop();
        if (song == 1)
        {
            InfoText.text = SongItem1.GetComponent<SongItem>().getName() + "\nLength: " + Mathf.Round(SongItem1.GetComponent<SongItem>().getAudio().length) + "s\n" + "Combo Threshold: "
                + Mathf.Round(TextReader.getComboThreshold(SongItem1.GetComponent<SongItem>().getText()) / 12);
            audio_player.clip = SongItem1.GetComponent<SongItem>().getAudio();
            audio_player.Play();
        }
        else if (song == 2)
        {
            InfoText.text = SongItem2.GetComponent<SongItem>().getName() + "\nLength: " + Mathf.Round(SongItem2.GetComponent<SongItem>().getAudio().length) + "s\n" + "Combo Threshold: "
                + Mathf.Round(TextReader.getComboThreshold(SongItem2.GetComponent<SongItem>().getText()) / 12);
            audio_player.clip = SongItem2.GetComponent<SongItem>().getAudio();
            audio_player.Play();
        }
        else if (song == 3)
        {
            InfoText.text = SongItem3.GetComponent<SongItem>().getName() + "\nLength: " + Mathf.Round(SongItem3.GetComponent<SongItem>().getAudio().length) + "s\n" + "Combo Threshold: "
                + Mathf.Round(TextReader.getComboThreshold(SongItem3.GetComponent<SongItem>().getText()) / 12);
            audio_player.clip = SongItem3.GetComponent<SongItem>().getAudio();
            audio_player.Play();
        }
        else if (song == 4)
        {
            InfoText.text = SongItem4.GetComponent<SongItem>().getName() + "\nLength: " + Mathf.Round(SongItem4.GetComponent<SongItem>().getAudio().length) + "s\n" + "Combo Threshold: "
                + Mathf.Round(TextReader.getComboThreshold(SongItem4.GetComponent<SongItem>().getText()) / 12);
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
            SongToPlay = SongItem1.GetComponent<SongItem>();
        }
        else if (whichSong == 2)
        {
            SongToPlay = SongItem2.GetComponent<SongItem>();
        }
        else if (whichSong == 3)
        {
            SongToPlay = SongItem3.GetComponent<SongItem>();
        }
        else if (whichSong == 4)
        {
            SongToPlay = SongItem4.GetComponent<SongItem>();
        }
        StartCoroutine(PlayerPerform(SongToPlay));
    }

    IEnumerator PlayerPerform(SongItem song)
    {
        state = BattleState.ENEMYTURN;
        PlayerPlayUI.SetActive(true);
        // damage calculations
        
        amtOfNotes = song.GetComponent<SongItem>().getAmountOfNotes();
        damagePerNote = song.GetComponent<SongItem>().getDamage() / amtOfNotes;
        //print(damagePerNote);

        // spawn song notes and perform
        audio_player.clip = song.GetComponent<SongItem>().getAudio();
        yield return new WaitForSeconds(3f);
        TextReader.setUp(song.GetComponent<SongItem>().getText(), song.GetComponent<SongItem>().getText2(), song.GetComponent<SongItem>().getBPM(), "player");
        comboThreshold = TextReader.notesLength/12;      //CHANGE THIS 6 to make it easier or harder for combo system (higher = easier)
        //print("COMBO THRESHOLD: " + comboThreshold);
        yield return new WaitForSeconds(song.GetComponent<SongItem>().getBuffer());
        audio_player.Play();
        yield return new WaitForSeconds(song.GetComponent<SongItem>().getAudio().length);
        reader.endCoroutine();
        // final performance bonus
        float final_accuracy = hitNotesAmt / currentNotesAmt;
        finalPerformanceBonus(final_accuracy);
        resetStats();
        game_manager.resetStats();
        yield return new WaitForSeconds(2f);
        

        // enemy take damage
        bool isDead = enemyhealth.isDead();
        //isDead = true;
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
    private void Update() {
        if(star_combo >= comboThreshold * 3){
            starCount = 3;
        }
        else if(star_combo >= comboThreshold*2){
            starCount = 2;
        }
        else if(star_combo >= comboThreshold){
            starCount = 1;
        }

        //I'm splitting it up like this in case we need to access the variable in other scripts
        if(starCount == 0){
            star1.sprite = originStar;
            star1.color = Color.white;
            star2.sprite = originStar;
            star2.color = Color.white;
            star3.sprite = originStar;
            star3.color = Color.white;
        }
        if(starCount == 1){
            star1.sprite = starReplacement;
            star1.color = Color.blue;
            star2.sprite = originStar;
            star2.color = Color.white;
            star3.sprite = originStar;
            star3.color = Color.white;
        }
        if(starCount == 2){
            star1.sprite = starReplacement;
            star1.color = Color.blue;
            star2.sprite = starReplacement;
            star2.color = Color.green;
            star3.sprite = originStar;
            star3.color = Color.white;
            
        }
        if(starCount == 3){
            star1.sprite = starReplacement;
            star1.color = Color.blue;
            star2.sprite = starReplacement;
            star2.color = Color.green;
            star3.sprite = starReplacement;
            star3.color = Color.yellow;
        }

        if(Input.GetKeyDown(KeyCode.V) && starCount > 0){
            starCount--;
            star_combo -= comboThreshold;
            //print("activated star ONE combo ability");
            threshold = 0.2f;
        }
        if(Input.GetKeyDown(KeyCode.B) && starCount > 1){
            starCount-= 2;
            star_combo -= comboThreshold * 2;
            //print("activated star TWO combo ability");
            threshold = 0.1f;
        }
        if(Input.GetKeyDown(KeyCode.N) && starCount > 2){
            starCount = 0;
            star_combo -= comboThreshold * 3;
            //print("activated star THREE combo ability");
            //star modifiers, may need to change how they get reset and stuff
            playerStarDamageModifier = 2;
            enemyStarDamageModifier = 1.5f;
        }
    }

    void finalPerformanceBonus(float accuracy)
    {
        if (0.9 <= accuracy)
        {
            playerhealth.addHealth(highestCombo * damagePerNote);
        }
        else if (0.5 <= accuracy)
        {

        }
        else
        {
            playerhealth.takeDamage(damagePerNote * (hitNotesAmt - currentNotesAmt));
        }
    }

    public float getCurrentBPM()
    {
        if (state == BattleState.ENEMYTURN)
        {
            drift += 0.25f;
            return SongToPlay.GetComponent<SongItem>().getBPM() + drift;
        }
        drift += 0.25f;
        return EnemyPlaySong.getBPM() + drift;
    }

    public float getThreshold()
    {
        return threshold;
    }

    void resetStats()
    {
        combo = 0;
        star_combo = 0;
        starCount = 0;
        damageModifier = 0;
        currentNotesAmt = 0;
        hitNotesAmt = 0;
        highestCombo = 0;
        drift = 0;
        playerStarDamageModifier = 1;
        enemyStarDamageModifier = 1;
        threshold = 0.15f;
}

    public void NoteHitPerfect()
    {
        combo++;
        star_combo++;
        hitNotesAmt++;
        currentNotesAmt++;
        damageModifier = 1f;
        damageEnemy(combo, damageModifier);
    }

    public void NoteHitGreat()
    {
        combo++;
        star_combo++;
        hitNotesAmt++;
        currentNotesAmt++;
        damageModifier = 0.8f;
        damageEnemy(combo, damageModifier);
    }

    public void NoteMiss()
    {
        combo = 0;
        star_combo = 0;
        currentNotesAmt++;
        damageModifier = 0;
        damageEnemy(combo, damageModifier);
    }

    void damageEnemy(float combo, float damageModifier)
    {
        if (combo < 50)
        {
            enemyhealth.takeDamage((damagePerNote * damageModifier * playerStarDamageModifier) + ((damagePerNote / 15) * combo));
        }
        else
        {
            enemyhealth.takeDamage((damagePerNote * damageModifier * playerStarDamageModifier) + ((damagePerNote / 15) * 50));
        }

        if (combo > highestCombo)
        {
            highestCombo = combo;
        }
        if (combo % 20 == 0 && damageModifier != 0)
        {
            enemy_animator.Play("Mozart_Hit");
        }
        //print(enemyhealth.getHealth());
    }

    IEnumerator EnemyTurn()
    {
        state = BattleState.PLAYERTURN;
        // enemy performs
        EnemyPlayUI.SetActive(true);

        int song_num = Random.Range(1, 4);
        if (song_num == 1)
        {
            EnemyPlaySong = EnemyObject.getSong1();
        }
        else if (song_num == 2)
        {
            EnemyPlaySong = EnemyObject.getSong2();
        }
        else if (song_num == 3)
        {
            EnemyPlaySong = EnemyObject.getSong3();
        }
        else if (song_num == 4)
        {
            EnemyPlaySong = EnemyObject.getSong4();
        }

        yield return new WaitForSeconds(3f);
        TextReader.setUp(EnemyPlaySong.getText(), EnemyPlaySong.getText2(), EnemyPlaySong.getBPM(), "enemy");
        audio_player.clip = EnemyPlaySong.getAudio();
        yield return new WaitForSeconds(EnemyPlaySong.getBuffer());
        audio_player.Play();
        yield return new WaitForSeconds(EnemyPlaySong.getAudio().length);
        audio_player.Stop();
        reader.endCoroutine();
        damagePlayer(EnemyPlaySong);

        yield return new WaitForSeconds(2f);
        // player take damage
        //  bool isDead = enemyChara.TakeDamage(damage);
        bool isDead = playerhealth.isDead();
        resetStats();
        game_manager.resetStats();
        
        //enemy_animator.Play("Player_Hit");

        if (isDead)
        {
            state = BattleState.LOST;
            EndBattle();
        }
        else
        {
            PlayerTurn();
            EnemyPlayUI.SetActive(false);
        }
    }
    void damagePlayer(Song song)
    {
        playerhealth.takeDamage(song.getDamage() * enemyStarDamageModifier);
    }
    void EndBattle()
    {
        if (state == BattleState.WON)
        {
            persistantManager.Instance.setDialogue("win");
            SceneManager.LoadScene("TalkingSceneWin");
        }
        else if (state == BattleState.LOST)
        {
            persistantManager.Instance.setDialogue("lose");
            SceneManager.LoadScene("TalkingSceneLose");
        }
    }
}