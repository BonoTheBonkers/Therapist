using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UserData", menuName = "Therapist/Personal/UserData", order = 1)]
public class UserData : ScriptableObject
{
    public FPersonalData personalData;
    public EUserType userType = EUserType.Guardian;
    public List<PlayerData> players;
}
