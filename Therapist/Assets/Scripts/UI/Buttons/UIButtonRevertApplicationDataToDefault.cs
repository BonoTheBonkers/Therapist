using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIButtonRevertApplicationDataToDefault : UIButton
{
    protected override void OnButtonClick()
    {
        base.OnButtonClick();
        MainManager.Instance.applicationData.ResetToDefault();
        EventManager.TriggerEvent(EventManager.OnApplicationDataChanged);
        MainManager.SetCurrentScreen(EGameScreen.MainMenu);
        UIManager.SetSettingsScreenActive(false);
        UIManager.SetPlayersListActive(true);
        UIManager.SetNewPlayerScreenActive(true);
    }
}
