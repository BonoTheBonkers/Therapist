using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIButtonBoardInformationAttribute : MonoBehaviour
{
    public Text valueText;

    protected Button button;
    // Use this for initialization

    public void Start()
    {
        button = GetComponentInChildren<Button>();
        if (button)
        {
            button.onClick.AddListener(OnButtonClick);
        }
    }

    public void OnEnable()
    {
        EventManager.StartListening("OnCurrentLevelChanged", ReloadCurrentAttribute);
        EventManager.StartListening("OnLanguageChanged", ReloadCurrentAttribute);
        ReloadCurrentAttribute();
    }

    public void OnDisable()
    {
        EventManager.StopListening("OnCurrentLevelChanged", ReloadCurrentAttribute);
        EventManager.StopListening("OnLanguageChanged", ReloadCurrentAttribute);
    }

    protected void OnButtonClick()
    {
    }

    protected void ReloadCurrentAttribute()
    {
        if(MainManager.GetCurrentAttribute() == EAttribute.Amount)
        {
            valueText.text = LocalisationSingleton.GetStringForId(2).ToUpper();
        }
        else if (MainManager.GetCurrentAttribute() == EAttribute.Brightness)
        {
            valueText.text = LocalisationSingleton.GetStringForId(9).ToUpper();
        }
        else if (MainManager.GetCurrentAttribute() == EAttribute.ColorIntensity)
        {
            valueText.text = LocalisationSingleton.GetStringForId(3).ToUpper();
        }
        else if (MainManager.GetCurrentAttribute() == EAttribute.Development)
        {
            valueText.text = LocalisationSingleton.GetStringForId(8).ToUpper();
        }
        else if (MainManager.GetCurrentAttribute() == EAttribute.Position)
        {
            valueText.text = LocalisationSingleton.GetStringForId(4).ToUpper();
        }
        else if (MainManager.GetCurrentAttribute() == EAttribute.Rotation)
        {
            valueText.text = LocalisationSingleton.GetStringForId(9).ToUpper();
        }
        else if (MainManager.GetCurrentAttribute() == EAttribute.Shape)
        {
            valueText.text = LocalisationSingleton.GetStringForId(5).ToUpper();
        }
        else if (MainManager.GetCurrentAttribute() == EAttribute.Size)
        {
            valueText.text = LocalisationSingleton.GetStringForId(1).ToUpper();
        }
    }
}
