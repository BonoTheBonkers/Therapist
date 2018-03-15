using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AudioDatabase", menuName = "Therapist/Singletons/AudioDatabase", order = 1)]
public class AudioDatabase : SingletonScriptableObject<AudioDatabase>
{
    public FSoundPreset onCursorClick;
    public FSoundPreset correctAnswer;
    public FSoundPreset wrongAnswer;
    public FSoundPreset targetTokenPlaceChanged;
    public FSoundPreset onButtonClicked;
    public FSoundPreset initializeBoard;
}
