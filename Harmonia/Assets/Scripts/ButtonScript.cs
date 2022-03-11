using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    public GameObject panelToOpen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartGame(){
        //print(persistantManager.Instance.currScene);
        persistantManager.Instance.setDialogue("intro");

        if(persistantManager.Instance.currScene != "Menu" && persistantManager.Instance.currScene != "" && persistantManager.Instance.currScene != "Intro"){
            SceneManager.LoadScene(persistantManager.Instance.currScene);
        }
        else{
            //SceneManager.LoadScene("RPG_scene");
            SceneManager.LoadScene("Intro");
        }

        //  once we switch to the setting scene (this is how we load based on save)
        /*
        int loadLevel = PlayerPrefs.GetInt("level");
        if(loadLevel == 1){
            SceneManager.LoadScene("RPG_scene");
        }
        if(loadLevel == 2){
            SceneManager.LoadScene("TalkingScene1");
        }
        if(loadLevel == 3){
            SceneManager.LoadScene("CombatScene");
        }
        */
    }
    public void OpenTutorial(){
        panelToOpen.gameObject.SetActive(true);
    }
    public void CloseTutorial(){
        panelToOpen.gameObject.SetActive(false);
    }
    public void OpenSettings(){
        PlayerPrefs.SetInt("Settings", 1);
        SceneManager.LoadScene("Settings");
        persistantManager.Instance.menuOpened = true;
    }
    public void SaveGame(){
        PlayerPrefs.SetInt("level", persistantManager.Instance.currentLevel);
        print(persistantManager.Instance.currScene);
        PlayerPrefs.SetString("current scene", persistantManager.Instance.currScene);
    }
    public void NewGame(){
        int beat = PlayerPrefs.GetInt("Game Beaten");
        PlayerPrefs.DeleteAll();
        if (beat == 1)
        {
            PlayerPrefs.SetInt("Game Beaten", 1);
        }
        persistantManager.Instance.currScene = "Menu";
    }
    public void CloseSettings(){
        PlayerPrefs.SetInt("Settings", 0);
        //SceneManager.LoadScene(persistantManager.Instance.currScene);
        if(persistantManager.Instance.menuOpened){
            persistantManager.Instance.menuOpened = false;
            SceneManager.LoadScene("Menu");
        }
        else{
            SceneManager.LoadScene(persistantManager.Instance.currScene);
        }
    }
    public void ExitGame(){
        if(Application.platform == RuntimePlatform.WebGLPlayer){
            Screen.fullScreen = false;
        }
        else{
            Application.Quit();
        } 
    }
}
