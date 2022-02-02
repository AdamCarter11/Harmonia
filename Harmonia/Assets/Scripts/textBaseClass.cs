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

    private int whichText = 1;
    private bool isThereStillText = true;

    private void Awake() {
        nameText.text = scriptableObjs[0].NPCName;
        talkingText.text = "";
    }
    private void Start() {
        StartCoroutine(WriteText(scriptableObjs[0].dialogue[0], talkingText, timeDelay));
    }
    private void Update() {
        if(Input.GetKeyDown(KeyCode.E) && isThereStillText){
            StopAllCoroutines();
            talkingText.text = "";
            if(whichText >= scriptableObjs[0].dialogue.Length){
                panel.SetActive(false);
                isThereStillText = false;
            }
            else{
                StartCoroutine(WriteText(scriptableObjs[0].dialogue[whichText], talkingText, timeDelay));   
            }
            whichText++;
            
        }
        if (!isThereStillText)
        {
            SceneManager.LoadScene("Jalen's Scene");
        }
    }
}
