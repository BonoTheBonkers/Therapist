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
            Debug.Log("asd");
            return;
        }

        if (MainManager.GetCurrentScreen() == EGameScreen.MainMenu && !UIManager.Instance.languagesListGameObject.IsUIActive() && !UIManager.Instance.playersListGameObject.IsUIActive() && !UIManager.Instance.newPlayerGameObject.IsUIActive() && !UIManager.Instance.settingsGameObject.IsUIActive())
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
                if(!UIManager.Instance.languagesListGameObject.IsUIActive() && !UIManager.Instance.playersListGameObject.IsUIActive() && !UIManager.Instance.newPlayerGameObject.IsUIActive() && !UIManager.Instance.settingsGameObject.IsUIActive())
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
            UIManager.SetSettingsScreenActive(false);
        }
    }
}
