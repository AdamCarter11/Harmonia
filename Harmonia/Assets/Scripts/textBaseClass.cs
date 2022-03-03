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
        if (persistantManager.Instance.getDialogue() == "first encounter")
        {
            StartCoroutine(WriteText(scriptableObjs[npcIndex].dialogue[0], talkingText, timeDelay / settings.getTextSpeed()));
        }
        else if (persistantManager.Instance.getDialogue() == "win")
        {
            StartCoroutine(WriteText(scriptableObjs[npcIndex].player_win_dialogue[0], talkingText, timeDelay / settings.getTextSpeed()));
        }
        else if (persistantManager.Instance.getDialogue() == "lose")
        {
            StartCoroutine(WriteText(scriptableObjs[npcIndex].player_lose_dialogue[0], talkingText, timeDelay / settings.getTextSpeed()));
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
            if (persistantManager.Instance.getDialogue() == "first encounter")
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
            else if (persistantManager.Instance.getDialogue() == "win")
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
            else if (persistantManager.Instance.getDialogue() == "lose")
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
            if (persistantManager.Instance.getDialogue() == "first encounter")
            {
                SceneManager.LoadScene("CombatScene");
            }
            else if (persistantManager.Instance.getDialogue() == "lose")
            {
                button_script.NewGame();
                SceneManager.LoadScene(persistantManager.Instance.currScene);
            }
            else if (persistantManager.Instance.getDialogue() == "win")
            {
                persistantManager.Instance.AddChara(scriptableObjs[0].getCharaSO());
                PlayerPrefs.SetFloat("playerX", 0);
                PlayerPrefs.SetFloat("playerY", 0);
                SceneManager.LoadScene("RPG_Scene2");
            }
        }
    }
}
