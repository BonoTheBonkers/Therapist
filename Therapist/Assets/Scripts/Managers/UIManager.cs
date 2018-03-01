using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : SingletonManager<UIManager>
{
    public List<FGameObjectsForScreens> gameObjectForScreen = new List<FGameObjectsForScreens>();
    public GameObject languagesListGameObject;

    public void Start()
    {
        EventManager.StartListening("OnCurrentScreenChanged", UpdateCurrentScreen);
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
}
