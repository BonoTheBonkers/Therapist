using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : SingletonManager<UIManager>
{
    public List<FGameObjectsForScreens> gameObjectForScreen = new List<FGameObjectsForScreens>();
    public UIController languagesListGameObject;
    public UIController playersListGameObject;
    public UIController newPlayerGameObject;
    public UIController settingsGameObject;
    public UIController advancedSettingsGameObject;
    public UIController welcomeScreenGameObject;
    public UILogInScreenController logInScreenGameObject;
    public UIRegisterScreenController registerScreenGameObject;
    public UIAboutScreenController aboutScreenGameObject;
    [HideInInspector]
    public GameObject currentlyDraggedGameObject;
    public BoardController boardController;
    public UIReturnConfirmController returnController;

    public void Start()
    {
        EventManager.StartListening(EventManager.OnCurrentScreenChanged, UpdateCurrentScreen);
        EventManager.StartListening(EventManager.OnAccountLogOut, ForceWelcomeScreen);
        SetLanguagesListActive(false);
        welcomeScreenGameObject.SetUIActiveInstant(true);
        //UpdateCurrentScreen();
    }
    public static void InitializeBoardPublic(FBoardConfig inBoardConfig, Sequence inSequence)
    {
        Instance.boardController.InitializeBoard(inBoardConfig, inSequence);
    }

    protected void UpdateCurrentScreen()
    {
        foreach(FGameObjectsForScreens current in gameObjectForScreen)
        {
            current.gameObject.SetActive(current.screen == MainManager.GetCurrentScreen());
        }
    }

    protected void ForceWelcomeScreen()
    {
        SetWelcomeScreenActiveInstant(true);
    }

    public static void SetLanguagesListActive(bool newIsActive)
    {
        Instance.languagesListGameObject.SetUIActive(newIsActive);
    }

    public static void SetPlayersListActive(bool newIsActive)
    {
        Instance.playersListGameObject.SetUIActive(newIsActive);
    }

    public static void SetNewPlayerScreenActive(bool newIsActive)
    {
        Instance.newPlayerGameObject.SetUIActive(newIsActive);
    }

    public static void SetSettingsScreenActive(bool newIsActive)
    {
        Instance.settingsGameObject.SetUIActive(newIsActive);
    }

    public static void SetAdvancedSettingsScreenActive(bool newIsActive)
    {
        Instance.advancedSettingsGameObject.SetUIActive(newIsActive);
    }

    public static void SetWelcomeScreenActive(bool newIsActive)
    {
        Instance.welcomeScreenGameObject.SetUIActive(newIsActive);
    }

    public static void SetWelcomeScreenActiveInstant(bool newIsActive)
    {
        Instance.welcomeScreenGameObject.SetUIActiveInstant(newIsActive);
    }
    public static void SetLogInScreenActive(bool newIsActive)
    {
        Instance.logInScreenGameObject.SetUIActive(newIsActive);
    }
    public static void SetRegisterScreenActive(bool newIsActive)
    {
        Instance.registerScreenGameObject.SetUIActive(newIsActive);
    }
    public static void SetAboutScreenActive(bool newIsActive)
    {
        Instance.aboutScreenGameObject.SetUIActive(newIsActive);
    }

    public static void ShowConfirmScreen(EReturnConfirmType inReturnConfirmType)
    {
        if (Instance.returnController)
        {
            Instance.returnController.ShowConfirmScreen(inReturnConfirmType);
        }
    }

    public static void HideConfirmScreen()
    {
        if (Instance.returnController)
        {
            Instance.returnController.HideConfirmScreen();
        }
    }
}
