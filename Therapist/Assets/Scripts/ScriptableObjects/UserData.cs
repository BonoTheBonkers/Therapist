using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UserData", menuName = "Therapist/Personal/UserData", order = 1)]
public class UserData : ScriptableObject
{
    [SerializeField]
    public FPersonalData personalData;
    [SerializeField]
    public EUserType userType = EUserType.Guardian;
    [SerializeField]
    public List<PlayerData> players;
}
