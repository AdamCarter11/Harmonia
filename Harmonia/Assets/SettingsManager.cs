using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SettingsManager : MonoBehaviour
{


    public GameObject settingsUI;
    private bool settingsOpen = true;

    public AudioSource Volume;
    public AudioSource SFX;
    public GameObject audio_players;
    private AudioSource[] music_players;
    public GameObject sfx_player;
    private AudioSource[] sfx_players;

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
        
        if(PlayerPrefs.GetFloat("TextValue") == 0){
            LoadNewDefaults();
        }
        else{
            LoadValues();
        }

        music_players = GetComponentsInChildren<AudioSource>();
        sfx_players = GetComponentsInChildren<AudioSource>();
        updateAudioLevels();

        if (PlayerPrefs.GetInt("Settings") == 1)
        {
            Volume.Play();
            play_sfx();
        }
    }

    void play_sfx()
    {
        StartCoroutine(sfx_loop());
    }

    IEnumerator sfx_loop()
    {
        yield return new WaitForSeconds(3f);
        SFX.Play();
        StartCoroutine(sfx_loop());
    }

    void updateAudioLevels()
    {
        for (int i = 0; i < music_players.Length; i++)
        {
            music_players[i].volume = PlayerPrefs.GetFloat("VolumeValue");
        }
        for (int i = 0; i < sfx_players.Length; i++)
        {
            sfx_players[i].volume = PlayerPrefs.GetFloat("EffectsValue");
        }
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
        PlayerPrefs.SetFloat("VolumeValue", volumeValue * .25f);
        LoadValues();
    }
  
    public void EffectsSlider(float volume)
    {
        float effectsValue = volume;
        PlayerPrefs.SetFloat("EffectsValue", effectsValue * .15f);
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
        volumeSlider.value = volumeValue / .25f;
        Volume.volume = volumeValue;

        float effectsValue = PlayerPrefs.GetFloat("EffectsValue");
        effectsSlider.value = effectsValue / .15f;
        SFX.volume = effectsValue;

        float textValue = PlayerPrefs.GetFloat("TextValue");
        textSlider.value = textValue;
    }
    public void LoadNewDefaults(){
        float volumeValue = .25f;
        volumeSlider.value = volumeValue;
        Volume.volume = volumeValue * .25f;

        float effectsValue = .25f;
        effectsSlider.value = effectsValue;
        SFX.volume = effectsValue * .25f;

        float textValue = .25f;
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
