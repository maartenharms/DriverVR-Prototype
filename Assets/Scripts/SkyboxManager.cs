using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxManager : MonoBehaviour
{
	public Material SkyboxDay;
	public Material SkyboxNight;
	public GameObject DirectionalLight;

	public bool IsDay = true;
	public bool ToChange = false;

	void Start() => SetDayTime();

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
		if(Input.GetKeyDown(KeyCode.Space))
		{
			IsDay = !IsDay;
			ToChange = true;
		}

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
