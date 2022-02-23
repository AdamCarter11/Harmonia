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
    [HideInInspector] public string whichDialogue;
    [HideInInspector] public List<CharacterSO> characters;


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
        if (currScene == "TalkingSceneWin")
        {
            currentLevel = 4;
        }
        if (currScene == "TalkingSceneLose")
        {
            currentLevel = 5;
        }
        if (currScene == "RPG_Scene2")
        {
            currentLevel = 6;
        }
    }

    public void setDialogue(string text)
    {
        whichDialogue = text;
    }

    public string getDialogue()
    {
        return whichDialogue;
    }

    public void setCharacters(List<CharacterSO> chars)
    {
        characters = chars;
    }

    public List<CharacterSO> getCharacters()
    {
        return characters;
    }

    public void AddChara(CharacterSO character)
    {
        if (characters.Count < 12)
        {
            characters.Add(character);
        }
    }

    public void RemoveChara(CharacterSO character)
    {
        if (characters.Count > 0)
        {
            characters.Remove(character);
        }
    }
}
