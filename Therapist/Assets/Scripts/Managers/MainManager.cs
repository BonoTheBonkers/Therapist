using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : SingletonManager<MainManager>
{
    public UserData currentUser;
    public PlayerData currentPlayer;

    protected static EGameScreen currentScreen = EGameScreen.MainMenu;
    protected static int currentLevel = 0;
    protected static EAttribute currentAttribute = EAttribute.Development;
    protected static int currentProgressLevel = 0;

    public void Start()
    {
        LocalisationDatabase.ReloadLocalisationDatabase();
        SequencesConfig.ReloadSequencesDatabase();
    }

    public void OnEnable()
    {
        GenerateBoard();
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.N))
        {
            GenerateBoard();
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            OnWin();
        }
    }

    public bool GetBestBoardConfig(EAttribute inAttribute, int inLevel, out FBoardConfig outBoardConfig)
    {
        currentLevel = inLevel;
        currentAttribute = inAttribute;
        float currentProgressValue = currentPlayer.progressData.levelsProgress[currentLevel].attributesProgress[(int)inAttribute].progress;
        //currentProgressLevel = currentPlayer.progressData.levelsProgress[currentLevel].attributesProgress[(int)inAttribute].progress < 1.0f ? (Mathf.Clamp((int)(currentProgressValue * 10.0f), 0, 9)) : 0;
        outBoardConfig = LevelsConfig.GetLevels()[currentLevel].boardConfigs[currentProgressLevel];
        return true;
    }

    public bool GetRandomSequence(EAttribute inAttribute, FBoardConfig inBoardConfig, out Sequence outSequence)
    {
        if(SequencesConfig.GetRandomSequence(inAttribute, inBoardConfig, out outSequence))
        {
            return true;
        }

        Debug.Log("MainManager - GetRandomSequence failed!");
        outSequence = new Sequence();
        return false;
    }

    public void GenerateBoard()
    {
        FBoardConfig bestBoardConfig;
        if(GetBestBoardConfig(currentAttribute, currentLevel, out bestBoardConfig))
        {
            Sequence bestSequence;
            if (GetRandomSequence(currentAttribute, bestBoardConfig, out bestSequence))
            {
                BoardController.InitializeBoardPublic(bestBoardConfig, bestSequence);
            }
        }
    }

    public void OnWin()
    {
        if(currentProgressLevel < 9)
        {
            currentProgressLevel = currentProgressLevel + 1;
            float newProgressValue = Mathf.Clamp(currentProgressLevel / 10.0f, 0.0f, 1.0f);
            if (newProgressValue > currentPlayer.progressData.levelsProgress[currentLevel].attributesProgress[(int)currentAttribute].progress)
            {
                currentPlayer.progressData.levelsProgress[currentLevel].attributesProgress[(int)currentAttribute].progress = newProgressValue;
                EventManager.TriggerEvent(currentAttribute.ToString() + " progress increased to " + newProgressValue.ToString());
            }
        }
        else
        {
            currentPlayer.progressData.levelsProgress[currentLevel].attributesProgress[(int)currentAttribute].progress = 1.0f;
            currentProgressLevel = 0;
        }
        GenerateBoard();
    }

    public static EGameScreen GetCurrentScreen()
    {
        return currentScreen;
    }
    public static void SetCurrentScreen(EGameScreen inScreen)
    {
        currentScreen = inScreen;
        EventManager.TriggerEvent("OnCurrentScreenChanged");
        if(currentScreen == EGameScreen.Board)
        {
            Instance.GenerateBoard();
        }
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

    public static float GetProgressPercentageAtLevel(int inLevel)
    {
        if(!Instance)
        {
            return 0.0f;
        }

        return Instance.GetProgressPercentageAtLevelPrivate(inLevel);
    }

    protected float GetProgressPercentageAtLevelPrivate(int inLevel)
    {
        if (!currentPlayer)
        {
            return 0.0f;
        }

        float valueToReturn = 0.0f;
        for(int i = 0; i < (int)EAttribute.Max; ++i)
        {
            valueToReturn += currentPlayer.progressData.levelsProgress[inLevel].attributesProgress[i].progress;
        }

        valueToReturn /= (int)EAttribute.Max;

        return valueToReturn;
    }

    public static float GetAttributeProgressPercentageAtCurrentLevel(EAttribute inAttribute)
    {
        return GetAttributeProgressPercentageAtLevel(inAttribute, GetCurrentLevel());
    }

    public static float GetAttributeProgressPercentageAtLevel(EAttribute inAttribute, int inLevel)
    {
        if(Instance == null)
        {
            return 0.0f;
        }

        return Instance.GetAttributeProgressPercentageAtLevelPrivate(inAttribute, inLevel);
    }

    protected float GetAttributeProgressPercentageAtLevelPrivate(EAttribute inAttribute, int inLevel)
    {
        if(currentPlayer == null)
        {
            return 0.0f;
        }

        return currentPlayer.progressData.levelsProgress[inLevel].attributesProgress[(int)inAttribute].progress;
    }
}
