using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class textBaseClass : TalkingScene
{
    [SerializeField]
    private Text nameText, talkingText;
    [SerializeField]
    private GameObject panel;
    public NPCScriptableObject[] scriptableObjs;
    [SerializeField]
    private float timeDelay;
    string checkScene;
    private int whichText = 0;
    private bool isThereStillText = true;

    public SettingsManager settings;
    private int npcIndex=0;

    public ButtonScript button_script;

    private void Awake() {
        nameText.text = scriptableObjs[0].NPCName;
        talkingText.text = "";
    }
    private void Start() {
        settings.LoadValues();
        checkScene = SceneManager.GetActiveScene().name;
        if (checkScene == "TalkingScene1")
        {
            StartCoroutine(WriteText(scriptableObjs[npcIndex].dialogue[0], talkingText, timeDelay / settings.getTextSpeed()));
        }
        else if (checkScene == "TalkingSceneWin")
        {
            StartCoroutine(WriteText(scriptableObjs[npcIndex].player_win_dialogue[0], talkingText, timeDelay / settings.getTextSpeed()));
        }
        else if (checkScene == "TalkingSceneLose")
        {
            StartCoroutine(WriteText(scriptableObjs[npcIndex].player_lose_dialogue[0], talkingText, timeDelay / settings.getTextSpeed()));
        }
        else if (persistantManager.Instance.getDialogue() == "intro")
        {
            StartCoroutine(WriteText(scriptableObjs[npcIndex].intro_dialogue[0], talkingText, timeDelay / settings.getTextSpeed()));
        }
        npcIndex = 1;
    }
    private void Update() {
        //if (!settings.settingsActive())
        //{
            updateText();
        //}
    }

    void updateText()
    {
        if (Input.GetKeyDown(KeyCode.E) && isThereStillText)
        {
            StopAllCoroutines();
            talkingText.text = "";
            if (checkScene == "TalkingScene1")
            {
                if (whichText >= scriptableObjs[npcIndex].dialogue.Length)
                {
                    panel.SetActive(false);
                    isThereStillText = false;
                }
                else
                {
                    StartCoroutine(WriteText(scriptableObjs[npcIndex].dialogue[whichText], talkingText, timeDelay / settings.getTextSpeed()));
                }
            }
            else if (checkScene == "TalkingSceneWin")
            {
                if (whichText >= scriptableObjs[npcIndex].player_win_dialogue.Length)
                {
                    panel.SetActive(false);
                    isThereStillText = false;
                }
                else
                {
                    StartCoroutine(WriteText(scriptableObjs[npcIndex].player_win_dialogue[whichText], talkingText, timeDelay / settings.getTextSpeed()));
                }
            }
            else if (checkScene == "TalkingSceneLose")
            {
                if (whichText >= scriptableObjs[npcIndex].player_lose_dialogue.Length)
                {
                    panel.SetActive(false);
                    isThereStillText = false;
                }
                else
                {
                    StartCoroutine(WriteText(scriptableObjs[npcIndex].player_lose_dialogue[whichText], talkingText, timeDelay / settings.getTextSpeed()));
                }
            }
            else if (persistantManager.Instance.getDialogue() == "intro")
            {
                if (whichText >= scriptableObjs[npcIndex].intro_dialogue.Length)
                {
                    panel.SetActive(false);
                    isThereStillText = false;
                }
                else
                {
                    StartCoroutine(WriteText(scriptableObjs[npcIndex].intro_dialogue[whichText], talkingText, timeDelay / settings.getTextSpeed()));
                }
            }
            if(npcIndex == 0){
                npcIndex = 1;
                nameText.text = scriptableObjs[0].NPCName;
            }
            else{
                npcIndex = 0;
                nameText.text = scriptableObjs[1].NPCName;
                whichText++;
            }
            //whichText++;

        }
        if (!isThereStillText)
        {
            if (checkScene == "TalkingScene1")
            {
                SceneManager.LoadScene("CombatScene");
            }
            else if (checkScene == "TalkingSceneLose")
            {
                button_script.NewGame();
                SceneManager.LoadScene(persistantManager.Instance.currScene);
            }
            else if (checkScene == "TalkingSceneWin")
            {
                persistantManager.Instance.AddChara(scriptableObjs[0].getCharaSO());
                PlayerPrefs.SetFloat("playerX", 0);
                PlayerPrefs.SetFloat("playerY", 0);
                SceneManager.LoadScene("RPG_Scene2");
            }
            else if (persistantManager.Instance.getDialogue() == "intro")
            {
                persistantManager.Instance.AddChara(scriptableObjs[1].getCharaSO());
                PlayerPrefs.SetFloat("playerX", 0);
                PlayerPrefs.SetFloat("playerY", 0);
                SceneManager.LoadScene("RPG_Scene");
            }
        }
    }
}
