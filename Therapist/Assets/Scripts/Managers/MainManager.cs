﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : SingletonManager<MainManager>
{
    public FApplicationData applicationData;

    protected static EGameScreen currentScreen = EGameScreen.MainMenu;
    protected static EGameScreen previousScreen = EGameScreen.MainMenu;
    protected static int currentLevel = 0;
    protected static EAttribute currentAttribute = EAttribute.Development;
    protected static int currentProgressLevel = 0;

    public void Start()
    {
        LocalisationDatabase.ReloadLocalisationDatabase();
        SequencesConfig.ReloadSequencesDatabase();
        FindNextBestLevelAndAttribute();
        if(applicationData.userData.currentPlayer == null)
        {
            UIManager.SetPlayersListActive(true);
        }
    }

    public void OnEnable()
    {
        //GenerateBoard();
        SetCurrentScreen(EGameScreen.MainMenu);
    }

    public void Update()
    {
    }

    public bool GetBestBoardConfig(EAttribute inAttribute, int inLevel, ref FBoardConfig outBoardConfig)
    {
        currentLevel = inLevel;
        currentAttribute = inAttribute;
        //float currentProgressValue = currentPlayer.progressData.levelsProgress[currentLevel].attributesProgress[(int)inAttribute].progress;
        //currentProgressLevel = currentPlayer.progressData.levelsProgress[currentLevel].attributesProgress[(int)inAttribute].progress < 1.0f ? (Mathf.Clamp((int)(currentProgressValue * 10.0f), 0, 9)) : 0;
        outBoardConfig = LevelsConfig.GetLevels()[currentLevel].boardConfigs[GetCurrentProgressLevel()];
        return true;
    }

    public bool GetRandomSequence(EAttribute inAttribute, FBoardConfig inBoardConfig, ref Sequence outSequence)
    {
        if(SequencesConfig.GetRandomSequence(inAttribute, inBoardConfig, ref outSequence))
        {
            return true;
        }

        //Debug.Log("MainManager - GetRandomSequence failed!");
        return false;
    }

    public void GenerateBoard()
    {
        FBoardConfig bestBoardConfig = null;
        if(GetBestBoardConfig(currentAttribute, currentLevel, ref bestBoardConfig))
        {
            Sequence bestSequence = null;
            if (GetRandomSequence(currentAttribute, bestBoardConfig, ref bestSequence))
            {
                BoardController.InitializeBoardPublic(bestBoardConfig, bestSequence);
            }
        }
    }

    public static void OnWin()
    {
        if(!Instance)
        {
            return;
        }

        Instance.OnWinPrivate();
    }

    public void OnWinPrivate()
    {
        if(GetCurrentPlayer() == null)
        {
            Debug.Log("No player");
            return;
        }

        if(GetCurrentProgressLevel() < 9)
        {
            SetCurrentProgressLevel(GetCurrentProgressLevel() + 1);
            float newProgressValue = GetCurrentProgressLevelPercentage();
            if (newProgressValue > GetCurrentPlayer().progressData.levelsProgress[currentLevel].attributesProgress[(int)currentAttribute].progress)
            {
                GetCurrentPlayer().progressData.levelsProgress[currentLevel].attributesProgress[(int)currentAttribute].progress = newProgressValue;
                EventManager.TriggerEvent(currentAttribute.ToString() + " progress increased to " + newProgressValue.ToString());
            }
        }
        else
        {
            GetCurrentPlayer().progressData.levelsProgress[currentLevel].attributesProgress[(int)currentAttribute].progress = 1.0f;
            if(!FindNextBestLevelAndAttribute())
            {
                SetCurrentScreen(EGameScreen.AttributeMenu);
            }
        }
        EventManager.TriggerEvent(EventManager.OnApplicationDataChanged);
        GenerateBoard();
    }

    public static EGameScreen GetCurrentScreen()
    {
        return currentScreen;
    }

    public static EGameScreen GetPreviousScreen()
    {
        return previousScreen;
    }

    public static void SetCurrentScreen(EGameScreen inScreen)
    {
        previousScreen = currentScreen;
        currentScreen = inScreen;
        EventManager.TriggerEvent(EventManager.OnCurrentScreenChanged);
        if(inScreen == EGameScreen.Board)
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
        EventManager.TriggerEvent(EventManager.OnCurrentLevelChanged);
    }

    public static int GetCurrentProgressLevel()
    {
        return currentProgressLevel;
    }
    public static float GetCurrentProgressLevelPercentage()
    {
        return Mathf.Clamp(GetCurrentProgressLevel() / 10.0f, 0.0f, 1.0f);
    }

    public static void SetCurrentProgressLevel(int inProgressLevel)
    {
        currentProgressLevel = inProgressLevel;
        EventManager.TriggerEvent(EventManager.OnCurrentProgressLevelChanged);
    }

    public static PlayerData GetCurrentPlayer()
    {
        return Instance.applicationData.userData.currentPlayer;
    }

    public static UserData GetCurrentUser()
    {
        return Instance.applicationData.userData;
    }

    public static bool FindNextBestLevelAndAttribute()
    {
        if(!Instance)
        {
            return false;
        }

        return Instance.FindNextBestLevelAndAttributePrivate();
    }

    public bool FindNextBestLevelAndAttributePrivate()
    {
        if(GetCurrentPlayer() == null)
        {
            return false;
        }

        for(int i = 0; i < GetCurrentPlayer().progressData.levelsProgress.Count; ++i)
        {
            for(int j = 0; j < GetCurrentPlayer().progressData.levelsProgress[i].attributesProgress.Count; ++j)
            {
                if(GetCurrentPlayer().progressData.levelsProgress[i].attributesProgress[j].progress < 1.0f)
                {
                    SetCurrentLevel(i);
                    SetCurrentAttribute(GetCurrentPlayer().progressData.levelsProgress[i].attributesProgress[j].attribute);
                    SetCurrentProgressLevel(0);
                    return true;
                }
            }
        }

        return false;
    }

    public static EAttribute GetCurrentAttribute()
    {
        return currentAttribute;
    }
    public static void SetCurrentAttribute(EAttribute inAttibute)
    {
        currentAttribute = inAttibute;
        EventManager.TriggerEvent(EventManager.OnCurrentAttributeChanged);
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
        if (GetCurrentPlayer() == null)
        {
            return 0.0f;
        }

        float valueToReturn = 0.0f;
        for(int i = 0; i < (int)EAttribute.Max; ++i)
        {
            valueToReturn += GetCurrentPlayer().progressData.levelsProgress[inLevel].attributesProgress[i].progress;
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
        if(GetCurrentPlayer() == null)
        {
            return 0.0f;
        }

        return GetCurrentPlayer().progressData.levelsProgress[inLevel].attributesProgress[(int)inAttribute].progress;
    }

    public static void CreateNewPlayer(string inFirstName, string inSurName, int inAge)
    {
        Instance.applicationData.CreateNewPlayer(inFirstName, inSurName, inAge);
    }

    public static void DeletePlayer(PlayerData playerData)
    {
        Instance.applicationData.DeletePlayer(playerData);
    }

    public static void SetCurrentPlayer(PlayerData playerData)
    {
        Instance.applicationData.SetCurrentPlayer(playerData);
    }
}
