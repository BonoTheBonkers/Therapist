using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtonOpenLogInScreen : UIButton
{
    protected override void OnButtonClick()
    {
        base.OnButtonClick();
        UIManager.SetLogInScreenActive(true);
    }
}
