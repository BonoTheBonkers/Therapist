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
        EFlatColor colorToReturn = themeColor;
        foreach (FColorTheme current in ColorsPalette.Instance.colorThemes)
        {
            if (current.theme == themeColor)
            {
                if(themePart == EThemePart.Background)
                {
                    return current.themeBackground;
                }
                else if (themePart == EThemePart.ButtonFull)
                {
                    return current.themeButtonFull;
                }
                else if (themePart == EThemePart.ButtonShadowed)
                {
                    return current.themeButtonShadowed;
                }
                else if (themePart == EThemePart.AmbientLight)
                {
                    return current.themeAmbientLight;
                }
                else if (themePart == EThemePart.AmbientDark)
                {
                    return current.themeAmbientDark;
                }
                return Color.black;
            }
        }

        return Color.black;
    }
}
