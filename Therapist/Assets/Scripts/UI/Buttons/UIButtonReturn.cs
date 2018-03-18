using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIButtonReturn : UIButton
{
    protected override void OnButtonClick()
    {
        base.OnButtonClick();

        if(UIReturnConfirmController.Instance.gameObject.activeInHierarchy)
        {
            MainManager.ReturnCancel();
            return;
        }

        if(MainManager.GetCurrentScreen() == EGameScreen.MainMenu && !UIManager.Instance.languagesListGameObject.activeInHierarchy && !UIManager.Instance.playersListGameObject.activeInHierarchy && !UIManager.Instance.newPlayerGameObject.activeInHierarchy && !UIManager.Instance.settingsGameObject.activeInHierarchy)
        {
            UIReturnConfirmController.ShowConfirmScreen(EReturnConfirmType.QuitApplication);
        }
        if(UIManager.Instance.newPlayerGameObject.activeInHierarchy)
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
                if(MainManager.GetPreviousScreen() == EGameScreen.AttributeMenu)
                {
                    UIReturnConfirmController.ShowConfirmScreen(EReturnConfirmType.ReturnToAttributes);
                }
                else
                {
                    UIReturnConfirmController.ShowConfirmScreen(EReturnConfirmType.ReturnToMainMenu);
                }
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
