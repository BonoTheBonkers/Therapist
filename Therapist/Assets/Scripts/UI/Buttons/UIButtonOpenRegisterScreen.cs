using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtonOpenRegisterScreen : UIButton
{
    protected override void OnButtonClick()
    {
        base.OnButtonClick();
        UIManager.SetRegisterScreenActive(true);
    }
}
