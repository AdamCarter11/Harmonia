using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class persistantManager : MonoBehaviour
{
    public static persistantManager Instance;
    [HideInInspector] public int currentLevel;
    [HideInInspector] public float volumeVal, effectsVal, textVal;
    [HideInInspector] public string currScene;


    private void Awake() {
       if(Instance != null){
           Destroy(gameObject);
           return;
       } 
       Instance = this;
       DontDestroyOnLoad(gameObject);
    }

    private void Start() {
        currScene = PlayerPrefs.GetString("current scene");
        print(currScene);
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            /*
            settingsOpen = !settingsOpen;
            settingsUI.SetActive(settingsOpen);
            */
            SceneManager.LoadScene("Settings");
        }
        string checkScene = SceneManager.GetActiveScene().name;
        if(checkScene != "Settings" && checkScene != "Menu"){
            currScene = SceneManager.GetActiveScene().name;
        }
 
        //we could also switch to using index, we would just have to be careful with what order we build the levels in
        if(currScene == "RPG_scene"){
            currentLevel = 1;
        }
        if(currScene == "TalkingScene1"){
            currentLevel = 2;
        }
        if(currScene == "Jalen's Scene"){
            currentLevel = 3;
        }
    }
}
