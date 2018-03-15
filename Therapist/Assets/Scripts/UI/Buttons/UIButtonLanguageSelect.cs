using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIButtonLanguageSelect : UIButton
{
    public ELanguage language = ELanguage.Polish;
    public Image flagImage;
    
    protected override void OnButtonClick()
    {
        base.OnButtonClick();
        SettingsSingleton.SetLanguage(language);
        UIManager.SetLanguagesListActive(false);
    }

    public void Awake()
    {
        flagImage.sprite = LocalisationSingleton.GetFlagForLanguage(language);
    }
}
