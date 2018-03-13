using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FColorPreset
{
    [Tooltip("FlatColor that is representation of this color preset")]
    public EFlatColor flatColor;
    [Tooltip("Fully lighten color of this color preset")]
    public Color fullColor;
    [Tooltip("Shadowed color of this color preset")]
    public Color shadowedColor;
    [Tooltip("Color that will be used for background of this theme")]
    public Color backgroundColor;
    [Tooltip("Color that will be used for lighted ambient elements of this theme")]
    public Color themeAmbientLight;
    [Tooltip("Color that will be used for shadowed ambient elements of this theme")]
    public Color themeAmbientDark;
    [Tooltip("Color that will be used for lighted ambient elements of this theme")]
    public Color fontFullColor = Color.white;
    [Tooltip("Color that will be used for shadowed ambient elements of this theme")]
    public Color fontShadowedColor = Color.gray;
}

[System.Serializable]
public class FFontPreset
{
    [Tooltip("Enum of used flatFont in this text")]
    public EFlatFont flatFont;
    [Tooltip("Font to be used in this flatFont setting")]
    public Font font;
}

[System.Serializable]
public class FBoardConfig
{
    public EExampleConfig exampleConfig = EExampleConfig.SameAttribute;
    public List<FBoardSequenceValues> sequencesValues;
}

[System.Serializable]
public class FBoardSequenceValues
{
    public int value = -1;
    public bool IsSolvedOnStart = false;
}

[System.Serializable]
public class FLanguageDatabase
{
    [Tooltip("List of flags for language")]
    public List<string> texts = new List<string>();
}

[System.Serializable]
public class FSequencesDatabase
{
    [Tooltip("List of every sequence in attribute")]
    public List<Sequence> sequences = new List<Sequence>();
}

[System.Serializable]
public class FPersonalData
{
    [SerializeField]
    public string firstName = "FirstName";
    [SerializeField]
    public string surName = "SurName";
    [SerializeField]
    public ELanguage language = ELanguage.English;
    [SerializeField]
    public Sprite avatarSprite;
    [SerializeField]
    public int age = 8;
}

[System.Serializable]
public class FEntireProgressData
{
    public List<FLevelProgressData> levelsProgress = new List<FLevelProgressData>();

    public FEntireProgressData()
    {
        levelsProgress = new List<FLevelProgressData>();
        for (int i = 0; i < 10; ++i)
        {
            levelsProgress.Add(new FLevelProgressData());
        }
    }
}

[System.Serializable]
public class FLevelProgressData
{
    public List<FAttributeAndProgressData> attributesProgress;

    public FLevelProgressData()
    {
        attributesProgress = new List<FAttributeAndProgressData>();
        for (int i = 0; i < (int)EAttribute.Max; ++i)
        {
            attributesProgress.Add(new FAttributeAndProgressData(((EAttribute)i)));
        }
    }
}

[System.Serializable]
public class FAttributeAndProgressData
{
    public EAttribute attribute;
    public float progress;
    public FAttributeAndProgressData(EAttribute newAttribute)
    {
        attribute = newAttribute;
        progress = 0.0f;
    }
}

[System.Serializable]
public class FGameObjectsForScreens
{
    public EGameScreen screen;
    public GameObject gameObject;
}

[System.Serializable]
public class PlayerData
{
    [SerializeField]
    public FPersonalData personalData = new FPersonalData();
    [SerializeField]
    public FEntireProgressData progressData = new FEntireProgressData();

    public PlayerData(string inFirstName, string inSurName, int inAge)
    {
        personalData.firstName = inFirstName;
        personalData.surName = inSurName;
        personalData.age = inAge;
    }
}

[System.Serializable]
public class FSoundPreset
{
    [SerializeField]
    public List<AudioClip> audioClips = new List<AudioClip>();
    [SerializeField]
    public float playDelay = 0.0f;
    [SerializeField]
    public float volumeMultiplier = 1.0f;
    [SerializeField]
    public bool isSingleInstance = true;

    public AudioClip GetRandomClip()
    {
        if (audioClips.Count == 1)
        {
            return audioClips[0];
        }
        else if(audioClips.Count > 1)
        {
            int randomIndex = Random.Range(0, audioClips.Count - 1);
            return audioClips[randomIndex];
        }

        return new AudioClip();
    }
}