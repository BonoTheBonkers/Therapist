using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ColorsPalette", menuName = "Therapist/ColorsPalette", order = 1)]
public class ColorsPalette : SingletonScriptableObject<ColorsPalette>
{
    /** VARIABLES */

    /* Public variables - START */
    public List<FColorPreset> colorPresets = new List<FColorPreset>();
    /* Public variables - END */

    void OnValidate()
    {
        if (Application.isPlaying)
        {
            return;
        }

        FlatImage[] flatImages = FindObjectsOfType(typeof(FlatImage)) as FlatImage[];
        foreach(FlatImage current in flatImages)
        {
            current.ApplyColor();
        }
    }
}