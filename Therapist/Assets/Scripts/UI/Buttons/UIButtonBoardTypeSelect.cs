using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtonBoardTypeSelect : UIButton
{
    protected override void OnButtonClick()
    {
        base.OnButtonClick();
        UIManager.SetBoardSelectionScreenActive(true);
    }
}
