using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : SingletonManager<UIManager>
{
    public List<FGameObjectsForScreens> gameObjectForScreen = new List<FGameObjectsForScreens>();
    public GameObject languagesListGameObject;
    public GameObject playersListGameObject;
    public GameObject newPlayerGameObject;
    public GameObject settingsGameObject;
    [HideInInspector]
    public GameObject currentlyDraggedGameObject;

    public void Start()
    {
        EventManager.StartListening(EventManager.OnCurrentScreenChanged, UpdateCurrentScreen);
        SetLanguagesListActive(false);
        //UpdateCurrentScreen();
    }

    protected void UpdateCurrentScreen()
    {
        foreach(FGameObjectsForScreens current in gameObjectForScreen)
        {
            current.gameObject.SetActive(current.screen == MainManager.GetCurrentScreen());
        }
    }

    public static void SetLanguagesListActive(bool newIsActive)
    {
        Instance.languagesListGameObject.SetActive(newIsActive);
    }

    public static void SetPlayersListActive(bool newIsActive)
    {
        Instance.playersListGameObject.SetActive(newIsActive);
    }

    public static void SetNewPlayerScreenActive(bool newIsActive)
    {
        Instance.newPlayerGameObject.SetActive(newIsActive);
    }

    public static void SetSettingsScreenActive(bool newIsActive)
    {
        Instance.settingsGameObject.SetActive(newIsActive);
    }
}
