using System;
using UnityEngine;
using UnityEngine.Audio;

[CreateAssetMenu]
public class AudioManager : ScriptableObject
{
	public AudioMixerGroup SFX;
	public Sound[] Sounds;

	public void Play(string Name)
	{
		var s = Array.Find(Sounds, sound => sound.Name == Name);
		if (s.Source == null)
		{
			var reference = new GameObject(s.Name + " (Instance)");
			var source = reference.AddComponent<AudioSource>();
			reference.AddComponent<DontDestroySelf>();
			source.clip = s.Clip;
			source.volume = s.Volume;
			source.pitch = s.Pitch;
			source.playOnAwake = false;
			source.outputAudioMixerGroup = SFX;
			s.Source = source;
		}

		s.Source.Play();
	}

	public void PlayPing() => Play("Ping");
	public void PlayClick() => Play("Click");
	public void PlaySlowtime() => Play("Slowtime");
	public void PlayAlert() => Play("Alert");
	public void PlaySwitch() => Play("Switch");
	public void PlayRadioSwitch() => Play("RadioSwitch");
	public void PlayFinish() => Play("Finish");
}
