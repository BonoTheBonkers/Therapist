using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PrefabsConfig", menuName = "Therapist/Singletons/PrefabsConfig", order = 1)]
public class PrefabsConfig : SingletonScriptableObject<PrefabsConfig>
{
    public GameObject tokenPrefab;
    public GameObject tokenPlacePrefab;
    public GameObject playerAtListPrefab;
    public Sprite missingAvatarSprite;
    public Sprite defaultAvatarSprite;

    public static GameObject GetTokenPrefab()
    {
        return Instance.tokenPrefab;
    }
    public static GameObject GetTokenPlacePrefab()
    {
        return Instance.tokenPlacePrefab;
    }
    public static GameObject GetPlayerAtListPrefab()
    {
        return Instance.playerAtListPrefab;
    }
    public static Sprite GetMissingAvatarSprite()
    {
        return Instance.missingAvatarSprite;
    }
    public static Sprite GetDefaultAvatarSprite()
    {
        return Instance.defaultAvatarSprite;
    }
}
