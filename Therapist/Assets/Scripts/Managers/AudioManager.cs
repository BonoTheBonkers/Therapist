using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : SingletonManager<AudioManager>
{
    private AudioSource [] audioSources;

    // Use this for initialization
    void Start ()
    {
        audioSources = GetComponents<AudioSource>();

        EventManager.StartListening(EventManager.OnCursorClick, OnCursorClick);

        EventManager.StartListening(EventManager.OnCorrectAnswer, OnCorrectAnswer);
        EventManager.StartListening(EventManager.OnWrongAnswer, OnWrongAnswer);
        EventManager.StartListening(EventManager.OnTargetTokenPlaceChanged, OnTargetTokenPlaceChanged);
        
        EventManager.StartListening(EventManager.OnInitializeBoard, OnInitializeBoard);

        EventManager.StartListening(EventManager.OnLanguageChanged, OnOptionApplied);
        EventManager.StartListening(EventManager.OnCurrentLevelChanged, OnOptionApplied);
        EventManager.StartListening(EventManager.OnCurrentScreenChanged, OnOptionApplied);
        EventManager.StartListening(EventManager.OnCurrentProgressLevelChanged, OnOptionApplied);
        EventManager.StartListening(EventManager.OnCurrentAttributeChanged, OnOptionApplied);
        EventManager.StartListening(EventManager.OnPlayersListChanged, OnOptionApplied);
        EventManager.StartListening(EventManager.OnPlayerChanged, OnOptionApplied);
        EventManager.StartListening(EventManager.OnContraindicationsChanged, OnOptionApplied);
        EventManager.StartListening(EventManager.OnOptionScreenOpened, OnOptionApplied);
    }

    private void PlayClip(AudioClip clipToPlay, float delay = 0.0f)
    {
        Debug.Log(clipToPlay);
        if(clipToPlay)
        {
            for (int i = 0; i < audioSources.GetLength(0); ++i)
            {
                if (!audioSources[i].isPlaying)
                {
                    audioSources[i].clip = clipToPlay;
                    if (delay == 0.0f)
                    {
                        audioSources[i].Play();
                    }
                    else
                    {
                        audioSources[i].PlayDelayed(delay);
                    }
                    return;
                }
            }
            
            audioSources[0].clip = clipToPlay;
            if(delay == 0.0f)
            {
                audioSources[0].Play();
            }
            else
            {
                audioSources[0].PlayDelayed(delay);
            }
        }
    }
    private void OnCursorClick()
    {
        PlayClip(AudioDatabase.Instance.onCursorClick.GetRandomClip(), AudioDatabase.Instance.onCursorClick.playDelay);
    }
    private void OnCorrectAnswer()
    {
        PlayClip(AudioDatabase.Instance.correctAnswer.GetRandomClip(), AudioDatabase.Instance.correctAnswer.playDelay);
    }
    private void OnWrongAnswer()
    {
        PlayClip(AudioDatabase.Instance.wrongAnswer.GetRandomClip(), AudioDatabase.Instance.wrongAnswer.playDelay);
    }
    private void OnTargetTokenPlaceChanged()
    {
        PlayClip(AudioDatabase.Instance.targetTokenPlaceChanged.GetRandomClip(), AudioDatabase.Instance.targetTokenPlaceChanged.playDelay);
    }
    private void OnOptionApplied()
    {
        PlayClip(AudioDatabase.Instance.onOptionApplied.GetRandomClip(), AudioDatabase.Instance.onOptionApplied.playDelay);
    }
    private void OnInitializeBoard()
    {
        PlayClip(AudioDatabase.Instance.initializeBoard.GetRandomClip(), AudioDatabase.Instance.initializeBoard.playDelay);
    }
}
