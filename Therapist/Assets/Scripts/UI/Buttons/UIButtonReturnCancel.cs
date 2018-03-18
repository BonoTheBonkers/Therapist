using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtonReturnCancel : UIButton
{
    protected override void OnButtonClick()
    {
        MainManager.ReturnCancel();
    }
}
