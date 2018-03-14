﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIButtonReturn : MonoBehaviour
{
    protected Button button;

    public void Start()
    {
        button = GetComponentInChildren<Button>();
        if (button)
        {
            button.onClick.AddListener(OnButtonClick);
        }
    }
    
    protected void OnButtonClick()
    {
        if(MainManager.GetCurrentScreen() == EGameScreen.MainMenu)
        {
            Application.Quit();
        }
        if(UIManager.Instance.newPlayerGameObject.active)
        {
            if(MainManager.Instance.applicationData.userData.players.Count > 0)
            {
                UIManager.SetNewPlayerScreenActive(false);
            }
        }
        else
        {
            if (MainManager.GetCurrentScreen() == EGameScreen.Board)
            {
                MainManager.SetCurrentScreen(MainManager.GetPreviousScreen());
            }
            else
            {
                MainManager.SetCurrentScreen(EGameScreen.MainMenu);
            }

            UIManager.SetLanguagesListActive(false);
            UIManager.SetPlayersListActive(false);
            UIManager.SetSettingsScreenActive(false);
        }
    }
}
