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
public class FLevelConfig
{
    [Tooltip("Name of the Level")]
    public string name;
    [Tooltip("Main theme color of entire level")]
    public EFlatColor themeColor;
    [Tooltip("Boards that player have to solve while playing this level")]
    public List<FBoardConfig> boardConfigs;
}

[System.Serializable]
public class FBoardConfig
{
    [Tooltip("Difficulties of sequence that are allowed in this board")]
    public List<EDifficulty> allowedDifficulties = new List<EDifficulty>();
}

[System.Serializable]
public class FLanguageDatabase
{
    [Tooltip("List of every texts in language")]
    public List<string> texts = new List<string>();
}