using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SFXManager : MonoBehaviour
{
	public AudioManager AudioManager;
	public AudioMixer AudioMixer;
	bool IsMuted = false;
	bool ToChange = false;

	public void ToggleMute()
	{
		IsMuted = !IsMuted;
		ToChange = true;
	}

	public void MuteSFX(bool muted)
    {
        if (muted)
		{
			AudioMixer.SetFloat("SFXVolume", -80);
		}
		else
		{
			AudioMixer.SetFloat("SFXVolume", 0);
		}
	}
    
    void Update()
    {
		if (Input.GetKeyDown(KeyCode.M))
			ToggleMute();

		if (IsMuted && ToChange)
		{
			MuteSFX(true);
			ToChange = false;
		}
		else if (!IsMuted && ToChange)
		{
			MuteSFX(false);
			ToChange = false;
		}
	}
}
