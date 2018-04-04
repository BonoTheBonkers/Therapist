using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtonBoardSelect : UIButton
{
    public EBoardType boardType = EBoardType.Sequences;

    protected override void OnButtonClick()
    {
        base.OnButtonClick();
        MainManager.SetCurrentBoardType(boardType);
    }
}
