using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelsConfig", menuName = "Therapist/Singletons/LevelsConfig", order = 1)]
public class LevelsConfig : SingletonScriptableObject<LevelsConfig>
{
    /** VARIABLES */

    /* Public variables - START */
    [Tooltip("List of all levels in game")]
    public List<LevelConfig> levels = new List<LevelConfig>();
    /* Public variables - END */

    public static List<LevelConfig> GetLevels()
    {
        return Instance.levels;
    }
}