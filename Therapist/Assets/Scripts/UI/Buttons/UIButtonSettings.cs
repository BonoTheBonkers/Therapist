using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIButtonSettings : UIButton
{
    protected override void OnButtonClick()
    {
        base.OnButtonClick();
        UIManager.SetSettingsScreenActive(true);
        EventManager.TriggerEvent(EventManager.OnOptionScreenOpened);
    }
}
