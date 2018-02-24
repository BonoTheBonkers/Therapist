using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FontsPalette", menuName = "Therapist/Singletons/FontsPalette", order = 1)]
public class FontsPalette : SingletonScriptableObject<FontsPalette>
{
    /** VARIABLES */

    /* Public variables - START */
    [Tooltip("All presents of fonts in this projects")]
    public List<FFontPreset> fontPresets = new List<FFontPreset>();
    /* Public variables - END */

    void OnValidate()
    {
        if (Application.isPlaying)
        {
            return;
        }

        FlatFont[] flatFonts = FindObjectsOfType(typeof(FlatFont)) as FlatFont[];
        foreach (FlatFont current in flatFonts)
        {
            current.ApplyFont();
        }
    }
}