using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorsSingleton : SingletonMonoBehaviour<ColorsSingleton>
{
    public static Color GetColorFromFlat(EFlatColor flatColor, bool bShadowed /* = false*/)
    {
        foreach (FColorPreset current in ColorsPalette.Instance.colorPresets)
        {
            if (current.flatColor == flatColor)
            {
                return !bShadowed ? current.fullColor : current.shadowedColor;
            }
        }

        return Color.black;
    }

    public static Color GetColorFromTheme(EFlatColor themeColor, EThemePart themePart)
    {
        foreach (FColorPreset current in ColorsPalette.Instance.colorPresets)
        {
            if (current.flatColor == themeColor)
            {
                if(themePart == EThemePart.Background)
                {
                    return current.backgroundColor;
                }
                else if (themePart == EThemePart.ButtonFull)
                {
                    return current.fullColor;
                }
                else if (themePart == EThemePart.ButtonShadowed)
                {
                    return current.shadowedColor;
                }
                else if (themePart == EThemePart.SettingsBackground)
                {
                    return current.settingsBackground;
                }
                else if (themePart == EThemePart.AmbientLight)
                {
                    return current.themeAmbientLight;
                }
                else if (themePart == EThemePart.AmbientDark)
                {
                    return current.themeAmbientDark;
                }
                else if (themePart == EThemePart.FontFullColor)
                {
                    return current.fontFullColor;
                }
                else if (themePart == EThemePart.FontShadowedColor)
                {
                    return current.fontShadowedColor;
                }
                return Color.black;
            }
        }
        return Color.black;
    }

    public static Color GetColorFromThemeForLevel(int levelValue, EThemePart themePart)
    {
        return GetColorFromTheme(LevelsConfig.GetLevels()[levelValue].themeColor, themePart);
    }

    public static Color GetColorFromThemeForCurrentLevel(EThemePart themePart)
    {
        return GetColorFromThemeForLevel(MainManager.GetCurrentLevel(), themePart);
    }
}
