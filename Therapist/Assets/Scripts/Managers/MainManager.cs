using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : SingletonManager<MainManager>
{
    protected static EGameScreen currentScreen = EGameScreen.Intro;
    protected static int currentLevel = 1;
    protected static EAttribute currentAttribute;
    
    public static EGameScreen GetCurrentScreen()
    {
        return currentScreen;
    }
    public static void SetCurrentScreen(EGameScreen inScreen)
    {
        currentScreen = inScreen;
        EventManager.TriggerEvent("OnCurrentScreenChanged");
    }

    public static int GetCurrentLevel()
    {
        return currentLevel;
    }
    public static void SetCurrentLevel(int inLevel)
    {
        currentLevel = inLevel;
        EventManager.TriggerEvent("OnCurrentLevelChanged");
    }
    
    public static EAttribute GetCurrentAttribute()
    {
        return currentAttribute;
    }
    public static void SetCurrentAttribute(EAttribute inAttibute)
    {
        currentAttribute = inAttibute;
        EventManager.TriggerEvent("OnCurrentAttributeChanged");
    }

}
