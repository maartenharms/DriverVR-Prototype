using System;
using UnityEngine;

[Serializable]
public class Sound
{
	public string Name;
	public AudioClip Clip;
	[Range(0f, 1f)] public float Volume;
	[Range(.1f, 3)] public float Pitch;

	[NonSerialized] public AudioSource Source;
}