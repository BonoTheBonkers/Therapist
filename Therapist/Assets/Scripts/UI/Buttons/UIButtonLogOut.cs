using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtonLogOut : UIButton
{
    protected override void OnButtonClick()
    {
        base.OnButtonClick();
        MainManager.Instance.applicationData.LogOut();
    }
}
