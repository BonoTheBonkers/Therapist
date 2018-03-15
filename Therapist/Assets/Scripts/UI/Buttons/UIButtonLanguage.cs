using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIButtonLanguage : UIButton
{
    public Image flagImage;
    
    protected override void OnButtonClick()
    {
        base.OnButtonClick();
        UIManager.SetLanguagesListActive(true);
        EventManager.TriggerEvent(EventManager.OnOptionScreenOpened);
    }

    // Use this for initialization
    public override void Start ()
    {
        base.Start();
        OnLanguageChanged();
    }

    void OnEnable()
    {
        EventManager.StartListening(EventManager.OnLanguageChanged, OnLanguageChanged);
    }

    void OnDisable()
    {
        EventManager.StopListening(EventManager.OnLanguageChanged, OnLanguageChanged);
    }

    protected void OnLanguageChanged()
    {
        flagImage.sprite = LocalisationSingleton.GetFlagForCurrentLanguage();
    }
}
