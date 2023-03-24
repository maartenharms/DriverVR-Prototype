using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer myMixer;
    [SerializeField] private Slider voiceSlider;
    [SerializeField] private Slider SFXSlider;


    public void Start()
    {
        if (PlayerPrefs.HasKey("voiceVolume"))
        {
            LoadVolume();
        }
        else
        {
            SetVoiceVolume();
            SetSFXVolume();
        }
    }
    public void SetVoiceVolume()
    {
        float volume = voiceSlider.value;
        myMixer.SetFloat("VoiceOver", Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("voiceVolume", volume);
    }

    public void SetSFXVolume()
    {
        float volume = SFXSlider.value;
        myMixer.SetFloat("SFX", Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("SFXVolume", volume);
    }

    private void LoadVolume()
    {
        voiceSlider.value = PlayerPrefs.GetFloat("voiceVolume");
        SFXSlider.value = PlayerPrefs.GetFloat("SFXVolume");


        SetVoiceVolume();
        SetSFXVolume();
    }
}
