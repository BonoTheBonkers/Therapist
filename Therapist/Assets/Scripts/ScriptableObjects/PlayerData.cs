using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Therapist/Personal/PlayerData", order = 1)]
public class PlayerData : ScriptableObject
{
    public FPersonalData personalData;
    public FEntireProgressData progressData;
}
