using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : SingletonManager<MusicManager>
{
    protected AudioSource audioSource;
	void Start ()
    {
        audioSource = GetComponent<AudioSource>();
        EventManager.StartListening(EventManager.OnApplicationDataChanged, UpdateVolume);
	}
	
	void UpdateVolume ()
    {
        if (audioSource)
        {
            audioSource.enabled = MainManager.Instance.applicationData.applicationSettings.audioSettings.isMusicMuted;
            audioSource.volume =  MainManager.Instance.applicationData.applicationSettings.audioSettings.musicVolume * 0.3f;
        }
	}
}
