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
}
