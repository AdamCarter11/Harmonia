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
        SceneManager.LoadScene("RPG_scene");

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
            SceneManager.LoadScene("Jalen's Scene");
        }
        */
    }
    public void OpenTutorial(){
        panelToOpen.gameObject.SetActive(true);
    }
    public void CloseTutorial(){
        panelToOpen.gameObject.SetActive(false);
    }

    public void SaveGame(){
        PlayerPrefs.SetInt("level", persistantManager.Instance.currentLevel);
    }
    public void NewGame(){
        PlayerPrefs.DeleteAll();
    }
}
