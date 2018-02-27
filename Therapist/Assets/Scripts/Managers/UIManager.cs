using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : SingletonManager<MainManager>
{
    public List<FGameObjectsForScreens> gameObjectForScreen = new List<FGameObjectsForScreens>();

    public void Start()
    {
        EventManager.StartListening("OnCurrentScreenChanged", UpdateCurrentScreen);
        //UpdateCurrentScreen();
    }

    protected void UpdateCurrentScreen()
    {
        foreach(FGameObjectsForScreens current in gameObjectForScreen)
        {
            current.gameObject.SetActive(current.screen == MainManager.GetCurrentScreen());
        }
    }
}
