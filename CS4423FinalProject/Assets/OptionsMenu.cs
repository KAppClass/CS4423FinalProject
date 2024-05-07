using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour
{
    [Header("Menu")]
    [SerializeField] Canvas canvas;
    
    [Header("Hard Mode")]
    [SerializeField] Toggle toggle;
    [SerializeField] EnemySO enemySO;

    [Header("Audio")]
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] Slider masterVolume;
    [SerializeField] Slider musicVolume;
    [SerializeField] Slider sfxVolume;
    
    void Start()
    {
        masterVolume.value = PlayerPrefs.GetFloat("MasterVolumeSlider");
        musicVolume.value = PlayerPrefs.GetFloat("MusicVolumeSlider");
        sfxVolume.value = PlayerPrefs.GetFloat("SFXVolumeSlider");
    }


    public void OpenOptions()
    {
        canvas.enabled = true;
    }

    public void CloseOptions()
    {
        canvas.enabled = false;
    }

    public void HardMode()
    {
        if (toggle.isOn)
            enemySO.hard = true;
        else
            enemySO.hard = false;
    }

    public void SetMasterVolume()
    {
        audioMixer.SetFloat("MasterVolume",ConvertToDec(masterVolume.value));
        PlayerPrefs.SetFloat("MasterVolumeSlider", masterVolume.value);
    }

    public void SetMusicVolume()
    {
        audioMixer.SetFloat("MusicVolume",ConvertToDec(musicVolume.value));
        PlayerPrefs.SetFloat("MusicVolumeSlider", musicVolume.value);
    }

    public void SetSFXVolume()
    {
        audioMixer.SetFloat("SFXVolume",ConvertToDec(sfxVolume.value));
        PlayerPrefs.SetFloat("SFXVolumeSlider", sfxVolume.value);
    }

    float ConvertToDec(float sliderValue)
    {
        return Mathf.Log10(Mathf.Max(sliderValue, 0.0001f)) * 20;
    }
}
