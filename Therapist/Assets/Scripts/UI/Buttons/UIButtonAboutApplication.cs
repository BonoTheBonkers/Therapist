using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtonAboutApplication : UIButton
{
    protected override void OnButtonClick()
    {
        base.OnButtonClick();
        UIManager.SetAboutScreenActive(true);
    }
}
