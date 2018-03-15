using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIButtonBoardInformationLevel : UIButton
{
    public Text valueText;

    protected override void OnButtonClick()
    {
        base.OnButtonClick();
    }

    public void OnEnable()
    {
        EventManager.StartListening(EventManager.OnCurrentLevelChanged, ReloadCurrentLevel);
        ReloadCurrentLevel();
    }

    public void OnDisable()
    {
        EventManager.StopListening(EventManager.OnCurrentLevelChanged, ReloadCurrentLevel);
    }

    protected void ReloadCurrentLevel()
    {
        valueText.text = (MainManager.GetCurrentLevel() + 1).ToString();
    }
}
