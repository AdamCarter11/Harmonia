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
    }
    public void OpenTutorial(){
        panelToOpen.gameObject.SetActive(true);
    }
    public void CloseTutorial(){
        panelToOpen.gameObject.SetActive(false);
    }
}
