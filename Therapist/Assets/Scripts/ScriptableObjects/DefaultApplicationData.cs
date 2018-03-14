using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DefaultApplicationData", menuName = "Therapist/Singletons/DefaultApplicationData", order = 1)]
public class DefaultApplicationData : SingletonScriptableObject<DefaultApplicationData>
{
    public FApplicationData defaultApplicationData = new FApplicationData();
}
