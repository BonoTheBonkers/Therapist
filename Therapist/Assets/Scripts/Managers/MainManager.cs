using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : SingletonManager<MainManager>
{
    private static int currentLevel = 0;

    public static void SetCurrentLevel(int inLevel)
    {
        currentLevel = inLevel;
    }

    public static int GetCurrentLevel()
    {
        return currentLevel;
    }
}
