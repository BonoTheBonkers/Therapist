using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIButtonAddNewPlayerButton_01 : UIButton
{
    protected override void OnButtonClick()
    {
        base.OnButtonClick();
        UIManager.SetNewPlayerScreenActive(true);
        UIManager.SetPlayersListActive(false);
    }
}
