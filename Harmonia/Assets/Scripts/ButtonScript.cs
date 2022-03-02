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
        print(persistantManager.Instance.currScene);
        if(persistantManager.Instance.currScene != "Menu" && persistantManager.Instance.currScene != ""){
            SceneManager.LoadScene(persistantManager.Instance.currScene);
        }
        else{
            SceneManager.LoadScene("RPG_scene");
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
        SceneManager.LoadScene("Settings");
    }
    public void SaveGame(){
        PlayerPrefs.SetInt("level", persistantManager.Instance.currentLevel);
        print(persistantManager.Instance.currScene);
        PlayerPrefs.SetString("current scene", persistantManager.Instance.currScene);
    }
    public void NewGame(){
        PlayerPrefs.DeleteAll();
        persistantManager.Instance.currScene = "Menu";
    }
    public void CloseSettings(){
        SceneManager.LoadScene(persistantManager.Instance.currScene);
    }
    public void ExitGame(){
        Application.Quit();
    }
}
