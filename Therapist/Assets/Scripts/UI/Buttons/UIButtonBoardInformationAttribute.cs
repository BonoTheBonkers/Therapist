using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIButtonBoardInformationAttribute : UIButton
{
    public Text valueText;

    protected override void OnButtonClick()
    {
        base.OnButtonClick();
    }

    public void OnEnable()
    {
        EventManager.StartListening(EventManager.OnCurrentLevelChanged, ReloadCurrentAttribute);
        EventManager.StartListening(EventManager.OnLanguageChanged, ReloadCurrentAttribute);
        ReloadCurrentAttribute();
    }

    public void OnDisable()
    {
        EventManager.StopListening(EventManager.OnCurrentLevelChanged, ReloadCurrentAttribute);
        EventManager.StopListening(EventManager.OnLanguageChanged, ReloadCurrentAttribute);
    }

    protected void ReloadCurrentAttribute()
    {
        if(MainManager.GetCurrentAttribute() == EAttribute.Amounts)
        {
            valueText.text = LocalisationSingleton.GetStringForId(2).ToUpper();
        }
        else if (MainManager.GetCurrentAttribute() == EAttribute.SomethingMore)
        {
            valueText.text = LocalisationSingleton.GetStringForId(9).ToUpper();
        }
        else if (MainManager.GetCurrentAttribute() == EAttribute.Colors)
        {
            valueText.text = LocalisationSingleton.GetStringForId(3).ToUpper();
        }
        else if (MainManager.GetCurrentAttribute() == EAttribute.Development)
        {
            valueText.text = LocalisationSingleton.GetStringForId(8).ToUpper();
        }
        else if (MainManager.GetCurrentAttribute() == EAttribute.Movements)
        {
            valueText.text = LocalisationSingleton.GetStringForId(4).ToUpper();
        }
        else if (MainManager.GetCurrentAttribute() == EAttribute.Mixed)
        {
            valueText.text = LocalisationSingleton.GetStringForId(9).ToUpper();
        }
        else if (MainManager.GetCurrentAttribute() == EAttribute.Shapes)
        {
            valueText.text = LocalisationSingleton.GetStringForId(5).ToUpper();
        }
        else if (MainManager.GetCurrentAttribute() == EAttribute.Sizes)
        {
            valueText.text = LocalisationSingleton.GetStringForId(1).ToUpper();
        }
    }
}
