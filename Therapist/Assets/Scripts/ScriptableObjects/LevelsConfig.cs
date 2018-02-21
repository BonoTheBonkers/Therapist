using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelsConfig", menuName = "Therapist/LevelsConfig", order = 1)]
public class LevelsConfig : SingletonScriptableObject<LevelsConfig>
{
    /** VARIABLES */

    /* Public variables - START */
    public List<FLevelConfig> colorPresets = new List<FLevelConfig>();
    /* Public variables - END */
}