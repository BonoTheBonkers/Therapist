using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FontsSingleton : SingletonMonoBehaviour<FontsSingleton>
{
    public static Font GetFontFromFlat(EFlatFont flatFont)
    {
        foreach (FFontPreset current in FontsPalette.Instance.fontPresets)
        {
            if (current.flatFont == flatFont)
            {
                return current.font;
            }
        }

        Font noFont = new Font();
        return noFont;
    }
}
