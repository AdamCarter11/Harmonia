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

    int npcIndex = 0;

    public SettingsManager settings;

    private void Awake() {
        nameText.text = scriptableObjs[npcIndex].NPCName;
        talkingText.text = "";
    }
    private void Start() {
        settings.LoadValues();
        StartCoroutine(WriteText(scriptableObjs[0].dialogue[0], talkingText, timeDelay / settings.getTextSpeed()));
        npcIndex = 1;
    }
    private void Update() {
        if (!settings.settingsActive())
        {
            updateText();
        }
    }

    void updateText()
    {
        if (Input.GetKeyDown(KeyCode.E) && isThereStillText)
        {
            StopAllCoroutines();
            talkingText.text = "";
            if (whichText >= scriptableObjs[npcIndex].dialogue.Length)
            {
                panel.SetActive(false);
                isThereStillText = false;
            }
            else
            {
                StartCoroutine(WriteText(scriptableObjs[npcIndex].dialogue[whichText], talkingText, timeDelay / settings.getTextSpeed()));
            }
            if (npcIndex == 0)
            {
                npcIndex = 1;
                nameText.text = scriptableObjs[0].NPCName;
            }
            else
            {
                npcIndex = 0;
                nameText.text = scriptableObjs[1].NPCName;
                whichText++;
            }
        }
        if (!isThereStillText)
        {
            SceneManager.LoadScene("Jalen's Scene");
        }
    }
}
