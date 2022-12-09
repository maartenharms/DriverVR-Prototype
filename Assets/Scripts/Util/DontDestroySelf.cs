using UnityEngine;

public class DontDestroySelf : MonoBehaviour
{
	void Start() => DontDestroyOnLoad(this);
}