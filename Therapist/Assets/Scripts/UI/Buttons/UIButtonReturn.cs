using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIButtonReturn : UIButton
{
    protected override void OnButtonClick()
    {
        base.OnButtonClick();

        if(UIManager.Instance.returnController.IsUIActive())
        {
            MainManager.ReturnCancel();
            return;
        }

        if (MainManager.GetCurrentScreen() == EGameScreen.MainMenu && !UIManager.Instance.languagesListGameObject.IsUIActive() && !UIManager.Instance.playersListGameObject.IsUIActive() && !UIManager.Instance.newPlayerGameObject.IsUIActive() && !UIManager.Instance.settingsGameObject.IsUIActive() && !UIManager.Instance.registerScreenGameObject.IsUIActive() && !UIManager.Instance.logInScreenGameObject.IsUIActive() && !UIManager.Instance.welcomeScreenGameObject.IsUIActive())
        {
            UIManager.Instance.returnController.ShowConfirmScreen(EReturnConfirmType.QuitApplication);
        }
        if(UIManager.Instance.newPlayerGameObject.IsUIActive())
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
                if(!UIManager.Instance.languagesListGameObject.IsUIActive() && !UIManager.Instance.playersListGameObject.IsUIActive() && !UIManager.Instance.newPlayerGameObject.IsUIActive() && !UIManager.Instance.settingsGameObject.IsUIActive() && !UIManager.Instance.registerScreenGameObject.IsUIActive() && !UIManager.Instance.logInScreenGameObject.IsUIActive() && !UIManager.Instance.welcomeScreenGameObject.IsUIActive())
                {
                    if (MainManager.GetPreviousScreen() == EGameScreen.AttributeMenu)
                    {
                        UIManager.Instance.returnController.ShowConfirmScreen(EReturnConfirmType.ReturnToAttributes);
                    }
                    else
                    {
                        UIManager.Instance.returnController.ShowConfirmScreen(EReturnConfirmType.ReturnToMainMenu);
                    }
                }
            }
            else
            {
                MainManager.SetCurrentScreen(EGameScreen.MainMenu);
            }

            UIManager.SetLanguagesListActive(false);
            UIManager.SetPlayersListActive(false);
            if (!UIManager.Instance.aboutScreenGameObject.IsUIActive())
            {
                UIManager.SetAdvancedSettingsScreenActive(false);
            }
            if (!UIManager.Instance.advancedSettingsGameObject.IsUIActive())
            {
                UIManager.SetSettingsScreenActive(false);
            }
        }
        if (!UIManager.Instance.registerScreenGameObject.IsUIActive() && !UIManager.Instance.logInScreenGameObject.IsUIActive())
        {
            UIManager.SetWelcomeScreenActive(false);
        }
        UIManager.SetLogInScreenActive(false);
        UIManager.SetRegisterScreenActive(false);
        UIManager.SetAboutScreenActive(false);
    }
}
