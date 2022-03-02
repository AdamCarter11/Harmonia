using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SettingsManager : MonoBehaviour
{
    //public static SettingsManager Instance;       //if we want to make the settings save across scenes


    public GameObject settingsUI;
    private bool settingsOpen = true;

    public AudioSource Volume;
    public AudioSource SFX;

    public Slider volumeSlider;
    public Slider effectsSlider;
    public Slider textSlider;

    //  if we want to make the settings save across scenes
    /*
    private void Awake() {
       if(Instance != null){
           Destroy(gameObject);
           return;
       } 
       Instance = this;
       DontDestroyOnLoad(gameObject);
    }
    */

    private void Start()
    {
        Screen.fullScreen = true;   //this may automatically set full screen?
        /*
        // if the code above doesn't work, try this code:
        var resolution = Screen.resolutions[Screen.resolutions.Length-1];
        Screen.SetResolution(resolution.width, resolution.height, true);
        */
        

        LoadValues();
    }

    // Update is called once per frame
    void Update()
    {
       
        
    }

    public void SettingsMenu(){
        settingsOpen = !settingsOpen;
        settingsUI.SetActive(settingsOpen); 
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void disableSettings()
    {
        settingsOpen = !settingsOpen;
        settingsUI.SetActive(settingsOpen);
    }

    public void VolumeSlider(float volume)
    {
        float volumeValue = volume;
        PlayerPrefs.SetFloat("VolumeValue", volumeValue);
        LoadValues();
    }
  
    public void EffectsSlider(float volume)
    {
        float effectsValue = volume;
        PlayerPrefs.SetFloat("EffectsValue", effectsValue);
        LoadValues();
    }

    public void TextSlider(float volume)
    {
        float textValue = volume;
        PlayerPrefs.SetFloat("TextValue", textValue);
        LoadValues();
    }

    public void LoadValues()
    {
        float volumeValue = PlayerPrefs.GetFloat("VolumeValue");
        volumeSlider.value = volumeValue;
        Volume.volume = volumeValue * .25f;

        float effectsValue = PlayerPrefs.GetFloat("EffectsValue");
        effectsSlider.value = effectsValue;
        SFX.volume = effectsValue * .25f;

        float textValue = PlayerPrefs.GetFloat("TextValue");
        print(textValue);
        textSlider.value = textValue;
    }

    public float getTextSpeed()
    {
        if (textSlider.value != 0)
        {
            return textSlider.value * 2f;
        }
        return 0.01f * 2f;
    }

    public bool settingsActive()
    {
        return settingsOpen;
    }
}
