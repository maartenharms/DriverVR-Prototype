using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxManager : MonoBehaviour
{
	public AudioManager AudioManager;
	public Material SkyboxDay;
	public Material SkyboxNight;
	public GameObject DirectionalLight;

	bool IsDay = true;
	bool ToChange = false;

	public void SwitchTimeOfDay()
	{
		AudioManager.PlaySwitch();
		IsDay = !IsDay;
		ToChange = true;
	}

	public void SetDayTime()
	{
		DirectionalLight.SetActive(true);
		RenderSettings.skybox = SkyboxDay;
	}

	public void SetNightTime()
	{
		DirectionalLight.SetActive(false);
		RenderSettings.skybox = SkyboxNight;
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
			SwitchTimeOfDay();

		if (IsDay && ToChange)
		{
			SetDayTime();
			ToChange = false;
		}
		else if (!IsDay && ToChange)
		{
			SetNightTime();
			ToChange = false;
		}
	}
}
