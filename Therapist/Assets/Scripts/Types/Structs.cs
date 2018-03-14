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
    [SerializeField]
    public EFlatFont flatFont;
    [Tooltip("Font to be used in this flatFont setting")]
    [SerializeField]
    public Font font;
}

[System.Serializable]
public class FBoardConfig
{
    [SerializeField]
    public EExampleConfig exampleConfig = EExampleConfig.SameAttribute;
    [SerializeField]
    public List<FBoardSequenceValues> sequencesValues;
}

[System.Serializable]
public class FBoardSequenceValues
{
    [SerializeField]
    public int value = -1;
    [SerializeField]
    public bool IsSolvedOnStart = false;
}

[System.Serializable]
public class FLanguageDatabase
{
    [Tooltip("List of flags for language")]
    [SerializeField]
    public List<string> texts = new List<string>();
}

[System.Serializable]
public class FSequencesDatabase
{
    [Tooltip("List of every sequence in attribute")]
    [SerializeField]
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
    public int age = 8;

    public void ResetToDefault()
    {
        firstName = "FirstName";
        surName = "SurName";
        age = 8;
    }
}

[System.Serializable]
public class FEntireProgressData
{
    [SerializeField]
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
    [SerializeField]
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
    [SerializeField]
    public EAttribute attribute;
    [SerializeField]
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
    [SerializeField]
    public EGameScreen screen;
    [SerializeField]
    public GameObject gameObject;
}

[System.Serializable]
public class PlayerData
{
    [SerializeField]
    public FPersonalData personalData = new FPersonalData();
    [SerializeField]
    public FEntireProgressData progressData = new FEntireProgressData();
    [SerializeField]
    public List<EContraindications> currentContraindications;

    public PlayerData(string inFirstName, string inSurName, int inAge)
    {
        personalData.firstName = inFirstName;
        personalData.surName = inSurName;
        personalData.age = inAge;
    }
}

[System.Serializable]
public class UserData
{
    [SerializeField]
    public FPersonalData personalData;
    [SerializeField]
    public ELanguage language;
    [SerializeField]
    public EUserType userType = EUserType.Guardian;
    [SerializeField]
    public List<PlayerData> players;
    [SerializeField]
    public PlayerData currentPlayer;
    
    public void ResetToDefault()
    {
        personalData.ResetToDefault();
        currentPlayer = new PlayerData("FirstName", "Surname", 8);
        players = new List<PlayerData>();
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

[System.Serializable]
public class FVideoSettings
{
    [SerializeField]
    public bool isHighQuality = true;

    public void ResetToDefault()
    {
        isHighQuality = true;
    }
}

[System.Serializable]
public class FAudioSettings
{
    [SerializeField]
    public float musicVolume = 1.0f;
    [SerializeField]
    public bool isMusicMuted = false;
    [SerializeField]
    public float soundsVolume = 1.0f;
    [SerializeField]
    public bool isSoundsMuted = false;

    public void ResetToDefault()
    {
        musicVolume = 1.0f;
        isMusicMuted = false;
        soundsVolume = 1.0f;
        isSoundsMuted = false;
    }
}

[System.Serializable]
public class FApplicationSettings
{
    [SerializeField]
    public FVideoSettings videoSettings;
    [SerializeField]
    public FAudioSettings audioSettings;

    public void ResetToDefault()
    {
        videoSettings.ResetToDefault();
        audioSettings.ResetToDefault();
    }
}

[System.Serializable]
public class FApplicationData
{
    [SerializeField]
    public UserData userData;
    [SerializeField]
    public FApplicationSettings applicationSettings;

    public void SetLanguage(ELanguage inLanguage)
    {
        if(inLanguage != userData.language)
        {
            userData.language = inLanguage;
            EventManager.TriggerEvent(EventManager.OnApplicationDataChanged);
        }
    }

    public void ResetToDefault()
    {
        userData.ResetToDefault();
        applicationSettings.ResetToDefault();
        EventManager.TriggerEvent(EventManager.OnApplicationDataChanged);
    }

    public void CreateNewPlayer(string inFirstName, string inSurName, int inAge)
    {
        userData.players.Add(new PlayerData(inFirstName, inSurName, inAge));
        EventManager.TriggerEvent(EventManager.OnPlayersListChanged);
        EventManager.TriggerEvent(EventManager.OnApplicationDataChanged);
    }
    public void DeletePlayer(PlayerData playerData)
    {
        if(userData.players.Count > 1)
        {
            userData.players.Remove(playerData);
            EventManager.TriggerEvent(EventManager.OnPlayersListChanged);
            EventManager.TriggerEvent(EventManager.OnApplicationDataChanged);
        }
    }
    public void SetCurrentPlayer(PlayerData playerData)
    {
        if(userData.currentPlayer != playerData)
        {
            userData.currentPlayer = playerData;
            EventManager.TriggerEvent(EventManager.OnPlayerChanged);
            EventManager.TriggerEvent(EventManager.OnApplicationDataChanged);
            if (MainManager.GetCurrentScreen() == EGameScreen.Board)
            {
                MainManager.SetCurrentScreen(EGameScreen.MainMenu);
            }
        }
    }

    public void SetCurrentPlayerContraindications(List<EContraindications> inContraindications)
    {
        if(userData.currentPlayer.currentContraindications != inContraindications)
        {
            userData.currentPlayer.currentContraindications = inContraindications;
            EventManager.TriggerEvent(EventManager.OnContraindicationsChanged);
            EventManager.TriggerEvent(EventManager.OnApplicationDataChanged);
        }
    }
}
