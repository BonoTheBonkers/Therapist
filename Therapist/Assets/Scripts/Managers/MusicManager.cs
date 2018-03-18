using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : SingletonManager<MusicManager>
{
    protected AudioSource audioSource;
	void Start ()
    {
        audioSource = GetComponent<AudioSource>();
        UpdateVolume();
        EventManager.StartListening(EventManager.OnApplicationDataChanged, UpdateVolume);
        EventManager.StartListening(EventManager.OnApplicationDataLoaded, UpdateVolume);
    }
	
	void UpdateVolume ()
    {
        if (audioSource)
        {
            audioSource.enabled = !MainManager.Instance.applicationData.applicationSettings.audioSettings.isMusicMuted;
            audioSource.volume =  MainManager.Instance.applicationData.applicationSettings.audioSettings.musicVolume * 0.3f;
        }
	}
}
