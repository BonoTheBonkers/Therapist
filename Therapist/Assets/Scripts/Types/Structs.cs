﻿using System.Collections;
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
}

[System.Serializable]
public class FColorTheme
{
    [Tooltip("FlatColor that is base of this theme")]
    public EFlatColor theme;
    [Tooltip("Color that will be used for background of this theme")]
    public Color themeBackground;
    [Tooltip("Color that will be used for full button of this theme")]
    public Color themeButtonFull;
    [Tooltip("Color that will be used for shadowed button of this theme")]
    public Color themeButtonShadowed;
    [Tooltip("Color that will be used for lighted ambient elements of this theme")]
    public Color themeAmbientLight;
    [Tooltip("Color that will be used for shadowed ambient elements of this theme")]
    public Color themeAmbientDark;
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
    [Tooltip("Minimal allowed difficulty of sequence in this board")]
    public EDifficulty minDifficulty = EDifficulty.VeryEasy;

    [Tooltip("Maximal allowed difficulty of sequence in this board")]
    public EDifficulty maxDifficulty = EDifficulty.VeryHard;

    public List<FBoardSequenceValues> sequencesValues;
}

[System.Serializable]
public class FBoardSequenceValues
{
    public int value = -1;
    public bool bSolvedOnStart = false;
}

[System.Serializable]
public class FLanguageDatabase
{
    [Tooltip("List of every texts in language")]
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
    public string firstName = "FirstName";
    public string surName = "SurName";
    //public int birthDate = (int)System.DateTime.Now.DayOfWeek;
    public ELanguage langueage = ELanguage.English; 
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
    public List<float> progresses;
    public FAttributeAndProgressData(EAttribute newAttribute)
    {
        attribute = newAttribute;
        progresses = new List<float>();
        for(int i = 0; i < 10; ++i)
        {
            progresses.Add(0.0f);
        }
    }
}