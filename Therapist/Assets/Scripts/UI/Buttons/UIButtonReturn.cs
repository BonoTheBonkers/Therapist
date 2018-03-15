using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIButtonReturn : UIButton
{
    protected override void OnButtonClick()
    {
        base.OnButtonClick();
        if(MainManager.GetCurrentScreen() == EGameScreen.MainMenu && !UIManager.Instance.languagesListGameObject.active && !UIManager.Instance.playersListGameObject.active && !UIManager.Instance.newPlayerGameObject.active && !UIManager.Instance.settingsGameObject.active)
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
