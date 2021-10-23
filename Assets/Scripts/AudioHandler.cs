using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum TypeSound : int
{
	FireMove,
	Motor,
	SelectedFail,
	Oil,
	Scene,
	RobotClear
}
public class AudioHandler : MonoBehaviour
{
	public static AudioHandler Instance;

	[SerializeField] private AudioSource _soundSource;
	[SerializeField] private AudioSource _musicSource;

	[SerializeField] private AudioClip[] _sounds;
	private void Awake()
	{
		if(Instance == null)
		{
			Instance = this;
		}
		else
		{
			Destroy(gameObject);
		}
		DontDestroyOnLoad(gameObject);
	}

	public void PlaySound(TypeSound sound)
	{
		_soundSource.PlayOneShot(_sounds[(int)sound]);
	}

	public void PlaySound(AudioClip clip)
	{
		_soundSource.PlayOneShot(clip);
	}
}
