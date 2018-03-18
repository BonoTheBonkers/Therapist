using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtonReturnConfirm : UIButton
{
    protected override void OnButtonClick()
    {
        MainManager.ReturnConfirm();
    }
}
