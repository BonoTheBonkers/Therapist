using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ProfilesData", menuName = "Therapist/Personal/ProfilesData", order = 1)]
public class ProfilesData : ScriptableObject
{
    public List<UserData> users;
}
