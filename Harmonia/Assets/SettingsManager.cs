using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    public GameObject settingsUI;
    private bool settingsOpen = false;

    public AudioSource Volume;
    public AudioSource SFX;
    public AudioSource FigaroBGM;

    public Slider volumeSlider;
    public Slider effectsSlider;
    public Slider textSlider;

    private void Start()
    {
        FigaroBGM.Play();
        LoadValues();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            settingsOpen = !settingsOpen;
            settingsUI.SetActive(settingsOpen);
        }
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
        textSlider.value = textValue;
    }

    public float getTextSpeed()
    {
        if (textSlider.value != 0)
        {
            return textSlider.value;
        }
        return 0.01f;
    }

    public bool settingsActive()
    {
        return settingsOpen;
    }

    public void pauseFigaroBGM(){
        if(FigaroBGM != null){
            FigaroBGM.Pause();
        }
    }

    public void playFigaroBGM(){
        if(FigaroBGM != null){
            FigaroBGM.UnPause();
        }
    }

}
