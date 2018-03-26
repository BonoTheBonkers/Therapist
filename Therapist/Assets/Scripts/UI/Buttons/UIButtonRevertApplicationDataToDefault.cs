using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIButtonRevertApplicationDataToDefault : UIButton
{
    protected override void OnButtonClick()
    {
        base.OnButtonClick();
        UIManager.Instance.returnController.ShowConfirmScreen(EReturnConfirmType.ResetApllication);
    }
}
