using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtonAdvancedSettings : UIButton
{
    protected override void OnButtonClick()
    {
        base.OnButtonClick();

        UIManager.SetAdvancedSettingsScreenActive(true);
    }
}
