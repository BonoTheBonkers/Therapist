using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelConfig", menuName = "Therapist/LevelConfig", order = 1)]
public class LevelConfig : ScriptableObject
{
    [Tooltip("Name id of the Level")]
    public int id = -1;
    [Tooltip("Main theme color of entire level")]
    public EFlatColor themeColor;
    [Tooltip("Boards that player have to solve while playing this level")]
    public List<FBoardConfig> boardConfigs;
}
