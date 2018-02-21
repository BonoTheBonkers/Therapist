using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FColorPreset
{
    public EFlatColor flatColor;
    public Color fullColor;
    public Color shadowedColor;
}

[System.Serializable]
public class FColorTheme
{
    public EFlatColor theme;
    public Color themeBackground;
    public Color themeButtonFull;
    public Color themeButtonShadowed;
    public Color themeAmbientLight;
    public Color themeAmbientDark;
}

[System.Serializable]
public class FFontPreset
{
    public EFlatFont flatFont;
    public Font font;
}

[System.Serializable]
public class FLevelConfig
{
    public string name;
    public EFlatColor themeColor;
}